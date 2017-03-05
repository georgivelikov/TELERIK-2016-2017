package com.telerikacademy.meetup.view.review.base;

import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.view.base.BasePresenter;
import com.telerikacademy.meetup.view.base.BaseView;


public interface IReviewContract {
    interface View extends BaseView<IReviewContract.Presenter> {

        void returnToVenueDetails();

        void startLoading();

        void stopLoading();

        void notifyError(String errorMessage);

        void notifySuccessfull(String successMsg);

        void onSubmitButtonClick();
    }

    interface Presenter extends BasePresenter<IReviewContract.View> {

        void submitComment(CharSequence comment);

        void setVenue(IVenue venue);
    }
}
