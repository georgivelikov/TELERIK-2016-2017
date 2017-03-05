package com.telerikacademy.meetup.model.gson;

import com.google.gson.annotations.SerializedName;
import com.telerikacademy.meetup.model.base.IComment;

import java.util.Date;

public class Comment implements IComment {

    @SerializedName("_id")
    private String id;
    @SerializedName("author")
    private String authorUsername;
    @SerializedName("text")
    private String content;
    private Date postDate;

    @Override
    public String getId() {
        return id;
    }

    @Override
    public String getAuthorUsername() {
        return authorUsername;
    }

    @Override
    public String getContent() {
        return content;
    }

    @Override
    public Date getPostDate() {
        return postDate;
    }
}
