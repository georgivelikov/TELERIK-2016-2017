package com.telerikacademy.meetup.provider;

import android.content.Context;
import android.graphics.Bitmap;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import com.google.android.gms.common.ConnectionResult;
import com.google.android.gms.common.api.GoogleApiClient;
import com.google.android.gms.location.places.*;
import com.telerikacademy.meetup.model.base.IVenueDetail;
import com.telerikacademy.meetup.provider.base.IVenueFactory;
import com.telerikacademy.meetup.provider.base.VenueDetailsProvider;
import io.reactivex.*;

import javax.inject.Inject;
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.concurrent.Callable;

public class GoogleVenueDetailsProvider extends VenueDetailsProvider
        implements GoogleApiClient.OnConnectionFailedListener {

    private static Map<Integer, String> venueTypeMap;

    private final Context context;
    private final IVenueFactory venueFactory;
    private GoogleApiClient googleApiClient;

    static {
        venueTypeMap = new HashMap<>();
    }

    @Inject
    public GoogleVenueDetailsProvider(Context context, IVenueFactory venueFactory) {
        this.context = context;
        this.venueFactory = venueFactory;
        buildGoogleApiClient(context);
    }

    @Override
    public void connect() {
        googleApiClient.connect();
    }

    @Override
    public void disconnect() {
        googleApiClient.disconnect();
    }

    public Flowable<Bitmap> getPhotos(@NonNull final String placeId) {
        return Flowable.create(new FlowableOnSubscribe<Bitmap>() {
            @Override
            public void subscribe(FlowableEmitter<Bitmap> emitter) throws Exception {
                PlacePhotoMetadataBuffer buffer = null;
                try {
                    PlacePhotoMetadataResult res = Places.GeoDataApi
                            .getPlacePhotos(googleApiClient, placeId)
                            .await();
                    buffer = res.getPhotoMetadata();

                    for (PlacePhotoMetadata photoMetadata : buffer) {
                        Bitmap photo = photoMetadata
                                .getPhoto(googleApiClient)
                                .await()
                                .getBitmap();

                        if (photo != null) {
                            emitter.onNext(photo);
                        }
                    }
                } catch (Exception ex) {
                    emitter.onError(ex);
                } finally {
                    if (buffer != null) {
                        buffer.release();
                    }
                    emitter.onComplete();
                }
            }
        }, BackpressureStrategy.BUFFER);
    }

    public Observable<IVenueDetail> getById(@NonNull final String placeId) {
        return Observable.defer(new Callable<ObservableSource<? extends IVenueDetail>>() {
            @Override
            public ObservableSource<? extends IVenueDetail> call() throws Exception {
                PlaceBuffer places = Places.GeoDataApi
                        .getPlaceById(googleApiClient, placeId)
                        .await();

                if (places.getCount() > 0) {
                    Place place = places.get(0);
                    Observable<IVenueDetail> result = Observable
                            .just(parsePlace(place));

                    places.release();
                    return result;
                }

                places.release();
                return null;
            }
        });
    }

    @Override
    public void onConnectionFailed(@NonNull ConnectionResult connectionResult) {
        if (getOnConnectionFailedListener() != null) {
            String errorMessage = connectionResult.getErrorCode() + " " + connectionResult.getErrorMessage();
            getOnConnectionFailedListener().onConnectionFailed(errorMessage);
        }
    }

    protected synchronized void buildGoogleApiClient(Context context) {
        if (googleApiClient == null) {
            googleApiClient = new GoogleApiClient.Builder(context)
                    .addApi(Places.GEO_DATA_API)
                    .addApi(Places.PLACE_DETECTION_API)
                    .addOnConnectionFailedListener(this)
                    .build();
        }
    }

    private IVenueDetail parsePlace(Place place) {
        List<String> placeTypesList = parsePlaceTypes(place.getPlaceTypes());
        String[] placeTypesArray = new String[placeTypesList.size()];
        placeTypesArray = placeTypesList.toArray(placeTypesArray);

        float placeRating = place.getRating() < 0 ? 0.0f : place.getRating();

        IVenueDetail venue = venueFactory.createVenueDetail(
                place.getId(),
                place.getName().toString(),
                place.getAddress().toString(),
                placeTypesArray,
                placeRating,
                place.getPhoneNumber().toString(),
                place.getWebsiteUri()
        );
        venue.setLatitude(place.getLatLng().latitude);
        venue.setLongitude(place.getLatLng().longitude);

        return venue;
    }

    @Nullable
    private List<String> parsePlaceTypes(List<Integer> typesAsInteger) {
        List<String> parsedTypes = new ArrayList<>();

        Map<Integer, String> types = extractTypes();
        for (Integer typeAsInteger : typesAsInteger) {
            if (types.containsKey(typeAsInteger)) {
                String typeName = types.get(typeAsInteger);
                parsedTypes.add(typeName);
            }
        }

        return parsedTypes;
    }

    private Map<Integer, String> extractTypes() {
        if (venueTypeMap != null && !venueTypeMap.isEmpty()) {
            return venueTypeMap;
        }

        final String FILE_PATH = "raw/place_types.txt";
        final String TYPE_SEPARATOR = ",";

        InputStream inputStream = null;
        BufferedReader reader = null;

        try {
            inputStream = context.getAssets().open(FILE_PATH);
            reader = new BufferedReader(new InputStreamReader(inputStream));
            if (inputStream != null) {
                String currLine;
                while ((currLine = reader.readLine()) != null) {
                    String[] type = currLine.split(TYPE_SEPARATOR);
                    String typeName = type[0];
                    String typeValue = type[1];
                    Integer typeValueAsInt = Integer.parseInt(typeValue);
                    venueTypeMap.put(typeValueAsInt, typeName);
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        } finally {
            try {
                inputStream.close();
                reader.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }

        return venueTypeMap;
    }
}
