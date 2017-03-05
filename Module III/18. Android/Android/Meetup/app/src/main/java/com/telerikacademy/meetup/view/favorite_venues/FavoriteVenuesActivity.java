package com.telerikacademy.meetup.view.favorite_venues;

import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.ui.fragment.base.IToolbar;
import com.telerikacademy.meetup.view.favorite_venues.base.IFavoriteVenuesContract;

import javax.inject.Inject;

public class FavoriteVenuesActivity extends AppCompatActivity {

    @Inject
    IFavoriteVenuesContract.Presenter presenter;
    @Inject
    FragmentManager fragmentManager;

    private IToolbar toolbar;
    private IFavoriteVenuesContract.View content;

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_favorite_venues);
        injectDependencies();
        initialize();
        setup();
    }

    @Override
    protected void onStart() {
        super.onStart();
        toolbar.setNavigationDrawer(R.layout.activity_favorite_venues);
    }

    private void initialize() {
        toolbar = (IToolbar) fragmentManager
                .findFragmentById(R.id.fragment_favorite_venues_toolbar);

        content = (IFavoriteVenuesContract.View) fragmentManager
                .findFragmentById(R.id.fragment_favorite_venues_content);
    }

    private void setup() {
        presenter.setView(content);
        content.setPresenter(presenter);
    }

    private void injectDependencies() {
        BaseApplication
                .bind(this)
                .from(this)
                .getComponent()
                .getControllerComponent(new ControllerModule(
                        this, getSupportFragmentManager()
                ))
                .inject(this);
    }
}
