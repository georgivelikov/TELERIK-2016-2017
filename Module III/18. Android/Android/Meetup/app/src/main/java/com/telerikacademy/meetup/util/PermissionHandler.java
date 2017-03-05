package com.telerikacademy.meetup.util;

import android.app.Activity;
import android.content.pm.PackageManager;
import android.support.annotation.NonNull;
import android.support.v4.app.ActivityCompat;
import android.support.v4.content.ContextCompat;
import com.telerikacademy.meetup.util.base.IPermissionHandler;

import javax.inject.Inject;

public class PermissionHandler implements IPermissionHandler {

    private final Activity activity;

    @Inject
    public PermissionHandler(Activity activity) {
        this.activity = activity;
    }

    public boolean checkPermissions(@NonNull String... permissions) {
        for (String permission : permissions) {
            int permissionRes = ContextCompat.checkSelfPermission(activity, permission);
            if (permissionRes != PackageManager.PERMISSION_GRANTED) {
                return false;
            }
        }

        return true;
    }

    public void requestPermissions(@NonNull String... permissions) {
        for (String permission : permissions) {
            int permissionRes = ContextCompat.checkSelfPermission(activity, permission);
            if (permissionRes != PackageManager.PERMISSION_GRANTED) {
                ActivityCompat.requestPermissions(activity, new String[]{permission}, 1);
            }
        }
    }
}
