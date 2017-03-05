package com.telerikacademy.meetup.config.di.component;

import com.telerikacademy.meetup.config.di.annotation.ControllerScope;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.ui.fragment.RecentVenuesFragment;
import com.telerikacademy.meetup.ui.fragment.ToolbarFragment;
import com.telerikacademy.meetup.view.favorite_venues.FavoriteVenuesActivity;
import com.telerikacademy.meetup.view.favorite_venues.FavoriteVenuesContentFragment;
import com.telerikacademy.meetup.view.home.HomeActivity;
import com.telerikacademy.meetup.view.home.HomeContentFragment;
import com.telerikacademy.meetup.view.home.HomeHeaderFragment;
import com.telerikacademy.meetup.view.nearby_venues.NearbyVenuesActivity;
import com.telerikacademy.meetup.view.nearby_venues.NearbyVenuesContentFragment;
import com.telerikacademy.meetup.view.review.ReviewActivity;
import com.telerikacademy.meetup.view.review.ReviewContentFragment;
import com.telerikacademy.meetup.view.sign_in.SignInActivity;
import com.telerikacademy.meetup.view.sign_in.SignInContentFragment;
import com.telerikacademy.meetup.view.sign_up.SignUpActivity;
import com.telerikacademy.meetup.view.sign_up.SignUpContentFragment;
import com.telerikacademy.meetup.view.venue_details.VenueDetailsActivity;
import com.telerikacademy.meetup.view.venue_details.VenueDetailsContentFragment;
import dagger.Subcomponent;

@ControllerScope
@Subcomponent(modules = {ControllerModule.class})
public interface ControllerComponent {

    void inject(HomeActivity homeActivity);

    void inject(HomeHeaderFragment homeHeaderFragment);

    void inject(HomeContentFragment homeContentFragment);

    void inject(NearbyVenuesActivity nearbyVenuesActivity);

    void inject(NearbyVenuesContentFragment nearbyVenuesContentFragment);

    void inject(FavoriteVenuesActivity favoriteVenuesActivity);

    void inject(FavoriteVenuesContentFragment favoriteVenuesContentFragment);

    void inject(VenueDetailsActivity venueDetailsActivity);

    void inject(VenueDetailsContentFragment venueDetailsContentFragment);

    void inject(SignInActivity signInActivity);

    void inject(SignInContentFragment signInContentFragment);

    void inject(SignUpActivity signUpActivity);

    void inject(ReviewActivity reviewActivity);

    void inject(SignUpContentFragment signUpContentFragment);

    void inject(ToolbarFragment toolbarFragment);

    void inject(RecentVenuesFragment recentVenuesFragment);

    void inject(ReviewContentFragment reviewContentFragment);
}
