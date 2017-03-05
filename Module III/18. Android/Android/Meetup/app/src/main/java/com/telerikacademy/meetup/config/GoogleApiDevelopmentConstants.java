package com.telerikacademy.meetup.config;

import com.telerikacademy.meetup.config.base.IGoogleApiConstants;

public class GoogleApiDevelopmentConstants implements IGoogleApiConstants {

    private static final String API_URL = "https://maps.googleapis.com/maps/api";
    private static final String API_KEY = "AIzaSyCJX1sMGpv4p9Mpww85unBMQHrIr9VM2NM";

    private static final String URL_NEARBY_VENUES = API_URL + "/place/nearbysearch/json";

    @Override
    public String nearbySearchUrl(double latitude, double longitude, int radius, String venueType) {
        String url = String.format("%s?location=%s,%s&radius=%d&type=%s&key=%s",
                URL_NEARBY_VENUES, latitude, longitude, radius, venueType, API_KEY);

        return url;
    }

    @Override
    public String nearbySearchUrl(double latitude, double longitude, int radius) {
        String url = String.format("%s?location=%s,%s&radius=%d&key=%s",
                URL_NEARBY_VENUES, latitude, longitude, radius, API_KEY);

        return url;
    }
}
