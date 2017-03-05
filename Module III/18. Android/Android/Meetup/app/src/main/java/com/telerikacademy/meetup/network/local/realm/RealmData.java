package com.telerikacademy.meetup.network.local.realm;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import com.telerikacademy.meetup.R;
import com.telerikacademy.meetup.config.base.IApiConstants;
import com.telerikacademy.meetup.model.base.IVenue;
import com.telerikacademy.meetup.network.local.base.ILocalData;
import com.telerikacademy.meetup.provider.base.IVenueFactory;
import com.telerikacademy.meetup.util.base.IImageUtil;
import com.telerikacademy.meetup.util.base.IUserSession;
import io.reactivex.Single;
import io.reactivex.SingleSource;
import io.realm.Realm;
import io.realm.RealmConfiguration;
import io.realm.RealmResults;
import io.realm.Sort;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Date;
import java.util.List;
import java.util.concurrent.Callable;

public class RealmData implements ILocalData {

    private final IUserSession userSession;
    private final IImageUtil imageUtil;
    private final IApiConstants constants;
    private final IVenueFactory venueFactory;
    private Context context;

    public RealmData(Context context, IUserSession userSession, IImageUtil imageUtil,
                     IApiConstants constants, IVenueFactory venueFactory) {

        this.context = context;
        this.userSession = userSession;
        this.imageUtil = imageUtil;
        this.constants = constants;
        this.venueFactory = venueFactory;
        Realm.init(this.context);
    }

    @Override
    public Single<IVenue> saveVenueToRecent(final IVenue venue, final Bitmap photo) {
        return Single.defer(new Callable<SingleSource<IVenue>>() {
            @Override
            public SingleSource<IVenue> call() throws Exception {
                final Realm realm = Realm.getDefaultInstance();

                Bitmap venuePhoto = photo;
                if (venuePhoto == null) {
                    venuePhoto = BitmapFactory.decodeResource(context.getResources(),
                            R.drawable.no_image_available);
                }

                String googleId = venue.getId();
                String name = venue.getName();
                byte[] pictureBytes = imageUtil.parseToByteArray(venuePhoto);
                String username = userSession.getUsername();
                if (username == null) {
                    username = constants.defaultUsername();
                }

                Date dateViewed = new Date();
                String id = generateId(googleId, name, username);

                RealmRecentVenue recentVenue = new RealmRecentVenue();
                recentVenue.setId(id);
                recentVenue.setGoogleId(googleId);
                recentVenue.setName(name);
                recentVenue.setRating(venue.getRating());
                recentVenue.setPictureBytes(pictureBytes);
                recentVenue.setViewerUsername(username);
                recentVenue.setDateViewed(dateViewed);

                realm.beginTransaction();
                realm.copyToRealm(recentVenue);
                realm.commitTransaction();
                realm.close();

                return Single.just(venue);
            }
        });
    }

    @Override
    public Single<List<IVenue>> getRecentVenues() {
        return Single.defer(new Callable<SingleSource<List<IVenue>>>() {
            @Override
            public SingleSource<List<IVenue>> call() throws Exception {
                final List<IVenue> resultsToDisplay = new ArrayList<>();
                final Realm realm = Realm.getDefaultInstance();

                String currentUsername = userSession.getUsername();
                if (currentUsername == null) {
                    currentUsername = constants.defaultUsername();
                }

                final RealmResults<RealmRecentVenue> results = realm
                        .where(RealmRecentVenue.class)
                        .equalTo("viewerUsername", currentUsername)
                        .findAllSorted("dateViewed", Sort.DESCENDING)
                        .distinct("name");

                final BitmapFactory.Options bitmapOptions = new BitmapFactory.Options();
                bitmapOptions.inPreferredConfig = Bitmap.Config.RGB_565;
                bitmapOptions.inJustDecodeBounds = false;
                bitmapOptions.inSampleSize = 4;

                for (RealmRecentVenue r : results) {
                    IVenue venue = venueFactory.createVenue(r.getGoogleId(), r.getName());
                    venue.setPhoto(imageUtil.parseToBitmap(r.getPictureBytes(), bitmapOptions));
                    venue.setRating(r.getRating());
                    resultsToDisplay.add(venue);
                }

                realm.close();
                return Single.just(resultsToDisplay);
            }
        });
    }

    @Override
    public void clearData() {
        RealmConfiguration config = new RealmConfiguration.Builder()
                .deleteRealmIfMigrationNeeded()
                .build();
        Realm realm = Realm.getInstance(config);
        realm.beginTransaction();
        realm.deleteAll();
        realm.commitTransaction();
        realm.close();
    }

    private String generateId(String venueId, String username, String venueName) {
        String helpString = venueId + username + venueName;
        char[] array = helpString.toCharArray();
        List<Character> list = new ArrayList<>();

        for (int i = 0; i < array.length; i++) {
            if (array[i] != ' ') {
                list.add(array[i]);
            }
        }

        Collections.shuffle(list);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < list.size(); i++) {
            sb.append(list.get(i));
        }

        return sb.toString();
    }
}
