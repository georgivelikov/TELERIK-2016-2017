package com.telerikacademy.meetup.provider.base;

import android.net.Uri;
import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.model.base.IVenueDetail;

public interface IVenueFactory {

    IVenue createVenue(String id, String name);

    IVenue createVenue(String id, String name, String address, String[] types, float rating);

    IVenueDetail createVenueDetail(String id, String name);

    IVenueDetail createVenueDetail(String id, String name, String address, String[] types,
                                   float rating, String phoneNumber, Uri websiteUri);
}
