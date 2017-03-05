package com.telerikacademy.meetup.model;

import android.graphics.Bitmap;
import android.support.annotation.Nullable;
import com.telerikacademy.meetup.model.base.IVenue;

public class Venue implements IVenue {

    private String id;
    private String name;
    private String address;
    private String[] types;
    private float rating;
    private transient Bitmap photo;

    public Venue(String id, String name) {
        setId(id);
        setName(name);
    }

    public Venue(String id, String name, String address, String[] types, float rating) {
        this(id, name);
        setAddress(address);
        setTypes(types);
        setRating(rating);
    }

    @Override
    public String getId() {
        return id;
    }

    @Override
    public void setId(String id) {
        if (id == null) {
            throw new IllegalArgumentException("Venues.setId parameter cannot be null");
        }

        this.id = id;
    }

    @Override
    public String getName() {
        return name;
    }

    @Override
    public void setName(String name) {
        if (name == null) {
            throw new IllegalArgumentException("Venue.setName parameter cannot be null.");
        }

        this.name = name;
    }

    @Override
    public String getAddress() {
        return address;
    }

    @Override
    public void setAddress(String address) {
        this.address = address;
    }

    @Override
    public String[] getTypes() {
        return types;
    }

    @Override
    public void setTypes(String[] types) {
        this.types = types;
    }

    @Override
    public float getRating() {
        return rating;
    }

    @Override
    public void setRating(float rating) {
        this.rating = rating;
    }

    @Override
    @Nullable
    public Bitmap getPhoto() {
        return photo;
    }

    @Override
    public void setPhoto(Bitmap photo) {
        this.photo = photo;
    }
}
