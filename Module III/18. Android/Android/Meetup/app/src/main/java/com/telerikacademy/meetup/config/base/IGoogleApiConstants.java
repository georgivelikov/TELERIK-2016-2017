package com.telerikacademy.meetup.config.base;

public interface IGoogleApiConstants {

    String nearbySearchUrl(double latitude, double longitude, int radius);

    String nearbySearchUrl(double latitude, double longitude, int radius, String venueType);
}
