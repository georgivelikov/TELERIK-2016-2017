package com.telerikacademy.meetup.view.favorite_venues;

import com.telerikacademy.meetup.model.base.IVenueShort;
import com.telerikacademy.meetup.network.remote.base.IUserData;
import com.telerikacademy.meetup.util.base.IUserSession;
import com.telerikacademy.meetup.view.favorite_venues.base.IFavoriteVenuesContract;
import io.reactivex.SingleObserver;
import io.reactivex.android.schedulers.AndroidSchedulers;
import io.reactivex.disposables.Disposable;
import io.reactivex.schedulers.Schedulers;

import java.util.List;

public class FavoriteVenuesPresenter implements IFavoriteVenuesContract.Presenter {

    private final IUserData userData;
    private final IUserSession userSession;

    private IFavoriteVenuesContract.View view;

    public FavoriteVenuesPresenter(IUserData userData, IUserSession userSession) {
        this.userData = userData;
        this.userSession = userSession;
    }

    @Override
    public void setView(IFavoriteVenuesContract.View view) {
        this.view = view;
    }

    @Override
    public void loadData() {
        userData
                .getSavedVenues(userSession.getUsername())
                .subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(new SingleObserver<List<? extends IVenueShort>>() {
                    @Override
                    public void onSubscribe(Disposable d) {
                        view.startLoading();
                    }

                    @Override
                    public void onSuccess(List<? extends IVenueShort> value) {
                        view.setVenues(value);
                        view.stopLoading();
                    }

                    @Override
                    public void onError(Throwable e) {
                        view.stopLoading();
                    }
                });
    }
}
