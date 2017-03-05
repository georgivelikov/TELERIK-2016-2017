package com.telerikacademy.meetup.model;

import android.net.Uri;
import com.telerikacademy.meetup.model.base.IVenueDetail;

public class VenueDetail extends Venue
        implements IVenueDetail {

    private double latitude = -1;
    private double longitude = -1;
    private String phoneNumber;
    private transient Uri websiteUri;

    public VenueDetail(String id, String name) {
        super(id, name);
    }

    public VenueDetail(String id, String name, String address, String[] types,
                       float rating, String phoneNumber, Uri websiteUri) {

        super(id, name, address, types, rating);
        setPhoneNumber(phoneNumber);
        setWebsiteUri(websiteUri);
    }

    @Override
    public double getLatitude() {
        return latitude;
    }

    @Override
    public void setLatitude(double latitude) {
        this.latitude = latitude;
    }

    @Override
    public double getLongitude() {
        return longitude;
    }

    @Override
    public void setLongitude(double longitude) {
        this.longitude = longitude;
    }

    @Override
    public String getPhoneNumber() {
        return phoneNumber;
    }

    @Override
    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    @Override
    public Uri getWebsiteUri() {
        return websiteUri;
    }

    @Override
    public void setWebsiteUri(Uri websiteUri) {
        this.websiteUri = websiteUri;
    }
}
