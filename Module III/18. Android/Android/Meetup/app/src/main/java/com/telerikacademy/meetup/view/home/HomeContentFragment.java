package com.telerikacademy.meetup.view.home;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import butterknife.OnClick;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.provider.base.IIntentFactory;
import com.telerikacademy.meetup.provider.base.ILocationAware;
import com.telerikacademy.meetup.view.home.base.IHomeContentContract;
import com.telerikacademy.meetup.view.nearby_venues.NearbyVenuesActivity;

import javax.inject.Inject;

public class HomeContentFragment extends Fragment
        implements IHomeContentContract.View {

    private static final String EXTRA_VENUE_TYPE =
            HomeContentFragment.class.getCanonicalName() + ".VENUE_TYPE";
    private static final String EXTRA_CURRENT_LATITUDE =
            HomeContentFragment.class.getCanonicalName() + ".EXTRA_CURRENT_LATITUDE";
    private static final String EXTRA_CURRENT_LONGITUDE =
            HomeContentFragment.class.getCanonicalName() + ".EXTRA_CURRENT_LONGITUDE";
    private static final String EXTRA_CURRENT_LOCATION =
            HomeContentFragment.class.getCanonicalName() + ".EXTRA_CURRENT_LOCATION";

    @Inject
    IIntentFactory intentFactory;

    private IHomeContentContract.Presenter presenter;
    private ILocationAware locationProvider;

    @Override
    public void setPresenter(IHomeContentContract.Presenter presenter) {
        this.presenter = presenter;
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        locationProvider = (ILocationAware) context;
    }

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container,
                             @Nullable Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_home_content, container, false);
        BaseApplication.bind(this, view);
        return view;
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
        injectDependencies();
    }

    @OnClick(R.id.btn_restaurant)
    void showNearbyRestaurants() {
        Intent intent = createNearbyVenuesIntent()
                .putExtra(EXTRA_VENUE_TYPE, "restaurant");
        startActivity(intent);
    }

    @OnClick(R.id.btn_cafe)
    void showNearbyCafes() {
        Intent intent = createNearbyVenuesIntent()
                .putExtra(EXTRA_VENUE_TYPE, "cafe");
        startActivity(intent);
    }

    @OnClick(R.id.btn_bar)
    void showNearbyBars() {
        Intent intent = createNearbyVenuesIntent()
                .putExtra(EXTRA_VENUE_TYPE, "bar");
        startActivity(intent);
    }

    @OnClick(R.id.btn_casino)
    void showNearbyFastFoodRestaurants() {
        Intent intent = createNearbyVenuesIntent()
                .putExtra(EXTRA_VENUE_TYPE, "casino");
        startActivity(intent);
    }

    @OnClick(R.id.btn_night_club)
    void showNightClubs() {
        Intent intent = createNearbyVenuesIntent()
                .putExtra(EXTRA_VENUE_TYPE, "night_club");
        startActivity(intent);
    }

    @OnClick(R.id.btn_other)
    void showOtherVenues() {
        Intent intent = createNearbyVenuesIntent();
        startActivity(intent);
    }

    private Intent createNearbyVenuesIntent() {
        Intent nearbyVenuesIntent = intentFactory
                .createIntentToFront(NearbyVenuesActivity.class);

        if (locationProvider.getLocation() != null) {
            nearbyVenuesIntent
                    .putExtra(EXTRA_CURRENT_LOCATION, locationProvider.getLocation())
                    .putExtra(EXTRA_CURRENT_LATITUDE, locationProvider
                            .getLocation()
                            .getLatitude())
                    .putExtra(EXTRA_CURRENT_LONGITUDE, locationProvider
                            .getLocation()
                            .getLongitude());
        }

        return nearbyVenuesIntent;
    }

    private void injectDependencies() {
        BaseApplication
                .from(getContext())
                .getComponent()
                .getControllerComponent(new ControllerModule(
                        getActivity(), getFragmentManager()
                ))
                .inject(this);
    }
}
