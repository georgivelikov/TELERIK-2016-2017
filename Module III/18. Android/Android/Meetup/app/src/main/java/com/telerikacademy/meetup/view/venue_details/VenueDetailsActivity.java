package com.telerikacademy.meetup.view.venue_details;

import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import butterknife.OnClick;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.ui.fragment.GalleryFragment;
import com.telerikacademy.meetup.view.venue_details.base.IVenueDetailsContract;

import javax.inject.Inject;

public class VenueDetailsActivity extends AppCompatActivity {

    private static final String EXTRA_CURRENT_VENUE_ID =
            VenueDetailsActivity.class.getCanonicalName() + ".CURRENT_VENUE_ID";

    @Inject
    IVenueDetailsContract.Presenter presenter;
    @Inject
    FragmentManager fragmentManager;

    private GalleryFragment galleryFragment;
    private VenueDetailsContentFragment content;
    private String currentVenueId;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_venue_details);
        injectDependencies();
        initialize();
        setup();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        super.onPrepareOptionsMenu(menu);
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @OnClick(R.id.btn_start_navigation)
    void onStartNavigationButtonClick() {
        presenter.onNavigationButtonClick();
    }

    private void initialize() {
        currentVenueId = getIntent().getStringExtra(EXTRA_CURRENT_VENUE_ID);

        content = (VenueDetailsContentFragment) fragmentManager
                .findFragmentById(R.id.fragment_venue_details_content);

        galleryFragment = (GalleryFragment) fragmentManager
                .findFragmentById(R.id.fragment_venue_details_gallery);
    }

    private void setup() {
        presenter.setView(content);
        presenter.setVenueId(currentVenueId);
        content.setPresenter(presenter);
        content.setGallery(galleryFragment);

        android.support.v7.app.ActionBar actionBar = getSupportActionBar();
        Drawable actionBarBackground = getDrawable(R.drawable.gradient_bottom_black_transparent);
        actionBar.setBackgroundDrawable(actionBarBackground);
        actionBar.setDisplayShowTitleEnabled(false);
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
