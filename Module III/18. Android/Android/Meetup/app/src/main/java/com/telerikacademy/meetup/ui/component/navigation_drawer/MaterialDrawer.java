package com.telerikacademy.meetup.ui.component.navigation_drawer;

import android.app.Activity;
import android.support.annotation.Dimension;
import android.support.annotation.NonNull;
import android.support.v7.widget.Toolbar;
import android.view.View;
import com.mikepenz.materialdrawer.DrawerBuilder;
import com.mikepenz.materialdrawer.model.AbstractBadgeableDrawerItem;
import com.mikepenz.materialdrawer.model.interfaces.IDrawerItem;
import com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawer;

import javax.inject.Inject;
import java.lang.reflect.Type;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class MaterialDrawer implements IDrawer {

    private final static int DP = 0;

    private DrawerBuilder drawerBuilder;

    @Inject
    public MaterialDrawer(Activity activity) {
        drawerBuilder = new DrawerBuilder(activity);
    }

    @Override
    public IDrawer withDrawerItems(
            @NonNull com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawerItem... drawerItems) {

        IDrawerItem[] parsedDrawerItems = parseDrawerItems(Arrays.asList(drawerItems));
        drawerBuilder.addDrawerItems(parsedDrawerItems);
        return this;
    }

    @Override
    public IDrawer withDrawerItems(
            @NonNull List<com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawerItem> drawerItems) {

        IDrawerItem[] parsedDrawerItems = parseDrawerItems(drawerItems);
        drawerBuilder.addDrawerItems(parsedDrawerItems);
        return this;
    }

    @Override
    public IDrawer withSelectedItem(long identifier) {
        drawerBuilder.withSelectedItem(identifier);
        return this;
    }

    @Override
    public IDrawer withStickyFooterItems(
            @NonNull com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawerItem... drawerItems) {

        IDrawerItem[] parsedDrawerItems = parseDrawerItems(Arrays.asList(drawerItems));
        drawerBuilder.addStickyDrawerItems(parsedDrawerItems);
        return this;
    }

    @Override
    public IDrawer withStickyFooterItems(
            @NonNull List<com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawerItem> drawerItems) {

        IDrawerItem[] parsedDrawerItems = parseDrawerItems(drawerItems);
        drawerBuilder.addStickyDrawerItems(parsedDrawerItems);
        return this;
    }

    @Override
    public IDrawer withDrawerWidth(@Dimension(unit = DP) int drawerWidth) {
        drawerBuilder.withDrawerWidthDp(drawerWidth);
        return this;
    }

    @Override
    public IDrawer withToolbar(@NonNull Toolbar toolbar) {
        drawerBuilder.withToolbar(toolbar);
        return this;
    }

    @Override
    public IDrawer withActionBarDrawerToggleAnimated(boolean hasAnimation) {
        drawerBuilder.withActionBarDrawerToggleAnimated(hasAnimation);
        return this;
    }

    @Override
    public IDrawer withTranslucentStatusBar(boolean isTranslucent) {
        drawerBuilder.withTranslucentStatusBar(isTranslucent);
        return this;
    }

    @Override
    public IDrawer withOnDrawerItemClickListener(final IDrawer.OnDrawerItemClickListener onDrawerItemClickListener) {
        drawerBuilder.withOnDrawerItemClickListener(new com.mikepenz.materialdrawer.Drawer.OnDrawerItemClickListener() {
            @Override
            public boolean onItemClick(View view, int position, IDrawerItem drawerItem) {
                return onDrawerItemClickListener.onClick(view, position);
            }
        });

        return this;
    }

    @Override
    public void build() {
        drawerBuilder.build();
    }

    private IDrawerItem parseDrawerItem(
            com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawerItem drawerItem) {

        Type drawerItemType = drawerItem.getDrawerItemType();

        IDrawerItem materialDrawerItem;
        AbstractBadgeableDrawerItem mainDrawerItem;

        if (drawerItemType == PrimaryDrawerItem.class) {
            mainDrawerItem = new com.mikepenz.materialdrawer.model.PrimaryDrawerItem();
        } else if (drawerItemType == SecondaryDrawerItem.class) {
            mainDrawerItem = new com.mikepenz.materialdrawer.model.SecondaryDrawerItem();
        } else if (drawerItemType == DividerDrawerItem.class) {
            materialDrawerItem = new com.mikepenz.materialdrawer.model.DividerDrawerItem()
                    .withIdentifier(drawerItem.getIdentifier());
            return materialDrawerItem;
        } else {
            throw new UnsupportedOperationException(drawerItemType.toString() + " not supported.");
        }

        mainDrawerItem.withIdentifier(drawerItem.getIdentifier());
        mainDrawerItem.withName(drawerItem.getName());

        if (drawerItem.getIicon() != null) {
            mainDrawerItem.withIcon(drawerItem.getIicon());
        } else {
            mainDrawerItem.withIcon(drawerItem.getIcon());
        }

        return mainDrawerItem;
    }

    private IDrawerItem[] parseDrawerItems(
            List<com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawerItem> drawerItems) {

        List<IDrawerItem> materialDrawerItems = new ArrayList<>();
        for (com.telerikacademy.meetup.ui.component.navigation_drawer.base.IDrawerItem drawerItem : drawerItems) {
            materialDrawerItems.add(parseDrawerItem(drawerItem));
        }

        return materialDrawerItems.toArray(new IDrawerItem[materialDrawerItems.size()]);
    }
}
