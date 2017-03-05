package com.telerikacademy.meetup.model.gson;

import com.google.gson.annotations.SerializedName;
import com.telerikacademy.meetup.model.base.IUser;

public class User implements IUser {

    @SerializedName("_id")
    private String id;
    private String username;

    public String getId() {
        return this.id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getUsername() {
        return this.username;
    }

    public void setUsername(String username) {
        this.username = username;
    }
}
