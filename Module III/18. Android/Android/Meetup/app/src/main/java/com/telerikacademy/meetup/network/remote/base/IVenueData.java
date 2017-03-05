package com.telerikacademy.meetup.network.remote.base;

import com.telerikacademy.meetup.model.base.IComment;
import com.telerikacademy.meetup.model.base.IVenue;
import io.reactivex.Observable;
import io.reactivex.Single;

import java.util.List;

public interface IVenueData {

    Observable<List<IVenue>> getNearby(double latitude, double longitude, int radius);

    Observable<List<IVenue>> getNearby(double latitude, double longitude, int radius, String type);

    Observable<List<? extends IComment>> getComments(String venueId);

    Single<String> submitComment(IVenue venue, CharSequence comment);

    Single<String> saveVenueToUser(IVenue venue);

    Single<String> removeVenueFromUser(IVenue venue);

    Observable<Boolean> isVenueSavedToUser(IVenue venue);
}
