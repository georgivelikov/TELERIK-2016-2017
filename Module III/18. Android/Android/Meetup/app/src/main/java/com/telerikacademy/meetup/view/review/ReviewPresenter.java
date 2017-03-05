package com.telerikacademy.meetup.view.review;

import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.network.remote.base.IVenueData;
import com.telerikacademy.meetup.view.review.base.IReviewContract;
import io.reactivex.SingleObserver;
import io.reactivex.android.schedulers.AndroidSchedulers;
import io.reactivex.disposables.Disposable;
import io.reactivex.schedulers.Schedulers;

import javax.inject.Inject;

public class ReviewPresenter implements IReviewContract.Presenter {

    private final IVenueData venueData;

    private IReviewContract.View view;
    private IVenue currentVenue;

    @Inject
    public ReviewPresenter(IVenueData venueData) {
        this.venueData = venueData;
    }

    @Override
    public void submitComment(CharSequence comment) {
        venueData
                .submitComment(currentVenue, comment)
                .subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(new SingleObserver<String>() {
                    @Override
                    public void onSubscribe(Disposable d) {
                        view.startLoading();
                    }

                    @Override
                    public void onSuccess(String value) {
                        view.returnToVenueDetails();
                        view.stopLoading();
                    }

                    @Override
                    public void onError(Throwable e) {
                        view.notifyError(e.getMessage());
                        view.returnToVenueDetails();
                        view.stopLoading();
                    }
                });
    }

    @Override
    public void setVenue(IVenue venue) {
        currentVenue = venue;
    }

    public void setView(IReviewContract.View view) {
        this.view = view;
    }
}
