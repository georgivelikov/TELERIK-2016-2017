package com.telerikacademy.meetup.network.remote.base;

import com.telerikacademy.meetup.model.base.IUser;
import com.telerikacademy.meetup.model.base.IVenueShort;
import io.reactivex.Observable;
import io.reactivex.Single;

import java.util.List;

public interface IUserData {

    Observable<IUser> signIn(String username, String password);

    Observable<IUser> signUp(String username, String password);

    Single<List<? extends IVenueShort>> getSavedVenues(String username);
}
