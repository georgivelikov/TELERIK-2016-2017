package com.telerikacademy.meetup.view.favorite_venues;

import android.os.Bundle;
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
import com.telerikacademy.meetup.model.base.IVenueShort;
import com.telerikacademy.meetup.provider.base.IDecorationFactory;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialog;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialogFactory;
import com.telerikacademy.meetup.view.favorite_venues.base.IFavoriteVenuesContract;

import javax.inject.Inject;
import java.util.ArrayList;
import java.util.List;

public class FavoriteVenuesContentFragment extends Fragment
        implements IFavoriteVenuesContract.View {

    @Inject
    @VerticalLayoutManager
    LinearLayoutManager layoutManager;
    @Inject
    IDialogFactory dialogFactory;
    @Inject
    IDecorationFactory decorationFactory;

    @BindView(R.id.rv_favorite_venues_content)
    RecyclerView favoriteItemsRecyclerView;

    private IFavoriteVenuesContract.Presenter presenter;
    private FavoriteVenuesAdapter favoriteItemsAdapter;
    private IDialog progressDialog;

    public FavoriteVenuesContentFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_favorite_venues_content, container, false);
        BaseApplication.bind(this, view);
        return view;
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
        injectDependencies();
        initialize();
        presenter.loadData();
    }

    @Override
    public void setPresenter(IFavoriteVenuesContract.Presenter presenter) {
        this.presenter = presenter;
    }

    @Override
    public void setVenues(List<? extends IVenueShort> venues) {
        favoriteItemsAdapter.swap(venues);
    }

    @Override
    public void startLoading() {
        progressDialog.show();
    }

    @Override
    public void stopLoading() {
        progressDialog.hide();
    }

    private void initialize() {
        progressDialog = dialogFactory
                .createDialog()
                .withContent(R.string.dialog_loading_content)
                .withProgress();

        DividerItemDecoration dividerDecoration = decorationFactory
                .createDividerDecoration(layoutManager.getOrientation(), R.drawable.horizontal_divider);
        favoriteItemsAdapter = new FavoriteVenuesAdapter(new ArrayList<IVenueShort>());
        favoriteItemsRecyclerView.addItemDecoration(dividerDecoration);
        favoriteItemsRecyclerView.setLayoutManager(layoutManager);
        favoriteItemsRecyclerView.setAdapter(favoriteItemsAdapter);
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
