package com.telerikacademy.meetup.view.nearby_venues;

import android.os.Bundle;
import android.os.Parcelable;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v7.widget.DividerItemDecoration;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import butterknife.BindView;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.annotation.VerticalLayoutManager;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.provider.base.IDecorationFactory;
import com.telerikacademy.meetup.view.nearby_venues.base.INearbyVenuesContract;

import javax.inject.Inject;

public class NearbyVenuesContentFragment extends Fragment
        implements INearbyVenuesContract.View {

    private static final String BUNDLE_RECYCLER_LAYOUT =
            NearbyVenuesContentFragment.class.getCanonicalName() + ".RECYCLER_LAYOUT";

    @Inject
    @VerticalLayoutManager
    LinearLayoutManager layoutManager;
    @Inject
    IDecorationFactory decorationFactory;

    @BindView(R.id.rv_nearby_venues)
    RecyclerView recyclerView;

    private INearbyVenuesContract.Presenter presenter;

    public NearbyVenuesContentFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_nearby_venues_content, container, false);
        BaseApplication.bind(this, view);
        return view;
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
        injectDependencies();

        DividerItemDecoration dividerDecoration = decorationFactory
                .createDividerDecoration(layoutManager.getOrientation(), R.drawable.horizontal_divider);
        recyclerView.addItemDecoration(dividerDecoration);
        recyclerView.setLayoutManager(layoutManager);
    }

    @Override
    public void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        outState.putParcelable(BUNDLE_RECYCLER_LAYOUT, recyclerView.getLayoutManager().onSaveInstanceState());
    }

    @Override
    public void onViewStateRestored(@Nullable Bundle savedInstanceState) {
        super.onViewStateRestored(savedInstanceState);

        if (savedInstanceState != null) {
            Parcelable savedRecyclerLayoutState = savedInstanceState.getParcelable(BUNDLE_RECYCLER_LAYOUT);
            recyclerView.getLayoutManager().onRestoreInstanceState(savedRecyclerLayoutState);
        }
    }

    @Override
    public void setPresenter(INearbyVenuesContract.Presenter presenter) {
        this.presenter = presenter;
    }

    @Override
    public void setAdapter(RecyclerView.Adapter adapter) {
        recyclerView.setAdapter(adapter);
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
