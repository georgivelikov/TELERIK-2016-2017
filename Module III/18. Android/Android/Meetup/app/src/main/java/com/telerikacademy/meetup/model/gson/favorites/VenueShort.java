package com.telerikacademy.meetup.model.gson.favorites;

import com.google.gson.annotations.SerializedName;
import com.telerikacademy.meetup.model.base.IVenueShort;

public class VenueShort implements IVenueShort {

    @SerializedName("_id")
    private String id;
    private String googleId;
    @SerializedName("venueName")
    private String name;
    @SerializedName("venueAddress")
    private String address;

    @Override
    public String getId() {
        return id;
    }

    @Override
    public String getGoogleId() {
        return googleId;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public String getAddress() {
        return address;
    }
}
