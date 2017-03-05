package com.telerikacademy.meetup.view.review;

import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.ui.fragment.base.IToolbar;
import com.telerikacademy.meetup.view.review.base.IReviewContract;
import com.telerikacademy.meetup.view.venue_details.VenueDetailsContentFragment;

import javax.inject.Inject;

public class ReviewActivity extends AppCompatActivity {

    private static final String EXTRA_VENUE =
            VenueDetailsContentFragment.class.getCanonicalName() + ".VENUE";

    @Inject
    IReviewContract.Presenter presenter;
    @Inject
    FragmentManager fragmentManager;

    private IReviewContract.View view;
    private IVenue currentVenue;
    private IToolbar toolbar;

    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_review);
        injectDependencies();
        initialize();
        setup();
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        getSupportActionBar().setHomeAsUpIndicator(R.drawable.ic_solid_close);
        toolbar.inflateMenu(R.menu.toolbar_review_menu, menu, getMenuInflater());
        toolbar.setBackButton(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                onBackPressed();
            }
        });

        return super.onCreateOptionsMenu(menu);
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.action_submit_comment:
                view.onSubmitButtonClick();
                break;
        }

        return super.onOptionsItemSelected(item);
    }

    private void initialize() {
        currentVenue = (IVenue) getIntent().getSerializableExtra(EXTRA_VENUE);

        toolbar = (IToolbar) fragmentManager
                .findFragmentById(R.id.fragment_review_toolbar);

        view = (IReviewContract.View) fragmentManager
                .findFragmentById(R.id.fragment_review_content);
    }

    private void setup() {
        setTitle(currentVenue.getName());
        presenter.setView(view);
        presenter.setVenue(currentVenue);
        view.setPresenter(presenter);
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
