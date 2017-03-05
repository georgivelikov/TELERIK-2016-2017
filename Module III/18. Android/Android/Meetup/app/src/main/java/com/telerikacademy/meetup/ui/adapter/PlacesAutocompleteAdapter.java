package com.telerikacademy.meetup.ui.adapter;

import android.content.Context;
import android.location.Address;
import android.location.Geocoder;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Filter;
import android.widget.Filterable;
import android.widget.TextView;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public class PlacesAutocompleteAdapter extends ArrayAdapter<Address> implements Filterable {

    private LayoutInflater mInflater;
    private Geocoder mGeocoder;
    private StringBuilder mSb = new StringBuilder();

    public PlacesAutocompleteAdapter(final Context context) {
        super(context, -1);
        mInflater = LayoutInflater.from(context);
        mGeocoder = new Geocoder(context);
    }

    @Override
    public View getView(final int position, final View convertView, final ViewGroup parent) {
        final TextView tv;
        if (convertView != null) {
            tv = (TextView) convertView;
        } else {
            tv = (TextView) mInflater.inflate(android.R.layout.simple_dropdown_item_1line, parent, false);
        }

        tv.setText(createFormattedAddressFromAddress(getItem(position)));
        return tv;
    }

    private String createFormattedAddressFromAddress(final Address address) {
        mSb.setLength(0);
        final int addressLineSize = address.getMaxAddressLineIndex();
        for (int i = 0; i < addressLineSize; i++) {
            mSb.append(address.getAddressLine(i));
            if (i != addressLineSize - 1) {
                mSb.append(", ");
            }
        }
        return mSb.toString();
    }

    @Override
    public Filter getFilter() {
        Filter myFilter = new Filter() {
            @Override
            protected Filter.FilterResults performFiltering(final CharSequence constraint) {
                List<Address> addressList = null;
                if (constraint != null) {
                    try {
                        addressList = mGeocoder.getFromLocationName((String) constraint, 5);
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }
                if (addressList == null) {
                    addressList = new ArrayList<>();
                }

                final FilterResults filterResults = new FilterResults();
                filterResults.values = addressList;
                filterResults.count = addressList.size();

                return filterResults;
            }

            @SuppressWarnings("unchecked")
            @Override
            protected void publishResults(final CharSequence contraint, final FilterResults results) {
                clear();
                for (Address address : (List<Address>) results.values) {
                    add(address);
                }
                if (results.count > 0) {
                    notifyDataSetChanged();
                } else {
                    notifyDataSetInvalidated();
                }
            }

            @Override
            public CharSequence convertResultToString(final Object resultValue) {
                return resultValue == null ? "" : ((Address) resultValue).getAddressLine(0);
            }
        };

        return myFilter;
    }
}
