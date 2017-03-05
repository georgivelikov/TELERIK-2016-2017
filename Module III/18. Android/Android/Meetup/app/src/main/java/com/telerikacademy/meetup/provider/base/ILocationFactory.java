package com.telerikacademy.meetup.provider.base;

import com.telerikacademy.meetup.model.base.ILocation;

public interface ILocationFactory {

    ILocation createLocation(double latitude, double longitude);

    ILocation createLocation(double latitude, double longitude,
                             String locality, String thoroughfare,
                             String subThoroughfare);
}
