package com.telerikacademy.meetup.provider.base;

public abstract class LocationProvider implements ILocationProvider {

    private IOnConnectedListener onConnectedListener;
    private IOnConnectionFailedListener onConnectionFailedListener;
    private IOnLocationChangeListener onLocationChangeListener;

    public void setOnConnectedListener(IOnConnectedListener onConnectedListener) {
        this.onConnectedListener = onConnectedListener;
    }

    public void setOnConnectionFailedListener(IOnConnectionFailedListener onConnectionFailedListener) {
        this.onConnectionFailedListener = onConnectionFailedListener;
    }

    public void setOnLocationChangeListener(IOnLocationChangeListener onLocationChangeListener) {
        this.onLocationChangeListener = onLocationChangeListener;
    }

    protected IOnConnectedListener getOnConnectedListener() {
        return onConnectedListener;
    }

    protected IOnConnectionFailedListener getOnConnectionFailedListener() {
        return onConnectionFailedListener;
    }

    protected IOnLocationChangeListener getOnLocationChangeListener() {
        return onLocationChangeListener;
    }
}
