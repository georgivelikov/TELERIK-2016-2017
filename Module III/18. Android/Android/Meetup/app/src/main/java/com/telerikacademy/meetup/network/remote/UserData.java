package com.telerikacademy.meetup.network.remote;

import com.telerikacademy.meetup.config.base.IApiConstants;
import com.telerikacademy.meetup.model.base.IUser;
import com.telerikacademy.meetup.model.base.IVenueShort;
import com.telerikacademy.meetup.model.gson.favorites.VenueShort;
import com.telerikacademy.meetup.network.remote.base.IUserData;
import com.telerikacademy.meetup.util.base.*;
import io.reactivex.Observable;
import io.reactivex.Single;
import io.reactivex.functions.Function;

import javax.inject.Inject;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class UserData implements IUserData {

    private final IApiConstants apiConstants;
    private final IHttpRequester httpRequester;
    private final IJsonParser jsonParser;
    private final IUserSession userSession;
    private final IHashProvider hashProvider;
    private final Type userModelType;

    @Inject
    public UserData(IApiConstants apiConstants, IHttpRequester httpRequester,
                    IJsonParser jsonParser, IUserSession userSession,
                    IHashProvider hashProvider, Type userModelType) {

        this.apiConstants = apiConstants;
        this.httpRequester = httpRequester;
        this.jsonParser = jsonParser;
        this.userSession = userSession;
        this.hashProvider = hashProvider;
        this.userModelType = userModelType;
    }

    @Override
    public Observable<IUser> signIn(String username, String password) {
        Map<String, String> userCredentials = new HashMap<>();
        String passHash = hashProvider.hashPassword(password);
        userCredentials.put("username", username);
        userCredentials.put("passHash", passHash);

        return httpRequester
                .post(apiConstants.signInUrl(), userCredentials)
                .map(new Function<IHttpResponse, IUser>() {
                    @Override
                    public IUser apply(IHttpResponse iHttpResponse) throws Exception {
                        if (iHttpResponse.getCode() == apiConstants.responseErrorCode()) {
                            throw new Error(iHttpResponse.getMessage());
                        }

                        String responseBody = iHttpResponse.getBody().toString();
                        String userJson = jsonParser.getDirectMember(responseBody, "result");
                        IUser resultUser = jsonParser.fromJson(userJson, userModelType);

                        userSession.setUsername(resultUser.getUsername());
                        userSession.setId(resultUser.getId());

                        return resultUser;
                    }
                });
    }

    @Override
    public Observable<IUser> signUp(String username, String password) {
        Map<String, String> userCredentials = new HashMap<>();
        String passHash = hashProvider.hashPassword(password);
        userCredentials.put("username", username);
        userCredentials.put("passHash", passHash);

        return httpRequester
                .post(apiConstants.signUpUrl(), userCredentials)
                .map(new Function<IHttpResponse, IUser>() {
                    @Override
                    public IUser apply(IHttpResponse iHttpResponse) throws Exception {
                        if (iHttpResponse.getCode() == apiConstants.responseErrorCode()) {
                            throw new Error(iHttpResponse.getMessage());
                        }

                        String responseBody = iHttpResponse.getBody().toString();
                        String userJson = jsonParser.getDirectMember(responseBody, "result");
                        IUser resultUser = jsonParser.fromJson(userJson, userModelType);

                        return resultUser;
                    }
                });
    }

    @Override
    public Single<List<? extends IVenueShort>> getSavedVenues(String username) {
        String usersUrl = String.format("%s/%s", apiConstants.getUserUrl(), username);

        return httpRequester
                .get(usersUrl)
                .map(new Function<IHttpResponse, List<? extends IVenueShort>>() {
                    @Override
                    public List<? extends IVenueShort> apply(IHttpResponse response) throws Exception {
                        String jsonResult = jsonParser.getDirectMember(response.getBody(), "result");
                        String jsonUser = jsonParser.getDirectMember(jsonResult, "user");
                        return jsonParser.getDirectArray(jsonUser, "favorites", VenueShort.class);
                    }
                })
                .single(new ArrayList<IVenueShort>());
    }
}
