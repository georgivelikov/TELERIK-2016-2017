package com.telerikacademy.meetup.ui.fragment;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.LayoutRes;
import android.support.annotation.MenuRes;
import android.support.v4.app.Fragment;
import android.support.v4.app.NavUtils;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.view.*;
import com.mikepenz.fontawesome_typeface_library.FontAwesome;
import com.mikepenz.google_material_typeface_library.GoogleMaterial;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.provider.base.IIntentFactory;
import com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawer;
import com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawerItem;
import com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawerItemFactory;
import com.telerikacademy.meetup.ui.fragment.base.IToolbar;
import com.telerikacademy.meetup.util.base.IUserSession;
import com.telerikacademy.meetup.view.favorite_venues.FavoriteVenuesActivity;
import com.telerikacademy.meetup.view.home.HomeActivity;
import com.telerikacademy.meetup.view.nearby_venues.NearbyVenuesActivity;
import com.telerikacademy.meetup.view.sign_in.SignInActivity;
import com.telerikacademy.meetup.view.sign_up.SignUpActivity;

import javax.inject.Inject;

public class ToolbarFragment extends Fragment
        implements IToolbar {

    private static final int NAV_HOME_ID = 0;
    private static final int NAV_EXPLORE_ID = 1;
    private static final int NAV_FAVORITE_ID = 2;
    private static final int NAV_SIGN_IN_ID = 3;
    private static final int NAV_SIGN_UP_ID = 4;
    private static final int NAV_SIGN_OUT_ID = 4;
    private static final int NAV_DRAWER_WIDTH = 270;

    @Inject
    IDrawer navigationDrawer;
    @Inject
    IUserSession userSession;
    @Inject
    IIntentFactory intentFactory;
    @Inject
    IDrawerItemFactory drawerItemFactory;

    private Toolbar toolbar;
    private ActionBar actionBar;
    private AppCompatActivity currentActivity;

    public ToolbarFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        return inflater.inflate(R.layout.fragment_toolbar, container, false);
    }

    @Override
    public void onStart() {
        super.onStart();
        injectDependencies();

        if (!(getActivity() instanceof AppCompatActivity)) {
            throw new ClassCastException(
                    "Activity must be of type AppCompatActivity in order to support custom Toolbar.");
        }

        currentActivity = (AppCompatActivity) getActivity();
        toolbar = (Toolbar) currentActivity.findViewById(R.id.toolbar);
        currentActivity.setSupportActionBar(toolbar);
        actionBar = currentActivity.getSupportActionBar();
    }

    @Override
    public void setBackButton() {
        setBackButton(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                NavUtils.navigateUpFromSameTask(currentActivity);
            }
        });
    }

    @Override
    public void setBackButton(View.OnClickListener clickListener) {
        actionBar.setDisplayHomeAsUpEnabled(true);
        actionBar.setDisplayShowHomeEnabled(true);
        toolbar.setNavigationOnClickListener(clickListener);
    }

    @Override
    public void inflateMenu(@MenuRes int menuRes, Menu menu, MenuInflater inflater) {
        super.onCreateOptionsMenu(menu, inflater);
        menu.clear();
        currentActivity.getMenuInflater().inflate(menuRes, menu);
    }

    @Override
    public void setNavigationDrawer(@LayoutRes long selectedItemId) {
        createDrawerBuilder();

        final Intent homeIntent = intentFactory.createIntentToFront(HomeActivity.class);
        final Intent nearbyVenuesIntent = intentFactory.createIntentToFront(NearbyVenuesActivity.class);
        final Intent favoriteVenuesIntent = intentFactory.createIntentToFront(FavoriteVenuesActivity.class);
        final Intent signInIntent = intentFactory.createIntentToFront(SignInActivity.class);
        final Intent signUpIntent = intentFactory.createIntentToFront(SignUpActivity.class);

        if (userSession.isUserLoggedIn()) {
            IDrawerItem itemFavorite = drawerItemFactory
                    .createPrimaryDrawerItem()
                    .withIdentifier(R.layout.activity_favorite_venues)
                    .withName(R.string.nav_favorite)
                    .withIcon(FontAwesome.Icon.faw_heart);

            IDrawerItem itemSignOut = drawerItemFactory
                    .createPrimaryDrawerItem()
                    .withName(R.string.nav_sign_out)
                    .withIcon(FontAwesome.Icon.faw_sign_out);

            navigationDrawer
                    .withDrawerItems(
                            itemFavorite,
                            drawerItemFactory.createDividerDrawerItem(),
                            itemSignOut
                    )
                    .withOnDrawerItemClickListener(new IDrawer.OnDrawerItemClickListener() {
                        @Override
                        public boolean onClick(View view, int position) {
                            switch (position) {
                                case NAV_HOME_ID:
                                    startActivity(homeIntent);
                                    break;
                                case NAV_EXPLORE_ID:
                                    startActivity(nearbyVenuesIntent);
                                    break;
                                case NAV_FAVORITE_ID:
                                    startActivity(favoriteVenuesIntent);
                                    break;
                                case NAV_SIGN_OUT_ID:
                                    userSession.clearSession();
                                    startActivity(signInIntent);
                                    break;
                            }

                            return false;
                        }
                    });
        } else {
            IDrawerItem itemSignIn = drawerItemFactory
                    .createPrimaryDrawerItem()
                    .withIdentifier(R.layout.activity_sign_in)
                    .withName(R.string.nav_sign_in)
                    .withIcon(FontAwesome.Icon.faw_sign_in);

            IDrawerItem itemSignUp = drawerItemFactory
                    .createPrimaryDrawerItem()
                    .withIdentifier(R.layout.activity_sign_up)
                    .withName(R.string.nav_sign_up)
                    .withIcon(GoogleMaterial.Icon.gmd_person_add);

            navigationDrawer
                    .withDrawerItems(
                            drawerItemFactory.createDividerDrawerItem(),
                            itemSignIn,
                            itemSignUp
                    )
                    .withOnDrawerItemClickListener(new IDrawer.OnDrawerItemClickListener() {
                        @Override
                        public boolean onClick(View view, int position) {
                            switch (position) {
                                case NAV_HOME_ID:
                                    startActivity(homeIntent);
                                    break;
                                case NAV_EXPLORE_ID:
                                    startActivity(nearbyVenuesIntent);
                                    break;
                                case NAV_SIGN_IN_ID:
                                    startActivity(signInIntent);
                                    break;
                                case NAV_SIGN_UP_ID:
                                    startActivity(signUpIntent);
                                    break;
                            }

                            return false;
                        }
                    });
        }

        navigationDrawer.withSelectedItem(selectedItemId).build();
    }

    private void createDrawerBuilder() {
        IDrawerItem itemHome = drawerItemFactory
                .createPrimaryDrawerItem()
                .withIdentifier(R.layout.activity_home)
                .withName(R.string.nav_home)
                .withIcon(GoogleMaterial.Icon.gmd_home);

        IDrawerItem itemNearby = drawerItemFactory
                .createPrimaryDrawerItem()
                .withIdentifier(R.layout.activity_nearby_venues)
                .withName(R.string.nav_explore)
                .withIcon(GoogleMaterial.Icon.gmd_explore);

        navigationDrawer
                .withToolbar(toolbar)
                .withTranslucentStatusBar(false)
                .withDrawerWidth(NAV_DRAWER_WIDTH)
                .withDrawerItems(itemHome, itemNearby);
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
