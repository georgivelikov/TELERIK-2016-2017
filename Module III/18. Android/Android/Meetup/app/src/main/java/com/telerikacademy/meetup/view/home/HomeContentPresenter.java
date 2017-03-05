package com.telerikacademy.meetup.view.home;

import com.telerikacademy.meetup.view.home.base.IHomeContentContract;

public class HomeContentPresenter implements IHomeContentContract.Presenter {

    private IHomeContentContract.View view;

    @Override
    public void setView(IHomeContentContract.View view) {
        this.view = view;
    }
}
