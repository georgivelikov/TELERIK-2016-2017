package com.telerikacademy.meetup.network.remote;

import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import com.telerikacademy.meetup.config.base.IApiConstants;
import com.telerikacademy.meetup.config.base.IGoogleApiConstants;
import com.telerikacademy.meetup.model.base.IComment;
import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.model.gson.Comment;
import com.telerikacademy.meetup.model.gson.VenueSavedResponse;
import com.telerikacademy.meetup.model.gson.nearby_search.Venue;
import com.telerikacademy.meetup.network.remote.base.IVenueData;
import com.telerikacademy.meetup.provider.base.IVenueFactory;
import com.telerikacademy.meetup.util.base.IHttpRequester;
import com.telerikacademy.meetup.util.base.IHttpResponse;
import com.telerikacademy.meetup.util.base.IJsonParser;
import com.telerikacademy.meetup.util.base.IUserSession;
import io.reactivex.Observable;
import io.reactivex.Single;
import io.reactivex.functions.Function;
import io.reactivex.functions.Predicate;

import javax.inject.Inject;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.*;

public class VenueData implements IVenueData {

    private static final String STRING_NULL = "STRING_NULL";

    private final IGoogleApiConstants googleApiConstants;
    private final IApiConstants apiConstants;
    private final IHttpRequester httpRequester;
    private final IUserSession userSession;
    private final IJsonParser jsonParser;
    private final IVenueFactory venueFactory;
    private final Set<String> blacklistedTypes;

    @Inject
    public VenueData(IGoogleApiConstants googleApiConstants, IHttpRequester httpRequester, IJsonParser jsonParser,
                     IVenueFactory venueFactory, IApiConstants apiConstants, IUserSession userSession) {

        this.googleApiConstants = googleApiConstants;
        this.httpRequester = httpRequester;
        this.jsonParser = jsonParser;
        this.venueFactory = venueFactory;
        this.apiConstants = apiConstants;
        this.userSession = userSession;
        blacklistedTypes = new HashSet<>();
        populateBlacklist();
    }

    @Override
    public Observable<List<IVenue>> getNearby(double latitude, double longitude, int radius) {
        String nearbySearchUrl = googleApiConstants.nearbySearchUrl(latitude, longitude, radius);
        return getNearby(nearbySearchUrl);
    }

    @Override
    public Observable<List<IVenue>> getNearby(double latitude, double longitude,
                                              int radius, @Nullable String type) {

        if (type == null || type.isEmpty()) {
            return getNearby(latitude, longitude, radius);
        }

        String nearbySearchUrl = googleApiConstants
                .nearbySearchUrl(latitude, longitude, radius, type);
        return getNearby(nearbySearchUrl);
    }

    @Override
    public Observable<List<? extends IComment>> getComments(@NonNull String venueId) {
        if (venueId == null || venueId.isEmpty()) {
            return null;
        }

        String url = String.format("%s/%s", apiConstants.getVenueUrl(), venueId);

        return httpRequester
                .get(url)
                .map(new Function<IHttpResponse, String>() {
                    @Override
                    public String apply(IHttpResponse response) throws Exception {
                        String jsonResult = jsonParser.getDirectMember(response.getBody(), "result");
                        String jsonVenue = jsonParser.getDirectMember(jsonResult, "venue");
                        return jsonVenue == null ? STRING_NULL : jsonVenue;
                    }
                })
                .filter(new Predicate<String>() {
                    @Override
                    public boolean test(String jsonVenue) throws Exception {
                        return jsonVenue != STRING_NULL;
                    }
                })
                .map(new Function<String, List<? extends IComment>>() {
                    @Override
                    public List<? extends IComment> apply(String jsonVenue) throws Exception {
                        return jsonParser.getDirectArray(jsonVenue, "comments", Comment.class);
                    }
                });
    }

    @Override
    public Single<String> submitComment(IVenue venue, CharSequence comment) {
        String username = userSession.getUsername();
        if (username == null) {
            username = apiConstants.defaultUsername();
        }

        Map<String, String> body = new HashMap<>();
        body.put("googleId", venue.getId());
        body.put("venueName", venue.getName());
        body.put("venueAddress", venue.getAddress());
        body.put("author", username);
        body.put("text", comment.toString());
        body.put("postDate", getCurrentDateUTC());

        return httpRequester
                .post(apiConstants.postCommentUrl(), body)
                .map(new Function<IHttpResponse, String>() {
                    @Override
                    public String apply(IHttpResponse response) throws Exception {
                        if (response.getCode() == apiConstants.responseErrorCode()) {
                            throw new Error(response.getMessage());
                        }

                        return response.getMessage();
                    }
                })
                .single(STRING_NULL);
    }

    public Single<String> saveVenueToUser(IVenue venue) {
        Map<String, String> body = new HashMap<>();
        body.put("googleId", venue.getId());
        body.put("venueName", venue.getName());
        body.put("venueAddress", venue.getAddress());
        body.put("username", userSession.getUsername());

        return httpRequester
                .post(apiConstants.saveVenueToUserUrl(), body)
                .map(new Function<IHttpResponse, String>() {
                    @Override
                    public String apply(IHttpResponse response) throws Exception {
                        if (response.getCode() == apiConstants.responseErrorCode()) {
                            throw new Error(response.getMessage());
                        }
                        return response.getMessage();
                    }
                })
                .single(STRING_NULL);
    }

    public Single<String> removeVenueFromUser(IVenue venue) {
        Map<String, String> body = new HashMap<>();
        body.put("googleId", venue.getId());
        body.put("username", userSession.getUsername());

        return httpRequester
                .post(apiConstants.removeVenueFromUserUrl(), body)
                .map(new Function<IHttpResponse, String>() {
                    @Override
                    public String apply(IHttpResponse response) throws Exception {
                        if (response.getCode() == apiConstants.responseErrorCode()) {
                            throw new Error(response.getMessage());
                        }
                        return response.getMessage();
                    }
                })
                .single(STRING_NULL);
    }

    public Observable<Boolean> isVenueSavedToUser(IVenue venue) {
        String url = String.format("%s/%s/%s", apiConstants.isVenueSavedUrl(), venue.getId(), userSession.getUsername());
        return httpRequester
                .get(url)
                .map(new Function<IHttpResponse, Boolean>() {
                    @Override
                    public Boolean apply(IHttpResponse response) throws Exception {
                        if (response.getCode() == apiConstants.responseErrorCode()) {
                            return false;
                        }

                        String reusltJson = jsonParser.getDirectMember(response.getBody(), "result");
                        VenueSavedResponse res = jsonParser.fromJson(reusltJson, VenueSavedResponse.class);
                        return res.isSavedToUser;
                    }
                });
    }

    private Observable<List<IVenue>> getNearby(String nearbySearchUrl) {
        return httpRequester
                .get(nearbySearchUrl)
                .map(new Function<IHttpResponse, List<IVenue>>() {
                    @Override
                    public List<IVenue> apply(IHttpResponse response) throws Exception {
                        List<Venue> venues = jsonParser
                                .getDirectArray(response.getBody(), "results", Venue.class);

                        return parseVenues(venues);
                    }
                });
    }

    private List<IVenue> parseVenues(List<Venue> venues) {
        List<IVenue> parsedVenues = new ArrayList<>();

        for (final Venue venue : venues) {
            IVenue parsedVenue = venueFactory.createVenue(
                    venue.getId(),
                    venue.getName(),
                    venue.getAddress(),
                    parseVenueTypes(venue.getTypes()),
                    venue.getRating()
            );

            parsedVenues.add(parsedVenue);
        }

        return parsedVenues;
    }

    private String[] parseVenueTypes(String[] venueTypes) {
        final char OLD_SEPARATOR = '_';
        final char NEW_SEPARATOR = ' ';
        final int MAX_VENUE_TYPES = 3;

        final int venueTypesCount = Math.min(venueTypes.length, MAX_VENUE_TYPES);
        List<String> parsedVenueTypes = new ArrayList<>();

        for (int i = 0; i < venueTypesCount; i++) {
            String venueType = venueTypes[i];
            if (blacklistedTypes.contains(venueType)) {
                continue;
            }

            venueType = venueType.replace(OLD_SEPARATOR, NEW_SEPARATOR);
            parsedVenueTypes.add(venueType);
        }

        return parsedVenueTypes.toArray(new String[parsedVenueTypes.size()]);
    }

    private String getCurrentDateUTC() {
        Date currentDate = new Date();
        DateFormat sourceFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        sourceFormat.setTimeZone(TimeZone.getTimeZone("UTC"));
        String parsedDate = sourceFormat.format(currentDate);
        return parsedDate;
    }

    private void populateBlacklist() {
        blacklistedTypes.add("point_of_interest");
        blacklistedTypes.add("establishment");
    }
}
