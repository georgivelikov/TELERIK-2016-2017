package com.telerikacademy.meetup.ui.component.navigation_drawer.base;

import android.content.Context;
import android.graphics.drawable.Drawable;
import android.support.annotation.DrawableRes;
import android.support.annotation.NonNull;
import android.support.annotation.StringRes;
import com.mikepenz.iconics.typeface.IIcon;

import java.lang.reflect.Type;

public interface IDrawerItem {

    Context getContext();

    Type getDrawerItemType();

    DrawerItem withIdentifier(long identifier);

    DrawerItem withName(@NonNull String name);

    DrawerItem withName(@StringRes int nameRes);

    DrawerItem withIcon(@NonNull Drawable icon);

    DrawerItem withIcon(@DrawableRes int iconRes);

    DrawerItem withIcon(@NonNull IIcon icon);

    long getIdentifier();

    String getName();

    Drawable getIcon();

    IIcon getIicon();
}
