package com.telerikacademy.meetup.ui.fragment.base;

import android.graphics.Bitmap;

public interface IGallery {

    void addPhoto(Bitmap photo);

    void removePhoto(Bitmap photo);
}
