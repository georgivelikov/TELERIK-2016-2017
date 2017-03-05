package com.telerikacademy.meetup.view.home;

import android.Manifest;
import android.content.Context;
import android.content.Intent;
import android.location.LocationManager;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.provider.Settings;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import butterknife.BindView;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialog;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialogFactory;
import com.telerikacademy.meetup.ui.fragment.ToolbarFragment;
import com.telerikacademy.meetup.util.base.IPermissionHandler;
import com.telerikacademy.meetup.view.home.base.IHomeHeaderContract;

import javax.inject.Inject;

public class HomeHeaderFragment extends ToolbarFragment
        implements IHomeHeaderContract.View {

    private static final String LOCATION_TITLE = "location title";
    private static final String LOCATION_SUBTITLE = "location subtitle";

    @Inject
    IPermissionHandler permissionHandler;
    @Inject
    IDialogFactory dialogFactory;

    @BindView(R.id.tv_location_title)
    TextView locationTitle;
    @BindView(R.id.tv_location_subtitle)
    TextView locationSubtitle;

    private IHomeHeaderContract.Presenter presenter;
    private LocationManager locationManager;

    public HomeHeaderFragment() {
    }

    @Override
    public void setPresenter(IHomeHeaderContract.Presenter presenter) {
        this.presenter = presenter;
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_home_header, container, false);
        BaseApplication.bind(this, view);
        return view;
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
        injectDependencies();

        if (savedInstanceState != null) {
            locationTitle.setText(savedInstanceState.getString(LOCATION_TITLE));
            locationSubtitle.setText(savedInstanceState.getString(LOCATION_SUBTITLE));
        }

        locationManager = (LocationManager) getActivity()
                .getSystemService(Context.LOCATION_SERVICE);
    }

    @Override
    public void onSaveInstanceState(Bundle outState) {
        outState.putString(LOCATION_TITLE, locationTitle.getText().toString());
        outState.putString(LOCATION_SUBTITLE, locationSubtitle.getText().toString());
        super.onSaveInstanceState(outState);
    }

    @Override
    public void onStart() {
        super.onStart();
        if (isNetworkAvailable()) {
            presenter.subscribe();
        }
    }

    @Override
    public void onStop() {
        super.onStop();
        presenter.unsubscribe();
    }

    @Override
    public void onResume() {
        super.onResume();
        if (isNetworkAvailable()) {
            presenter.subscribe();
        }
    }

    @Override
    public void onPause() {
        super.onPause();
        presenter.unsubscribe();
    }

    @Override
    public void setTitle(String title) {
        locationTitle.setText(title);
    }

    @Override
    public void setSubtitle(String subtitle) {
        locationSubtitle.setText(subtitle);
    }

    public void updateLocation() {
        if (isNetworkAvailable()) {
            presenter.update();
        }
    }

    @Override
    public boolean checkPermissions() {
        return permissionHandler.checkPermissions(
                Manifest.permission.INTERNET,
                Manifest.permission.ACCESS_FINE_LOCATION);
    }

    @Override
    public void requestPermissions() {
        permissionHandler.requestPermissions(
                Manifest.permission.INTERNET,
                Manifest.permission.ACCESS_FINE_LOCATION);
    }

    @Override
    public void showEnableLocationDialog() {
        if (!locationManager.isProviderEnabled(LocationManager.GPS_PROVIDER)) {
            dialogFactory
                    .createDialog()
                    .cancelable(true)
                    .withTitle(R.string.enable_location_dialog_title)
                    .withPositiveButton(R.string.enable_location_dialog_positive, new IDialog.OnOptionButtonClick() {
                        @Override
                        public void onClick() {
                            startActivity(new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS));
                        }
                    })
                    .withNegativeButton(R.string.enable_location_dialog_negative, null)
                    .withIcon(R.drawable.ic_location_gps)
                    .show();
        }
    }

    private boolean isNetworkAvailable() {
        ConnectivityManager connectivityManager = (ConnectivityManager)
                getActivity().getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();
        return activeNetworkInfo != null;
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
