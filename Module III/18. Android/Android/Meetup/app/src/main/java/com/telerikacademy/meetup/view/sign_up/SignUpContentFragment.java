package com.telerikacademy.meetup.view.sign_up;

import android.content.Intent;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Toast;
import butterknife.BindView;
import butterknife.OnClick;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.provider.base.IIntentFactory;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialog;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialogFactory;
import com.telerikacademy.meetup.view.sign_in.SignInActivity;
import com.telerikacademy.meetup.view.sign_up.base.ISignUpContract;

import javax.inject.Inject;

public class SignUpContentFragment extends Fragment
        implements ISignUpContract.View {

    @Inject
    IIntentFactory intentFactory;
    @Inject
    IDialogFactory dialogFactory;

    @BindView(R.id.username)
    EditText usernameEditText;
    @BindView(R.id.password)
    EditText passwordEditText;

    private ISignUpContract.Presenter presenter;
    private IDialog progressDialog;

    public SignUpContentFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_sign_up_content, container, false);
        BaseApplication.bind(this, view);
        return view;
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        injectDependencies();

        progressDialog = dialogFactory
                .createDialog()
                .withContent(R.string.dialog_loading_content)
                .withProgress();
    }

    @Override
    public void setPresenter(ISignUpContract.Presenter presenter) {
        this.presenter = presenter;
    }

    @Override
    public void setUsernameError() {
        usernameEditText.setError(this.getString(R.string.invalid_username));
    }

    @Override
    public void setPasswordError() {
        passwordEditText.setError(this.getString(R.string.invalid_password));
    }

    @Override
    public void notifySuccessful() {
        Toast.makeText(getContext(), getString(R.string.sign_up_successfull), Toast.LENGTH_LONG)
                .show();
    }

    @Override
    public void notifyError(String errorMessage) {
        Toast.makeText(getContext(), errorMessage, Toast.LENGTH_LONG)
                .show();
    }

    @Override
    @OnClick(R.id.link_signin)
    public void redirectToSignIn() {
        Intent signInIntent = intentFactory.createIntentToFront(SignInActivity.class);
        startActivity(signInIntent);
    }

    @Override
    public void startLoading() {
        progressDialog.show();
    }

    @Override
    public void stopLoading() {
        progressDialog.hide();
    }

    @OnClick(R.id.btn_sign_up)
    void signUp() {
        String username = usernameEditText.getText().toString();
        String password = passwordEditText.getText().toString();
        presenter.signUp(username, password);
    }

    private void injectDependencies() {
        BaseApplication
                .from(getActivity())
                .getComponent()
                .getControllerComponent(new ControllerModule(
                        getActivity(), getFragmentManager()
                ))
                .inject(this);
    }
}
