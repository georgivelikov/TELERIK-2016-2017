package com.telerikacademy.meetup.model.base;

import java.io.Serializable;

public interface ILocation extends Serializable {

    double getLatitude();

    void setLatitude(double latitude);

    double getLongitude();

    void setLongitude(double longitude);

    String getLocality();

    void setLocality(String locality);

    String getThoroughfare();

    void setThoroughfare(String thoroughfare);

    String getSubThoroughfare();

    void setSubThoroughfare(String subThoroughfare);
}
