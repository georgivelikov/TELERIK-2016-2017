package com.telerikacademy.meetup.ui.component.navigation_drawer.base;

import android.support.annotation.NonNull;
import android.support.v7.widget.Toolbar;
import android.view.View;

import java.util.List;

public interface IDrawer {

    IDrawer withDrawerItems(@NonNull IDrawerItem... drawerItems);

    IDrawer withDrawerItems(@NonNull List<IDrawerItem> drawerItems);

    IDrawer withSelectedItem(long identifier);

    IDrawer withStickyFooterItems(@NonNull IDrawerItem... drawerItems);

    IDrawer withStickyFooterItems(@NonNull List<IDrawerItem> drawerItems);

    IDrawer withDrawerWidth(int drawerWidth);

    IDrawer withToolbar(@NonNull Toolbar toolbar);

    IDrawer withActionBarDrawerToggleAnimated(boolean hasAnimation);

    IDrawer withTranslucentStatusBar(boolean isTranslucent);

    IDrawer withOnDrawerItemClickListener(OnDrawerItemClickListener onDrawerItemClickListener);

    void build();

    interface OnDrawerItemClickListener {

        boolean onClick(View view, int position);
    }
}
