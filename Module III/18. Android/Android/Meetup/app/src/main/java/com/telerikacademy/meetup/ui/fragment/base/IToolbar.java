package com.telerikacademy.meetup.ui.fragment.base;

import android.support.annotation.LayoutRes;
import android.support.annotation.MenuRes;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.View;

public interface IToolbar {

    void inflateMenu(@MenuRes int menuRes, Menu menu, MenuInflater menuInflater);

    void setBackButton();

    void setBackButton(View.OnClickListener onClickListener);

    // Might be extracted into a separate interface
    void setNavigationDrawer(@LayoutRes long selectedItem);
}
