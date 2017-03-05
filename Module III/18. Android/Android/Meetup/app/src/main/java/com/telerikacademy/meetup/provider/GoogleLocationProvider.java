package com.telerikacademy.meetup.provider;

import android.content.Context;
import android.location.Address;
import android.location.Geocoder;
import android.location.Location;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.GoogleApiAvailability;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.location.LocationListener;
import com.google.android.gms.location.LocationRequest;
import com.google.android.gms.location.LocationServices;
import com.telerikacademy.meetup.model.base.ILocation;
import com.telerikacademy.meetup.provider.base.ILocationFactory;
import com.telerikacademy.meetup.provider.base.LocationProvider;

import javax.inject.Inject;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;

public class GoogleLocationProvider extends LocationProvider
        implements GoogleApiClient.ConnectionCallbacks,
        GoogleApiClient.OnConnectionFailedListener, LocationListener {

    private static final int INTERVAL = 5000;
    private static final int FASTEST_INTERVAL = 5000;

    private final Context context;
    private final ILocationFactory locationFactory;

    private GoogleApiClient googleApiClient;
    private LocationRequest locationRequest;

    @Inject
    public GoogleLocationProvider(Context context, ILocationFactory locationFactory) {
        this.context = context;
        this.locationFactory = locationFactory;

        buildGoogleApiClient();
        createLocationRequest();
    }

    public void connect() {
        googleApiClient.connect();
    }

    public void disconnect() {
        googleApiClient.disconnect();
    }

    public boolean isConnected() {
        return googleApiClient.isConnected();
    }

    public boolean isConnecting() {
        return googleApiClient.isConnecting();
    }

    @Override
    public void onConnected(@Nullable Bundle bundle) {
        try {
            Location location = LocationServices.FusedLocationApi
                    .getLastLocation(googleApiClient);

            LocationServices.FusedLocationApi
                    .requestLocationUpdates(googleApiClient, locationRequest, this);

            if (getOnConnectedListener() != null) {
                getOnConnectedListener().onConnected(parseLocation(location));
            }

            GoogleApiAvailability.getInstance().isGooglePlayServicesAvailable(context);

        } catch (SecurityException ex) {
            if (getOnConnectionFailedListener() != null) {
                getOnConnectionFailedListener().onConnectionFailed(ex.getMessage());
            }
        }
    }

    @Override
    public void onConnectionSuspended(int i) {
    }

    @Override
    public void onConnectionFailed(@NonNull ConnectionResult connectionResult) {
        if (getOnConnectionFailedListener() != null) {
            getOnConnectionFailedListener().onConnectionFailed(
                    connectionResult.getErrorCode() + " " + connectionResult.getErrorMessage());
        }
    }

    @Override
    public void onLocationChanged(Location location) {
        if (getOnLocationChangeListener() != null) {
            getOnLocationChangeListener().onLocationChange(this.parseLocation(location));
        }
    }

    protected synchronized void buildGoogleApiClient() {
        if (googleApiClient == null) {
            googleApiClient = new GoogleApiClient.Builder(this.context)
                    .addConnectionCallbacks(this)
                    .addOnConnectionFailedListener(this)
                    .addApi(LocationServices.API)
                    .build();
        }
    }

    protected synchronized void createLocationRequest() {
        if (locationRequest == null) {
            locationRequest = LocationRequest.create()
                    .setPriority(LocationRequest.PRIORITY_HIGH_ACCURACY)
                    .setInterval(INTERVAL)
                    .setFastestInterval(FASTEST_INTERVAL);
        }
    }

    private ILocation parseLocation(Location location) {
        if (location == null) {
            return null;
        }

        double latitude = location.getLatitude();
        double longitude = location.getLongitude();

        Geocoder geocoder = new Geocoder(this.context, Locale.getDefault());
        List<Address> addresses = new ArrayList<>();

        try {
            addresses = geocoder.getFromLocation(latitude, longitude, 1);
        } catch (IOException e) {
            e.printStackTrace();
        }

        if (addresses != null && addresses.size() > 0) {
            Address address = addresses.get(0);

            String locality = address.getLocality();
            String thoroughfare = address.getThoroughfare();
            String subThoroughfare = address.getSubThoroughfare();

            return locationFactory.createLocation(latitude, longitude,
                    locality, thoroughfare, subThoroughfare);
        }

        return null;
    }
}
