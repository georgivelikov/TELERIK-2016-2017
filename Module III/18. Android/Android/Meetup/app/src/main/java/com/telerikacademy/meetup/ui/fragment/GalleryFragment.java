package com.telerikacademy.meetup.ui.fragment;

import android.graphics.Bitmap;
import android.os.Bundle;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v4.view.ViewPager;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import butterknife.BindView;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.ui.adapter.GalleryAdapter;
import com.telerikacademy.meetup.ui.fragment.base.IGallery;

public class GalleryFragment extends Fragment
        implements IGallery {

    @BindView(R.id.vp_gallery)
    ViewPager viewPager;
    @BindView(R.id.gallery_indicator)
    TabLayout galleryIndicator;

    private GalleryAdapter galleryAdapter;

    public GalleryFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_gallery, container, false);
        BaseApplication.bind(this, view);

        galleryAdapter = new GalleryAdapter(view.getContext());
        viewPager.setAdapter(galleryAdapter);
        galleryIndicator.setupWithViewPager(viewPager, true);

        return view;
    }

    @Override
    public void addPhoto(Bitmap photo) {
        galleryAdapter.addPhoto(photo);
    }

    @Override
    public void removePhoto(Bitmap photo) {
        galleryAdapter.removePhoto(photo);
    }
}
