package com.telerikacademy.meetup.provider.base;

import android.graphics.Bitmap;
import com.telerikacademy.meetup.model.base.IVenueDetail;
import io.reactivex.Flowable;
import io.reactivex.Observable;

public interface IVenueDetailsProvider {

    Flowable<Bitmap> getPhotos(final String placeId);

    Observable<IVenueDetail> getById(final String placeId);

    void connect();

    void disconnect();

    void setOnConnectionFailedListener(IOnConnectionFailedListener onConnectionFailedListener);

    interface IOnConnectionFailedListener {
        void onConnectionFailed(String errorMessage);
    }
}
