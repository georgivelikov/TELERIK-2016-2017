package com.telerikacademy.meetup.provider;

import android.net.Uri;
import com.telerikacademy.meetup.model.Venue;
import com.telerikacademy.meetup.model.VenueDetail;
import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.model.base.IVenueDetail;
import com.telerikacademy.meetup.provider.base.IVenueFactory;

public class VenueFactory implements IVenueFactory {

    @Override
    public IVenue createVenue(String id, String name) {
        return new Venue(id, name);
    }

    @Override
    public IVenue createVenue(String id, String name, String address, String[] types, float rating) {
        return new Venue(id, name, address, types, rating);
    }

    @Override
    public IVenueDetail createVenueDetail(String id, String name) {
        return new VenueDetail(id, name);
    }

    @Override
    public IVenueDetail createVenueDetail(String id, String name, String address, String[] types,
                                          float rating, String phoneNumber, Uri websiteUri) {

        return new VenueDetail(id, name, address, types, rating, phoneNumber, websiteUri);
    }
}
