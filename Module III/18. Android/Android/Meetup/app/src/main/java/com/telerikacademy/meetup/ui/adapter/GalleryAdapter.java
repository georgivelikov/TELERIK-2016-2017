package com.telerikacademy.meetup.ui.adapter;

import android.content.Context;
import android.graphics.Bitmap;
import android.support.v4.view.PagerAdapter;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;

import javax.inject.Inject;
import java.util.ArrayList;
import java.util.List;

public class GalleryAdapter extends PagerAdapter {

    private Context context;
    private List<Bitmap> photos;

    @Inject
    public GalleryAdapter(Context context) {
        this.context = context;
        this.photos = new ArrayList<>();
    }

    @Override
    public int getCount() {
        return photos.size();
    }

    @Override
    public boolean isViewFromObject(View view, Object object) {
        return view == object;
    }

    @Override
    public Object instantiateItem(ViewGroup container, int position) {
        ImageView imageView = new ImageView(context);

        imageView.setScaleType(ImageView.ScaleType.CENTER_CROP);
        imageView.setImageBitmap(photos.get(position));

        container.addView(imageView);
        return imageView;
    }

    @Override
    public void destroyItem(ViewGroup container, int position, Object object) {
        container.removeView((View) object);
    }

    public void addPhoto(Bitmap photo) {
        photos.add(photo);
        notifyDataSetChanged();
    }

    public void removePhoto(Bitmap photo) {
        photos.remove(photo);
        notifyDataSetChanged();
    }
}
