package com.telerikacademy.meetup.util.base;

public interface IUserSession {

    String getUsername();

    void setUsername(String username);

    String getId();

    void setId(String id);

    boolean isUserLoggedIn();

    void clearSession();
}
