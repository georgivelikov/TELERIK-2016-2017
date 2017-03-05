package com.telerikacademy.meetup.config.base;

public interface IApiConstants {

    String signInUrl();

    String signUpUrl();

    String getVenueUrl();

    String postCommentUrl();

    String isVenueSavedUrl();

    String saveVenueToUserUrl();

    String removeVenueFromUserUrl();

    String getUserUrl();

    int responseSuccessCode();

    int responseErrorCode();

    String defaultUsername();
}
