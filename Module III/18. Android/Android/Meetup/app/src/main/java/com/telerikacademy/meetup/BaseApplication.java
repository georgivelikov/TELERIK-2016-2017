package com.telerikacademy.meetup;

import android.app.Activity;
import android.app.Application;
import android.content.Context;
import android.support.annotation.NonNull;
import android.view.View;
import butterknife.ButterKnife;
import com.telerikacademy.meetup.config.di.component.ApplicationComponent;
import com.telerikacademy.meetup.config.di.component.DaggerApplicationComponent;
import com.telerikacademy.meetup.config.di.module.ApplicationModule;

public class BaseApplication extends Application {

    private ApplicationComponent applicationComponent;

    @Override
    public void onCreate() {
        super.onCreate();

        applicationComponent = DaggerApplicationComponent
                .builder()
                .applicationModule(new ApplicationModule(this))
                .build();
    }

    public ApplicationComponent getComponent() {
        return applicationComponent;
    }

    public static BaseApplication from(@NonNull Context context) {
        return (BaseApplication) context.getApplicationContext();
    }

    public static BaseApplication bind(@NonNull Activity activity) {
        ButterKnife.bind(activity);
        return (BaseApplication) activity.getApplicationContext();
    }

    public static void bind(@NonNull Object object, @NonNull View source) {
        ButterKnife.bind(object, source);
    }
}
