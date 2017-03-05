package com.telerikacademy.meetup.view.sign_in;

import com.telerikacademy.meetup.model.base.IUser;
import com.telerikacademy.meetup.network.remote.base.IUserData;
import com.telerikacademy.meetup.util.base.IValidator;
import com.telerikacademy.meetup.view.sign_in.base.ISignInContract;
import io.reactivex.Observer;
import io.reactivex.android.schedulers.AndroidSchedulers;
import io.reactivex.disposables.Disposable;
import io.reactivex.schedulers.Schedulers;

import javax.inject.Inject;

public class SignInPresenter implements ISignInContract.Presenter {

    private final IUserData userData;
    private final IValidator validator;

    private ISignInContract.View view;

    @Inject
    public SignInPresenter(IUserData userData, IValidator validator) {
        this.userData = userData;
        this.validator = validator;
    }

    @Override
    public void setView(ISignInContract.View view) {
        this.view = view;
    }

    @Override
    public void signIn(String username, String password) {
        if (!validator.isUsernameValid(username)) {
            view.setUsernameError();
            return;
        }

        if (!validator.isPasswordValid(password)) {
            view.setPasswordError();
            return;
        }

        userData.signIn(username, password)
                .subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(new Observer<IUser>() {
                    @Override
                    public void onSubscribe(Disposable d) {
                        view.startLoading();
                    }

                    @Override
                    public void onNext(IUser value) {
                        view.notifySuccessful();
                        view.redirectToHome();
                    }

                    @Override
                    public void onError(Throwable e) {
                        view.notifyError(e.getMessage());
                        view.stopLoading();
                    }

                    @Override
                    public void onComplete() {
                        view.stopLoading();
                    }
                });
    }
}
