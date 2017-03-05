package com.telerikacademy.meetup.view.nearby_venues.base;

import android.support.v7.widget.RecyclerView;
import com.telerikacademy.meetup.view.base.BasePresenter;
import com.telerikacademy.meetup.view.base.BaseView;

public interface INearbyVenuesContract {

    interface View extends BaseView<Presenter> {

        void setAdapter(RecyclerView.Adapter adapter);
    }

    interface Presenter extends BasePresenter<View> {
    }
}
