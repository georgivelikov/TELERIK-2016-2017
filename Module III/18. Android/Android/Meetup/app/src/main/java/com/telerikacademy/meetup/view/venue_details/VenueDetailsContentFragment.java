package com.telerikacademy.meetup.view.venue_details;

import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.design.widget.Snackbar;
import android.support.design.widget.TabLayout;
import android.support.v4.app.Fragment;
import android.support.v7.widget.DividerItemDecoration;
import android.support.v7.widget.LinearLayoutManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.Button;
import android.widget.RatingBar;
import android.widget.TextView;
import android.widget.Toast;
import butterknife.BindView;
import butterknife.OnClick;
import com.telerikacademy.meetup.BaseApplication;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.di.annotation.VerticalLayoutManager;
import com.telerikacademy.meetup.config.di.module.ControllerModule;
import com.telerikacademy.meetup.model.base.IComment;
import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.provider.base.IDecorationFactory;
import com.telerikacademy.meetup.provider.base.IIntentFactory;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialog;
import com.telerikacademy.meetup.ui.component.dialog.base.IDialogFactory;
import com.telerikacademy.meetup.ui.fragment.base.IGallery;
import com.telerikacademy.meetup.util.base.IUserSession;
import com.telerikacademy.meetup.view.review.ReviewActivity;
import com.telerikacademy.meetup.view.sign_in.SignInActivity;
import com.telerikacademy.meetup.view.venue_details.base.IVenueDetailsContract;
import com.wang.avi.AVLoadingIndicatorView;

import javax.inject.Inject;
import java.util.ArrayList;
import java.util.List;

public class VenueDetailsContentFragment extends Fragment
        implements IVenueDetailsContract.View {

    private static final String EXTRA_VENUE =
            VenueDetailsContentFragment.class.getCanonicalName() + ".VENUE";

    private static final String PACKAGE_GOOGLE_MAPS = "com.google.android.apps.maps";

    @Inject
    IDecorationFactory decorationFactory;
    @Inject
    IDialogFactory dialogFactory;
    @Inject
    IIntentFactory intentFactory;
    @Inject
    IUserSession userSession;
    @Inject
    @VerticalLayoutManager
    LinearLayoutManager layoutManager;

    @BindView(R.id.venue_details_content_loading_indicator)
    AVLoadingIndicatorView contentLoadingIndicator;
    @BindView(R.id.tv_venue_details_title)
    TextView titleTextView;
    @BindView(R.id.tv_venue_details_rating)
    TextView ratingTextView;
    @BindView(R.id.rb_venue_details_rating)
    RatingBar ratingBar;
    @BindView(R.id.tv_venue_details_type)
    TextView typeTextView;
    @BindView(R.id.wrapper_venue_details_comments)
    ViewGroup commentsWrapper;
    @BindView(R.id.rv_venue_details_comments)
    RecyclerView commentsRecyclerView;
    @BindView(R.id.btn_venue_details_save)
    Button saveButton;

    private IVenueDetailsContract.Presenter presenter;
    private IDialog progressDialog;
    private IGallery gallery;
    private VenueDetailsCommentsAdapter commentsAdapter;
    private TabLayout galleryIndicator;
    private AVLoadingIndicatorView galleryLoadingIndicator;

    public VenueDetailsContentFragment() {
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_venue_details_content, container, false);
        BaseApplication.bind(this, view);
        return view;
    }

    @Override
    public void onActivityCreated(@Nullable Bundle savedInstanceState) {
        super.onActivityCreated(savedInstanceState);
        injectDependencies();
        initialize();
        presenter.loadData();
    }

    @Override
    public void onStart() {
        super.onStart();
        if (isNetworkAvailable()) {
            presenter.subscribe();
        } else {
            stopLoading();
            showErrorMessage();
            getActivity().onBackPressed();
        }
    }

    @Override
    public void onStop() {
        super.onStop();
        presenter.unsubscribe();
    }

    @Override
    public void onResume() {
        super.onResume();
        if (isNetworkAvailable()) {
            presenter.subscribe();
            presenter.loadComments();
        } else {
            stopLoading();
            showErrorMessage();
            getActivity().onBackPressed();
        }
    }

    @Override
    public void onPause() {
        super.onPause();
        presenter.unsubscribe();
    }

    @Override
    public void setPresenter(IVenueDetailsContract.Presenter presenter) {
        this.presenter = presenter;
    }

    @Override
    public void setTitle(CharSequence title) {
        titleTextView.setText(title);
    }

    @Override
    public void setGallery(IGallery gallery) {
        this.gallery = gallery;
    }

    @Override
    public synchronized void addPhoto(final Bitmap photo) {
        if (getActivity() != null) {
            getActivity().runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    gallery.addPhoto(photo);
                }
            });
        }
    }

    @Override
    public void setRating(float rating) {
        ratingTextView.setText(Float.toString(rating));
        ratingBar.setVisibility(View.VISIBLE);
        ratingBar.setRating(rating);
    }

    @Override
    public void setSaveButtonText(Boolean isVenueSavedToUser) {
        if (getActivity() == null) {
            return;
        }

        final Boolean isVenueSaved = isVenueSavedToUser;
        getActivity().runOnUiThread(new Runnable() {
            public void run() {
                if (isVenueSaved) {
                    saveButton.setText("Saved");
                } else {
                    saveButton.setText("Save");
                }
            }
        });
    }

    @Override
    public void setType(String type) {
        typeTextView.setText(type);
    }

    @Override
    public void setComments(List<? extends IComment> comments) {
        if (comments == null || comments.isEmpty()) {
            commentsWrapper.setVisibility(View.GONE);
        } else {
            commentsWrapper.setVisibility(View.VISIBLE);
            commentsAdapter.swap(comments);
        }
    }

    @Override
    public void setDefaultPhoto() {
        getActivity().runOnUiThread(new Runnable() {
            @Override
            public void run() {
                Bitmap photo = BitmapFactory.decodeResource(getResources(),
                        R.drawable.no_image_available);
                gallery.addPhoto(photo);
            }
        });
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
    public void startGalleryLoadingIndicator() {
        galleryLoadingIndicator.smoothToShow();
    }

    @Override
    public void stopGalleryLoadingIndicator() {
        galleryLoadingIndicator.smoothToHide();
    }

    @Override
    public void startContentLoadingIndicator() {
        contentLoadingIndicator.smoothToShow();
    }

    @Override
    public void stopContentLoadingIndicator() {
        contentLoadingIndicator.smoothToHide();
    }

    @Override
    public void showGalleryIndicator() {
        galleryIndicator.setVisibility(View.VISIBLE);
        if (getContext() != null) {
            Animation expandIn = AnimationUtils
                    .loadAnimation(getContext(), R.anim.expand_in);
            galleryIndicator.startAnimation(expandIn);
        }
    }

    @Override
    public void startNavigation(Uri uri) {
        Intent mapIntent = new Intent(Intent.ACTION_VIEW, uri);
        mapIntent.setPackage(PACKAGE_GOOGLE_MAPS);
        startActivity(mapIntent);
    }

    @Override
    public void showErrorMessage() {
        if (getContext() != null) {
            Toast.makeText(getContext(), "An error has occured", Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void startDialer(String phoneNumber) {
        if (phoneNumber == null || phoneNumber.isEmpty()) {
            Toast.makeText(getContext(), "Phone number has not been provided", Toast.LENGTH_SHORT).show();
            return;
        }

        Intent dialerIntent = new Intent(Intent.ACTION_DIAL);
        String formattedPhoneNumber = String.format("tel:%s", phoneNumber.trim());
        dialerIntent.setData(Uri.parse(formattedPhoneNumber));
        startActivity(dialerIntent);
    }

    @Override
    public void startWebsite(Uri websiteUri) {
        if (websiteUri == null) {
            Toast.makeText(getContext(), "Website has not been provided", Toast.LENGTH_SHORT).show();
            return;
        }

        Intent browserIntent = new Intent(Intent.ACTION_VIEW);
        browserIntent.setData(websiteUri);
        startActivity(browserIntent);
    }

    @Override
    public void redirectToReview(IVenue venue) {
        Intent reviewIntent = intentFactory
                .createIntentToFront(ReviewActivity.class)
                .putExtra(EXTRA_VENUE, venue);
        startActivity(reviewIntent);
    }

    @Override
    public void notifySave(String venueName) {
        String msg = String.format("%s added to your favorites", venueName);
        Toast.makeText(getContext(), msg, Toast.LENGTH_SHORT).show();
    }

    @Override
    public void notifyRemove(String venueName) {
        String msg = String.format("%s removed from your favorites", venueName);
        Toast.makeText(getContext(), msg, Toast.LENGTH_SHORT).show();
    }

    @OnClick(R.id.btn_venue_details_call)
    void onCallButtonClick() {
        presenter.onCallButtonClick();
    }

    @OnClick(R.id.btn_venue_details_save)
    void onSaveButtonClick() {
        if (!userSession.isUserLoggedIn()) {
            showSignInPrompt();
        } else {
            presenter.onSaveButtonClick();
        }
    }

    @OnClick(R.id.btn_venue_details_review)
    void onReviewButtonClick() {
        presenter.onReviewButtonClick();
    }

    @OnClick(R.id.btn_venue_details_website)
    void onWebsiteButtonClick() {
        presenter.onWebsiteButtonClick();
    }

    private boolean isNetworkAvailable() {
        ConnectivityManager connectivityManager = (ConnectivityManager)
                getActivity().getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();
        return activeNetworkInfo != null;
    }

    private void showSignInPrompt() {
        Snackbar.make(getView(), "Sign in to continue", Snackbar.LENGTH_SHORT)
                .setAction("Sign in", new View.OnClickListener() {
                    @Override
                    public void onClick(View v) {
                        Intent signIntent = intentFactory
                                .createIntentToFront(SignInActivity.class);
                        startActivity(signIntent);
                    }
                })
                .show();
    }

    private void initialize() {
        progressDialog = dialogFactory
                .createDialog()
                .withContent(R.string.dialog_loading_content)
                .withProgress();

        DividerItemDecoration dividerDecoration = decorationFactory
                .createDividerDecoration(layoutManager.getOrientation(), R.drawable.horizontal_divider);
        commentsAdapter = new VenueDetailsCommentsAdapter(new ArrayList<IComment>());
        commentsRecyclerView.setLayoutManager(layoutManager);
        commentsRecyclerView.addItemDecoration(dividerDecoration);
        commentsRecyclerView.setAdapter(commentsAdapter);
    }

    private void injectDependencies() {
        BaseApplication
                .from(getContext())
                .getComponent()
                .getControllerComponent(new ControllerModule(
                        getActivity(), getFragmentManager()
                ))
                .inject(this);

        galleryIndicator = (TabLayout) getActivity()
                .findViewById(R.id.gallery_indicator);

        galleryLoadingIndicator = (AVLoadingIndicatorView) getActivity()
                .findViewById(R.id.gallery_loading_indicator);
    }
}
