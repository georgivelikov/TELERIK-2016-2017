package com.telerikacademy.meetup.view.sign_up;

import android.os.Bundle;
import android.support.v4.app.FragmentManager;
import android.support.v7.app.AppCompatActivity;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.view.sign_up.base.ISignUpContract;

import javax.inject.Inject;

public class SignUpActivity extends AppCompatActivity {

    @Inject
    FragmentManager fragmentManager;
    @Inject
    ISignUpContract.Presenter presenter;

    private SignUpContentFragment contentFragment;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_up);
        injectDependencies();

        contentFragment = (SignUpContentFragment) fragmentManager
                .findFragmentById(R.id.fragment_sign_up_content);
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
