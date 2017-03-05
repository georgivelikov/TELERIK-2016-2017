package com.telerikacademy.meetup.view.review;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.Toast;
import butterknife.BindView;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.provider.base.IIntentFactory;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialog;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialogFactory;
import com.telerikacademy.meetup.view.review.base.IReviewContract;

import javax.inject.Inject;

public class ReviewContentFragment extends Fragment implements IReviewContract.View {

    @Inject
    IIntentFactory intentFactory;
    @Inject
    IDialogFactory dialogFactory;

    @BindView(R.id.et_review_comment_holder)
    EditText commentEditText;

    private IReviewContract.Presenter presenter;
    private IDialog progressDialog;

    public ReviewContentFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_review_content, container, false);
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
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
        injectDependencies();
    }

    @Override
    public void setPresenter(IReviewContract.Presenter presenter) {
        this.presenter = presenter;
    }

    @Override
    public void notifySuccessfull(String successMsg) {
        if (getContext() != null) {
            Toast.makeText(getContext(), successMsg, Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void notifyError(String errorMessage) {
        if (getContext() != null) {
            Toast.makeText(getContext(), errorMessage, Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void returnToVenueDetails() {
        getActivity().onBackPressed();
    }

    @Override
    public void startLoading() {
        progressDialog.show();
    }

    @Override
    public void stopLoading() {
        progressDialog.hide();
    }

    @Override
    public void onSubmitButtonClick() {
        CharSequence comment = commentEditText.getText();
        commentEditText.setText("");
        presenter.submitComment(comment);
    }

    private void injectDependencies() {
        BaseApplication
                .from(getContext())
                .getComponent()
                .getControllerComponent(new ControllerModule(
                        getActivity(), getFragmentManager()
                ))
                .inject(this);
    }
}
