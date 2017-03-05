package com.telerikacademy.meetup.provider;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import com.telerikacademy.meetup.config.di.annotation.ActivityContext;
import com.telerikacademy.meetup.provider.base.IIntentFactory;

import javax.inject.Inject;

public class IntentFactory implements IIntentFactory {

    private final Context context;

    @Inject
    public IntentFactory(@ActivityContext Context context) {
        this.context = context;
    }

    @Override
    public Intent createIntentToFront(Class<? extends Activity> cls) {
        Intent intent = new Intent(context, cls);
        intent.addFlags(Intent.FLAG_ACTIVITY_REORDER_TO_FRONT);
        return intent;
    }
}
