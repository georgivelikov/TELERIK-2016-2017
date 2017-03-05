package com.telerikacademy.meetup.util;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import com.telerikacademy.meetup.util.base.IImageUtil;

import java.io.ByteArrayOutputStream;
import java.io.IOException;

public class ImageUtil implements IImageUtil {

    @Override
    public byte[] parseToByteArray(Bitmap picture) {
        ByteArrayOutputStream stream = new ByteArrayOutputStream();
        picture.compress(Bitmap.CompressFormat.PNG, 100, stream);
        byte[] byteArray = stream.toByteArray();

        try {
            stream.close();
        } catch (IOException e) {
            e.printStackTrace();
        }

        return byteArray;
    }

    @Override
    public Bitmap parseToBitmap(byte[] array) {
        Bitmap picture = BitmapFactory.decodeByteArray(array, 0, array.length);
        return picture;
    }

    @Override
    public Bitmap parseToBitmap(byte[] array, BitmapFactory.Options bitmapOptions) {
        Bitmap picture = BitmapFactory.decodeByteArray(array, 0, array.length, bitmapOptions);
        return picture;
    }
}
