package com.telerikacademy.meetup.ui.component.dialog;

import android.app.Activity;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialog;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialogFactory;

import javax.inject.Inject;

public final class DialogFactory implements IDialogFactory {

    private Activity activity;

    @Inject
    public DialogFactory(Activity activity) {
        this.activity = activity;
    }

    @Override
    public IDialog createDialog() {
        return new MaterialDialog(activity);
    }
}
