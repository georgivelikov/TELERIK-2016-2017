package com.telerikacademy.meetup.view.nearby_venues;

import com.telerikacademy.meetup.view.nearby_venues.base.INearbyVenuesContract;

public class NearbyVenuesPresenter implements INearbyVenuesContract.Presenter {

    private INearbyVenuesContract.View view;

    @Override
    public void setView(INearbyVenuesContract.View view) {
        this.view = view;
    }
}
