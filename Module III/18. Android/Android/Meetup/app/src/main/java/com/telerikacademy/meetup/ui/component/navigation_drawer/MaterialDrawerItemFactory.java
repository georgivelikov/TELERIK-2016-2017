package com.telerikacademy.meetup.ui.component.navigation_drawer;

import android.content.Context;
import com.telerikacademy.meetup.config.di.annotation.ApplicationContext;
import com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawerItem;
import com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawerItemFactory;

import javax.inject.Inject;

public class MaterialDrawerItemFactory implements IDrawerItemFactory {

    private final Context context;

    @Inject
    public MaterialDrawerItemFactory(@ApplicationContext Context context) {
        this.context = context;
    }

    @Override
    public IDrawerItem createPrimaryDrawerItem() {
        return new PrimaryDrawerItem(context);
    }

    @Override
    public IDrawerItem createSecondaryDrawerItem() {
        return new SecondaryDrawerItem(context);
    }

    @Override
    public IDrawerItem createDividerDrawerItem() {
        return new DividerDrawerItem(context);
    }
}
