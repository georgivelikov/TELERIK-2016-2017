package com.telerikacademy.meetup.model;

import com.telerikacademy.meetup.model.base.ILocation;

public class Location implements ILocation {

    private final String STRING_EMPTY = "";

    private double latitude;
    private double longitude;
    private String locality;
    private String thoroughfare;
    private String subThoroughfare;

    public Location(double latitude, double longitude) {
        setLatitude(latitude);
        setLongitude(longitude);
    }

    public Location(double latitude, double longitude, String locality,
                    String thoroughfare, String subThoroughfare) {

        setLatitude(latitude);
        setLongitude(longitude);
        setLocality(locality);
        setThoroughfare(thoroughfare);
        setSubThoroughfare(subThoroughfare);
    }

    public double getLatitude() {
        return latitude;
    }

    public void setLatitude(double latitude) {
        this.latitude = latitude;
    }

    public double getLongitude() {
        return longitude;
    }

    public void setLongitude(double longitude) {
        this.longitude = longitude;
    }

    public String getLocality() {
        return locality;
    }

    public void setLocality(String locality) {
        this.locality = locality;
    }

    public String getThoroughfare() {
        return thoroughfare;
    }

    public void setThoroughfare(String thoroughfare) {
        this.thoroughfare = thoroughfare;
    }

    public String getSubThoroughfare() {
        return subThoroughfare;
    }

    public void setSubThoroughfare(String subThoroughfare) {
        this.subThoroughfare = subThoroughfare;
    }

    @Override
    public String toString() {
        String fullAddress = STRING_EMPTY;

        if (this.getThoroughfare() != null) {
            fullAddress += thoroughfare;
        }

        if (this.getSubThoroughfare() != null) {
            fullAddress += " " + getSubThoroughfare();
        }

        if (this.getLocality() != null) {
            fullAddress += ", " + getLocality();
        }

        return fullAddress;
    }
}
