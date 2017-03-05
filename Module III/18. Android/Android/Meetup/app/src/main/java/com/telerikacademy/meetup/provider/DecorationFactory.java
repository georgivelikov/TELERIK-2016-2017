package com.telerikacademy.meetup.provider;

import android.content.Context;
import android.support.annotation.DrawableRes;
import android.support.v7.widget.DividerItemDecoration;
import com.telerikacademy.meetup.config.di.annotation.ApplicationContext;
import com.telerikacademy.meetup.provider.base.IDecorationFactory;

import javax.inject.Inject;

public class DecorationFactory implements IDecorationFactory {

    private final Context context;

    @Inject
    public DecorationFactory(@ApplicationContext Context context) {
        this.context = context;
    }

    @Override
    public DividerItemDecoration createDividerDecoration(int orientation) {
        return new DividerItemDecoration(context, orientation);
    }

    @Override
    public DividerItemDecoration createDividerDecoration(int orientation, @DrawableRes int drawableRes) {
        DividerItemDecoration dividerItemDecoration = new DividerItemDecoration(context, orientation);
        dividerItemDecoration.setDrawable(context.getDrawable(drawableRes));
        return dividerItemDecoration;
    }
}
