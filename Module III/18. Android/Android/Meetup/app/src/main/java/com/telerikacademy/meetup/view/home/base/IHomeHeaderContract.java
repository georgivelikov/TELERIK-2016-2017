package com.telerikacademy.meetup.view.home.base;

import com.telerikacademy.meetup.provider.base.ILocationAware;
import com.telerikacademy.meetup.view.base.BasePresenter;
import com.telerikacademy.meetup.view.base.BaseView;

public interface IHomeHeaderContract {

    interface View extends BaseView<Presenter> {

        void setTitle(String title);

        void setSubtitle(String subtitle);

        boolean checkPermissions();

        void requestPermissions();

        void showEnableLocationDialog();
    }

    interface Presenter extends BasePresenter<View>, ILocationAware {

        void subscribe();

        void unsubscribe();

        void update();
    }
}
