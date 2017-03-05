package com.telerikacademy.meetup.view.venue_details;

import android.graphics.Bitmap;
import android.net.Uri;
import com.telerikacademy.meetup.model.base.IComment;
import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.model.base.IVenueDetail;
import com.telerikacademy.meetup.network.local.base.ILocalData;
import com.telerikacademy.meetup.network.remote.base.IVenueData;
import com.telerikacademy.meetup.provider.base.IVenueDetailsProvider;
import com.telerikacademy.meetup.view.venue_details.base.IVenueDetailsContract;
import io.reactivex.android.schedulers.AndroidSchedulers;
import io.reactivex.functions.Consumer;
import io.reactivex.schedulers.Schedulers;
import org.reactivestreams.Subscriber;
import org.reactivestreams.Subscription;

import javax.inject.Inject;
import java.util.List;

public class VenueDetailsPresenter implements IVenueDetailsContract.Presenter {

    private IVenueDetailsContract.View view;
    private IVenueDetail currentVenue;
    private String currentVenueId;
    private boolean isVenueSavedToUser = false;

    private final IVenueDetailsProvider venueDetailsProvider;
    private final IVenueData venueData;
    private final ILocalData localData;

    @Inject
    public VenueDetailsPresenter(IVenueDetailsProvider venueDetailsProvider, IVenueData venueData, ILocalData localData) {
        this.venueDetailsProvider = venueDetailsProvider;
        this.venueData = venueData;
        this.localData = localData;
    }

    @Override
    public void setView(IVenueDetailsContract.View view) {
        this.view = view;
    }

    @Override
    public void setVenueId(String venueId) {
        currentVenueId = venueId;
    }

    @Override
    public void subscribe() {
        venueDetailsProvider.connect();
    }

    @Override
    public void unsubscribe() {
        venueDetailsProvider.disconnect();
    }

    @Override
    public void loadData() {
        if (currentVenueId == null || currentVenueId.isEmpty()) {
            return;
        }

        view.startLoading();
        view.startContentLoadingIndicator();

        venueDetailsProvider
                .getById(currentVenueId)
                .subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(new Consumer<IVenueDetail>() {
                    @Override
                    public void accept(IVenueDetail venue) throws Exception {
                        currentVenue = venue;
                        view.setTitle(venue.getName());
                        view.setRating(venue.getRating());
                        if (venue.getTypes().length > 0) {
                            view.setType(venue.getTypes()[0]);
                        }

                        setSaveStatus(currentVenue);
                        loadPhotos();
                        loadComments();
                        view.stopContentLoadingIndicator();
                    }
                });
    }

    @Override
    public void loadComments() {
        if (currentVenueId == null || currentVenueId.isEmpty()) {
            view.setComments(null);
            return;
        }

        venueData
                .getComments(currentVenueId)
                .subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(new Consumer<List<? extends IComment>>() {
                    @Override
                    public void accept(List<? extends IComment> comments) throws Exception {
                        view.setComments(comments);
                    }
                });
    }

    @Override
    public void loadPhotos() {
        if (currentVenueId == null || currentVenueId.isEmpty()) {
            view.setDefaultPhoto();
            view.stopLoading();
            view.stopGalleryLoadingIndicator();
            view.showGalleryIndicator();
            view.showErrorMessage();
            return;
        }

        venueDetailsProvider
                .getPhotos(currentVenueId)
                .subscribeOn(Schedulers.io())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(new Subscriber<Bitmap>() {
                    private static final int ITEMS_PER_REQUEST = 1;

                    private Subscription subscription;
                    private boolean isFirst = true;
                    private boolean hasPhoto = false;

                    @Override
                    public void onSubscribe(Subscription subscription) {
                        this.subscription = subscription;
                        subscription.request(ITEMS_PER_REQUEST);
                    }

                    @Override
                    public void onNext(Bitmap photo) {
                        Bitmap modifiedPhoto = photo.copy(Bitmap.Config.RGB_565, true);
                        photo.recycle();

                        view.addPhoto(modifiedPhoto);

                        if (isFirst) {
                            isFirst = false;
                            saveToRecent(currentVenue, modifiedPhoto);
                            view.stopLoading();
                            view.startGalleryLoadingIndicator();
                            hasPhoto = true;
                        }

                        subscription.request(ITEMS_PER_REQUEST);
                    }

                    @Override
                    public void onError(Throwable t) {
                        view.setDefaultPhoto();
                        view.stopLoading();
                        view.stopGalleryLoadingIndicator();
                        view.showGalleryIndicator();
                        view.showErrorMessage();
                    }

                    @Override
                    public void onComplete() {
                        if (!hasPhoto) {
                            view.setDefaultPhoto();
                            saveToRecent(currentVenue, null);
                        }

                        view.stopLoading();
                        view.stopGalleryLoadingIndicator();
                        view.showGalleryIndicator();
                    }
                });
    }

    @Override
    public void onNavigationButtonClick() {
        if (currentVenue == null || currentVenue.getLatitude() == -1 || currentVenue.getLongitude() == -1) {
            return;
        }

        String uriString = String.format("google.navigation:q=%s,%s",
                currentVenue.getLatitude(), currentVenue.getLongitude());
        view.startNavigation(Uri.parse(uriString));
    }

    @Override
    public void onCallButtonClick() {
        view.startDialer(currentVenue.getPhoneNumber());
    }

    @Override
    public void onWebsiteButtonClick() {
        view.startWebsite(currentVenue.getWebsiteUri());
    }

    @Override
    public void onReviewButtonClick() {
        view.redirectToReview(currentVenue);
    }

    @Override
    public void onSaveButtonClick() {
        if (isVenueSavedToUser) {
            if (currentVenue != null) {
                isVenueSavedToUser = false;
                venueData.removeVenueFromUser(currentVenue)
                        .subscribeOn(Schedulers.io())
                        .subscribe();
                view.setSaveButtonText(isVenueSavedToUser);
                view.notifyRemove(currentVenue.getName());
            }
        } else {
            if (currentVenue != null) {
                isVenueSavedToUser = true;
                venueData.saveVenueToUser(currentVenue)
                        .subscribeOn(Schedulers.io())
                        .subscribe();
                view.setSaveButtonText(isVenueSavedToUser);
                view.notifySave(currentVenue.getName());
            }
        }

    }

    private synchronized void saveToRecent(IVenue venue, Bitmap photo) {
        if (venue != null) {
            localData.saveVenueToRecent(venue, photo)
                    .subscribeOn(Schedulers.io())
                    .subscribe();
        }
    }

    private void setSaveStatus(IVenue currentVenue) {
        if (currentVenue != null) {
            venueData.isVenueSavedToUser(currentVenue)
                    .subscribeOn(Schedulers.io())
                    .subscribe(new Consumer<Boolean>() {
                        @Override
                        public void accept(Boolean isVenueSaved) throws Exception {
                            isVenueSavedToUser = isVenueSaved;
                            view.setSaveButtonText(isVenueSavedToUser);
                        }
                    });
        }
    }
}
