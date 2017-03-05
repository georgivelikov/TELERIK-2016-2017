package com.telerikacademy.meetup.util.base;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;

public interface IImageUtil {

    byte[] parseToByteArray(Bitmap picture);

    Bitmap parseToBitmap(byte[] array);

    Bitmap parseToBitmap(byte[] array, BitmapFactory.Options bitmapOptions);
}
