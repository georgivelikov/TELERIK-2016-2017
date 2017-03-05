package com.telerikacademy.meetup.model.base;

import android.graphics.Bitmap;

import java.io.Serializable;

public interface IVenue extends Serializable {

    String getId();

    void setId(String id);

    String getName();

    void setName(String name);

    String getAddress();

    void setAddress(String address);

    String[] getTypes();

    void setTypes(String[] types);

    float getRating();

    void setRating(float rating);

    Bitmap getPhoto();

    void setPhoto(Bitmap photo);
}
