package com.telerikacademy.meetup.provider.base;

import android.support.annotation.DrawableRes;
import android.support.v7.widget.DividerItemDecoration;

public interface IDecorationFactory {

    DividerItemDecoration createDividerDecoration(int orientation);

    DividerItemDecoration createDividerDecoration(int orientation, @DrawableRes int drawableRes);
}
