package com.telerikacademy.meetup.provider;

import com.telerikacademy.meetup.model.Location;
import com.telerikacademy.meetup.model.base.ILocation;
import com.telerikacademy.meetup.provider.base.ILocationFactory;

public class LocationFactory implements ILocationFactory {

    @Override
    public ILocation createLocation(double latitude, double longitude) {
        return new Location(latitude, longitude);
    }

    @Override
    public ILocation createLocation(double latitude, double longitude,
                                    String locality, String thoroughfare,
                                    String subThoroughfare) {

        return new Location(latitude, longitude,
                locality, thoroughfare, subThoroughfare);
    }
}
