package com.telerikacademy.meetup.util;

import android.content.SharedPreferences;
import com.telerikacademy.meetup.util.base.IUserSession;

import javax.inject.Inject;

public class UserSession implements IUserSession {

    private final SharedPreferences sharedPreferences;

    @Inject
    public UserSession(SharedPreferences sharedPreferences) {
        this.sharedPreferences = sharedPreferences;
    }

    @Override
    public String getUsername() {
        String username = sharedPreferences.getString("username", null);
        return username;
    }

    @Override
    public void setUsername(String username) {
        sharedPreferences.edit().putString("username", username).commit();
    }

    @Override
    public String getId() {
        String id = sharedPreferences.getString("id", null);
        return id;
    }

    @Override
    public void setId(String id) {
        sharedPreferences.edit().putString("id", id).commit();
    }

    public boolean isUserLoggedIn() {
        String username = getUsername();
        return username != null;
    }

    public void clearSession() {
        setUsername(null);
        setId(null);
    }
}
