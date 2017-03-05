package com.telerikacademy.meetup.network.local.base;

import android.graphics.Bitmap;
import com.telerikacademy.meetup.model.base.IVenue;
import io.reactivex.Single;

import java.util.List;

public interface ILocalData {

    Single<IVenue> saveVenueToRecent(final IVenue venue, final Bitmap picture);

    Single<List<IVenue>> getRecentVenues();

    void clearData();
}
