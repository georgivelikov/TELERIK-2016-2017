package com.telerikacademy.meetup.model.base;

import android.net.Uri;

public interface IVenueDetail extends IVenue {

    double getLatitude();

    void setLatitude(double latitude);

    double getLongitude();

    void setLongitude(double longitude);

    String getPhoneNumber();

    void setPhoneNumber(String phoneNumber);

    Uri getWebsiteUri();

    void setWebsiteUri(Uri websiteUri);
}
