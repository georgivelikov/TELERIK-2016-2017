package com.telerikacademy.meetup.ui.component.navigation_drawer.base;

public interface IDrawerItemFactory {

    IDrawerItem createPrimaryDrawerItem();

    IDrawerItem createSecondaryDrawerItem();

    IDrawerItem createDividerDrawerItem();
}
