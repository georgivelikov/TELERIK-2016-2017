package com.telerikacademy.meetup.model.gson.nearby_search;

import com.google.gson.annotations.SerializedName;

public class Venue {

    @SerializedName("place_id")
    private String id;
    private String name;
    @SerializedName("geometry")
    private Geometry geometry;
    private float rating;
    private String[] types;
    @SerializedName("vicinity")
    private String address;

    public String getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public Geometry getGeometry() {
        return geometry;
    }

    public float getRating() {
        return rating;
    }

    public String[] getTypes() {
        return types;
    }

    public String getAddress() {
        return address;
    }
}
