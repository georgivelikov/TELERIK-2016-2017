package com.telerikacademy.meetup.provider.base;

import android.app.Activity;
import android.content.Intent;

public interface IIntentFactory {

    Intent createIntentToFront(Class<? extends Activity> cls);
}
