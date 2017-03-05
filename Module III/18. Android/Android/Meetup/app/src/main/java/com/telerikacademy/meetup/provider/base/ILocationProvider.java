package com.telerikacademy.meetup.provider.base;

import com.telerikacademy.meetup.model.base.ILocation;

public interface ILocationProvider {

    void connect();

    void disconnect();

    boolean isConnected();

    boolean isConnecting();

    void setOnConnectedListener(IOnConnectedListener onConnectedListener);

    void setOnConnectionFailedListener(IOnConnectionFailedListener onConnectionFailedListener);

    void setOnLocationChangeListener(IOnLocationChangeListener onLocationChangeListener);

    interface IOnConnectedListener {
        void onConnected(ILocation location);
    }

    interface IOnConnectionFailedListener {
        void onConnectionFailed(String errorMessage);
    }

    interface IOnLocationChangeListener {
        void onLocationChange(ILocation location);
    }
}
