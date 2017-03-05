package com.telerikacademy.meetup.view.base;

public interface BaseView<T extends BasePresenter> {

    void setPresenter(T presenter);
}
