package com.telerikacademy.meetup.ui.component.dialog.base;

import android.graphics.drawable.Drawable;
import android.support.annotation.DrawableRes;
import android.support.annotation.NonNull;
import android.support.annotation.StringRes;

public interface IDialog {

    IDialog withTitle(@NonNull CharSequence title);

    IDialog withTitle(@StringRes int title);

    IDialog withContent(@NonNull CharSequence content);

    IDialog withContent(@StringRes int content);

    IDialog withIcon(@NonNull Drawable icon);

    IDialog withIcon(@DrawableRes int icon);

    IDialog withProgress();

    IDialog cancelable(boolean isCancelable);

    IDialog withPositiveButton(@StringRes int text, OnOptionButtonClick onPositiveListener);

    IDialog withPositiveButton(@NonNull CharSequence text, OnOptionButtonClick onPositiveListener);

    IDialog withNeutralButton(@StringRes int text, OnOptionButtonClick onNeutralListener);

    IDialog withNeutralButton(@NonNull CharSequence text, OnOptionButtonClick onNeutralListener);

    IDialog withNegativeButton(@StringRes int text, OnOptionButtonClick onNegativeListener);

    IDialog withNegativeButton(@NonNull CharSequence text, OnOptionButtonClick onNegativeListener);

    void show();

    void hide();

    interface OnOptionButtonClick {

        void onClick();
    }
}
