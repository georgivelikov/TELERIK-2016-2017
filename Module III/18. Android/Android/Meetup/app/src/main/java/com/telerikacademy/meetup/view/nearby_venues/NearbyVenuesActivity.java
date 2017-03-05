package com.telerikacademy.meetup.view.nearby_venues;

import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;
import butterknife.BindView;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.network.remote.base.IVenueData;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialog;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialogFactory;
import com.telerikacademy.meetup.ui.fragment.base.ISearchBar;
import com.telerikacademy.meetup.ui.fragment.base.IToolbar;
import com.telerikacademy.meetup.view.home.HomeContentFragment;
import com.telerikacademy.meetup.view.nearby_venues.base.INearbyVenuesContract;
import io.reactivex.Observer;
import io.reactivex.android.schedulers.AndroidSchedulers;
import io.reactivex.disposables.Disposable;
import io.reactivex.schedulers.Schedulers;

import javax.inject.Inject;
import java.util.ArrayList;
import java.util.List;

public class NearbyVenuesActivity extends AppCompatActivity {

    private static final String EXTRA_VENUE_TYPE =
            HomeContentFragment.class.getCanonicalName() + ".VENUE_TYPE";
    private static final String EXTRA_CURRENT_LATITUDE =
            HomeContentFragment.class.getCanonicalName() + ".EXTRA_CURRENT_LATITUDE";
    private static final String EXTRA_CURRENT_LONGITUDE =
            HomeContentFragment.class.getCanonicalName() + ".EXTRA_CURRENT_LONGITUDE";
    private static final int DEFAULT_RADIUS = 1000;

    @Inject
    INearbyVenuesContract.Presenter presenter;
    @Inject
    FragmentManager fragmentManager;
    @Inject
    IDialogFactory dialogFactory;
    @Inject
    IVenueData venueData;

    @BindView(R.id.fragment_nearby_venues_search_header)
    View searchHeaderView;
    @BindView(R.id.rv_nearby_venues)
    RecyclerView venuesRecyclerView;
    @BindView(R.id.tv_empty)
    TextView emptyTextView;

    private NearbyVenuesAdapter recyclerAdapter;
    private INearbyVenuesContract.View content;
    private ISearchBar searchBar;
    private IToolbar toolbar;
    private IDialog progressDialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_nearby_venues);
        injectDependencies();
        initialize();
        setup();
        showNearbyVenues();
    }

    @Override
    protected void onStart() {
        super.onStart();
        toolbar.setNavigationDrawer(R.layout.activity_nearby_venues);
    }

    private void initialize() {
        toolbar = (IToolbar) fragmentManager
                .findFragmentById(R.id.fragment_nearby_venues_toolbar);

        content = (INearbyVenuesContract.View) fragmentManager.
                findFragmentById(R.id.fragment_nearby_venues_content);

        searchBar = (ISearchBar) fragmentManager
                .findFragmentById(R.id.fragment_nearby_venues_search_header);

        progressDialog = dialogFactory
                .createDialog()
                .withContent(R.string.dialog_loading_content)
                .withProgress();
    }

    private void setup() {
        content.setPresenter(presenter);
        presenter.setView(content);

        recyclerAdapter = new NearbyVenuesAdapter(new ArrayList<IVenue>());
        content.setAdapter(recyclerAdapter);
        searchBar.setFilter(recyclerAdapter);
    }

    private void showNearbyVenues() {
        double latitude = getIntent().getDoubleExtra(EXTRA_CURRENT_LATITUDE, 0);
        double longitude = getIntent().getDoubleExtra(EXTRA_CURRENT_LONGITUDE, 0);
        String venueType = getIntent().getStringExtra(EXTRA_VENUE_TYPE);

        venueData.getNearby(latitude, longitude, DEFAULT_RADIUS, venueType)
                .subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(new Observer<List<IVenue>>() {
                    @Override
                    public void onSubscribe(Disposable d) {
                        progressDialog.show();
                    }

                    @Override
                    public void onNext(List<IVenue> value) {
                        recyclerAdapter.swapData(value);
                        if (value == null || value.isEmpty()) {
                            emptyTextView.setVisibility(View.VISIBLE);
                            venuesRecyclerView.setVisibility(View.GONE);
                            searchHeaderView.setVisibility(View.GONE);
                        } else {
                            emptyTextView.setVisibility(View.GONE);
                            venuesRecyclerView.setVisibility(View.VISIBLE);
                            searchHeaderView.setVisibility(View.VISIBLE);
                        }
                    }

                    @Override
                    public void onError(Throwable e) {
                        progressDialog.hide();
                        showErrorMessage();
                        onBackPressed();
                    }

                    @Override
                    public void onComplete() {
                        progressDialog.hide();
                    }
                });
    }

    private void showErrorMessage() {
        Toast.makeText(NearbyVenuesActivity.this,
                "An error has occured", Toast.LENGTH_SHORT).show();
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
