package com.telerikacademy.meetup.view.home;

import android.util.Log;
import com.telerikacademy.meetup.model.base.ILocation;
import com.telerikacademy.meetup.provider.base.ILocationProvider;
import com.telerikacademy.meetup.view.home.base.IHomeHeaderContract;

import javax.inject.Inject;

public class HomeHeaderPresenter implements IHomeHeaderContract.Presenter {

    private static final String TAG = HomeHeaderPresenter.class.getSimpleName();

    private ILocationProvider locationProvider;
    private IHomeHeaderContract.View view;
    private ILocation currentLocation;

    @Inject
    public HomeHeaderPresenter(ILocationProvider locationProvider) {
        this.locationProvider = locationProvider;
        setupLocationListeners();
    }

    @Override
    public void setView(IHomeHeaderContract.View view) {
        this.view = view;
    }

    @Override
    public void subscribe() {
        locationProvider.connect();
    }

    @Override
    public void unsubscribe() {
        locationProvider.disconnect();
    }

    @Override
    public void update() {
        view.requestPermissions();
        view.showEnableLocationDialog();

        if (view.checkPermissions() &&
                !locationProvider.isConnected() &&
                !locationProvider.isConnecting()) {

            locationProvider.connect();
        }

        setTitle(currentLocation);
    }

    @Override
    public ILocation getLocation() {
        return currentLocation;
    }

    private void setupLocationListeners() {
        locationProvider.setOnLocationChangeListener(new ILocationProvider.IOnLocationChangeListener() {
            @Override
            public void onLocationChange(ILocation location) {
                if (currentLocation == null) {
                    setTitle(location);
                }
                currentLocation = location;
            }
        });
        locationProvider.setOnConnectedListener(new ILocationProvider.IOnConnectedListener() {
            @Override
            public void onConnected(ILocation location) {
                currentLocation = location;
                setTitle(location);
            }
        });
        locationProvider.setOnConnectionFailedListener(new ILocationProvider.IOnConnectionFailedListener() {
            @Override
            public void onConnectionFailed(String errorMessage) {
                Log.e(TAG, errorMessage);
                setTitle(null);
            }
        });
    }

    private void setTitle(ILocation location) {
        final String LOCATION_NOT_FOUND = "Unknown location";

        if (location == null) {
            view.setTitle(LOCATION_NOT_FOUND);
            view.setSubtitle("");
            return;
        }

        String locality = location.getLocality();
        String thoroughfare = location.getThoroughfare();
        String subThoroughfare = location.getSubThoroughfare();

        locality = locality == null ? "" : locality;
        thoroughfare = thoroughfare == null ? "" : thoroughfare;
        subThoroughfare = subThoroughfare == null ? "" : subThoroughfare;

        if (locality.isEmpty() && thoroughfare.isEmpty()) {
            view.setTitle(LOCATION_NOT_FOUND);
            view.setSubtitle("");
        } else if (locality.isEmpty()) {
            view.setTitle(thoroughfare);
            view.setSubtitle(subThoroughfare);
        } else {
            view.setTitle(locality);

            String subtitle;
            if (!thoroughfare.isEmpty()) {
                subtitle = thoroughfare;

                if (!subThoroughfare.isEmpty()) {
                    subtitle = String.format("%s, %s", thoroughfare, subThoroughfare);
                }
            } else {
                subtitle = subThoroughfare;
            }

            view.setSubtitle(subtitle);
        }
    }
}
