package com.telerikacademy.meetup.ui.component.dialog;

import android.app.Activity;
import android.graphics.drawable.Drawable;
import android.support.annotation.DrawableRes;
import android.support.annotation.NonNull;
import android.support.annotation.StringRes;
import com.afollestad.materialdialogs.DialogAction;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialog;

import javax.inject.Inject;

public class MaterialDialog implements IDialog {

    private final com.afollestad.materialdialogs.MaterialDialog.Builder dialogBuilder;
    private com.afollestad.materialdialogs.MaterialDialog dialog;

    @Inject
    public MaterialDialog(@NonNull Activity activity) {
        dialogBuilder = new com.afollestad.materialdialogs.MaterialDialog.Builder(activity);
        dialogBuilder.cancelable(false);
    }

    @Override
    public IDialog withTitle(@NonNull CharSequence title) {
        dialogBuilder.title(title);
        return this;
    }

    @Override
    public IDialog withTitle(@StringRes int title) {
        dialogBuilder.title(title);
        return this;
    }

    @Override
    public IDialog withContent(@NonNull CharSequence content) {
        dialogBuilder.content(content);
        return this;
    }

    @Override
    public IDialog withContent(@StringRes int content) {
        dialogBuilder.content(content);
        return this;
    }

    @Override
    public IDialog withIcon(@NonNull Drawable icon) {
        dialogBuilder.icon(icon);
        return this;
    }

    @Override
    public IDialog withIcon(@DrawableRes int icon) {
        dialogBuilder.iconRes(icon);
        return this;
    }

    @Override
    public IDialog withProgress() {
        dialogBuilder.progress(true, 0);
        return this;
    }

    @Override
    public IDialog cancelable(boolean isCancelable) {
        dialogBuilder.cancelable(isCancelable);
        return this;
    }

    @Override
    public IDialog withPositiveButton(@StringRes int text,
                                      final OnOptionButtonClick onPositiveListener) {

        dialogBuilder.positiveText(text);
        if (onPositiveListener != null) {
            dialogBuilder.onPositive(new com.afollestad.materialdialogs.MaterialDialog.SingleButtonCallback() {
                @Override
                public void onClick(@NonNull com.afollestad.materialdialogs.MaterialDialog dialog, @NonNull DialogAction which) {
                    onPositiveListener.onClick();
                }
            });
        }

        return this;
    }

    @Override
    public IDialog withPositiveButton(@NonNull CharSequence text,
                                      final OnOptionButtonClick onPositiveListener) {

        dialogBuilder.positiveText(text);
        if (onPositiveListener != null) {
            dialogBuilder.onPositive(new com.afollestad.materialdialogs.MaterialDialog.SingleButtonCallback() {
                @Override
                public void onClick(@NonNull com.afollestad.materialdialogs.MaterialDialog dialog, @NonNull DialogAction which) {
                    onPositiveListener.onClick();
                }
            });
        }

        return this;
    }

    @Override
    public IDialog withNeutralButton(@StringRes int text,
                                     final OnOptionButtonClick onNeutralListener) {

        dialogBuilder.neutralText(text);
        if (onNeutralListener != null) {
            dialogBuilder.onNeutral(new com.afollestad.materialdialogs.MaterialDialog.SingleButtonCallback() {
                @Override
                public void onClick(@NonNull com.afollestad.materialdialogs.MaterialDialog dialog, @NonNull DialogAction which) {
                    onNeutralListener.onClick();
                }
            });
        }

        return this;
    }

    @Override
    public IDialog withNeutralButton(@NonNull CharSequence text,
                                     final OnOptionButtonClick onNeutralListener) {

        dialogBuilder.neutralText(text);
        if (onNeutralListener != null) {
            dialogBuilder.onNeutral(new com.afollestad.materialdialogs.MaterialDialog.SingleButtonCallback() {
                @Override
                public void onClick(@NonNull com.afollestad.materialdialogs.MaterialDialog dialog, @NonNull DialogAction which) {
                    onNeutralListener.onClick();
                }
            });
        }

        return this;
    }

    @Override
    public IDialog withNegativeButton(@StringRes int text,
                                      final OnOptionButtonClick onNegativeListener) {

        dialogBuilder.negativeText(text);
        if (onNegativeListener != null) {
            dialogBuilder.onNegative(new com.afollestad.materialdialogs.MaterialDialog.SingleButtonCallback() {
                @Override
                public void onClick(@NonNull com.afollestad.materialdialogs.MaterialDialog dialog, @NonNull DialogAction which) {
                    onNegativeListener.onClick();
                }
            });
        }

        return this;
    }

    @Override
    public IDialog withNegativeButton(@NonNull CharSequence text,
                                      final OnOptionButtonClick onNegativeListener) {

        dialogBuilder.negativeText(text);
        if (onNegativeListener != null) {
            dialogBuilder.onNegative(new com.afollestad.materialdialogs.MaterialDialog.SingleButtonCallback() {
                @Override
                public void onClick(@NonNull com.afollestad.materialdialogs.MaterialDialog dialog, @NonNull DialogAction which) {
                    onNegativeListener.onClick();
                }
            });
        }

        return this;
    }

    @Override
    public void show() {
        dialog = dialogBuilder.show();
    }

    @Override
    public void hide() {
        if (dialog != null) {
            dialog.dismiss();
        }
    }
}
