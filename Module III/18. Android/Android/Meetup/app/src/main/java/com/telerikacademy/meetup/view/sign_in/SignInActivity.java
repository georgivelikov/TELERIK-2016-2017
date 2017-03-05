package com.telerikacademy.meetup.view.sign_in;

import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.view.sign_in.base.ISignInContract;

import javax.inject.Inject;

public class SignInActivity extends AppCompatActivity {

    @Inject
    ISignInContract.Presenter presenter;
    @Inject
    FragmentManager fragmentManager;

    private SignInContentFragment contentFragment;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_in);
        injectDependencies();

        contentFragment = (SignInContentFragment) fragmentManager
                .findFragmentById(R.id.fragment_sign_in_content);
        contentFragment.setPresenter(presenter);
        presenter.setView(contentFragment);
    }

    private void injectDependencies() {
        BaseApplication
                .from(this)
                .getComponent()
                .getControllerComponent(new ControllerModule(
                        this, getSupportFragmentManager()
                ))
                .inject(this);
    }
}
