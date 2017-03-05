package com.telerikacademy.meetup.config;

import com.telerikacademy.meetup.config.base.IApiConstants;

public final class ApiDevelopmentConstants implements IApiConstants {

    private static final String API_URL = "https://telerik-meetup.herokuapp.com";
    //private static final String API_URL = "http://10.0.2.2:8080";
    private static final String URL_SIGN_IN = API_URL + "/auth/login";
    private static final String URL_SIGN_UP = API_URL + "/auth/register";
    private static final String URL_GET_VENUES = API_URL + "/venue";
    private static final String URL_POST_COMMENT = API_URL + "/venue/comment";
    private static final String URL_GET_IS_VENUE_SAVED = API_URL + "/venue/saved";
    private static final String URL_POST_SAVE_VENUE_TO_USER = API_URL + "/user/saveVenueToUser";
    private static final String URL_POST_REMOVE_VENUE_FROM_USER = API_URL + "/user/removeVenueFromUser";
    private static final String URL_GET_USER = API_URL + "/user";
    private static final String DEFAULT_USERNAME = "anonymous";
    private static final int RESPONSE_SUCCESS_CODE = 200;
    private static final int RESPONSE_ERROR_CODE = 404;

    @Override
    public String signInUrl() {
        return URL_SIGN_IN;
    }

    @Override
    public String signUpUrl() {
        return URL_SIGN_UP;
    }

    @Override
    public String getVenueUrl() {
        return URL_GET_VENUES;
    }

    @Override
    public String isVenueSavedUrl() {
        return URL_GET_IS_VENUE_SAVED;
    }

    @Override
    public String saveVenueToUserUrl() {
        return URL_POST_SAVE_VENUE_TO_USER;
    }

    @Override
    public String removeVenueFromUserUrl() {
        return URL_POST_REMOVE_VENUE_FROM_USER;
    }

    @Override
    public String postCommentUrl() {
        return URL_POST_COMMENT;
    }

    @Override
    public String getUserUrl() {
        return URL_GET_USER;
    }

    @Override
    public int responseSuccessCode() {
        return RESPONSE_SUCCESS_CODE;
    }

    @Override
    public int responseErrorCode() {
        return RESPONSE_ERROR_CODE;
    }

    @Override
    public String defaultUsername() {
        return DEFAULT_USERNAME;
    }
}
