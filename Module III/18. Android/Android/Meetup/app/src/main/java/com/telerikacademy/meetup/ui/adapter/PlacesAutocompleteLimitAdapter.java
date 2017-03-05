package com.telerikacademy.meetup.ui.adapter;

import android.content.Context;
import android.support.annotation.LayoutRes;
import android.support.annotation.NonNull;
import android.widget.ArrayAdapter;

import java.util.List;

public class PlacesAutocompleteLimitAdapter<T> extends ArrayAdapter<T> {

    private static final int LIMIT = 5;

    public PlacesAutocompleteLimitAdapter(@NonNull Context context,
                                          @LayoutRes int resource,
                                          @NonNull List<T> objects) {

        super(context, resource, objects);
    }

    @Override
    public int getCount() {
        return Math.min(LIMIT, super.getCount());
    }
}
