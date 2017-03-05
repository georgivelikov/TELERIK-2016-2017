package com.telerikacademy.meetup.view.favorite_venues.base;

import com.telerikacademy.meetup.model.base.IVenueShort;
import com.telerikacademy.meetup.view.base.BasePresenter;
import com.telerikacademy.meetup.view.base.BaseView;

import java.util.List;

public interface IFavoriteVenuesContract {

    interface View extends BaseView<Presenter> {

        void setVenues(List<? extends IVenueShort> venues);

        void startLoading();

        void stopLoading();
    }

    interface Presenter extends BasePresenter<View> {

        void loadData();
    }
}
