package com.telerikacademy.meetup.model.base;

import java.util.Date;

public interface IComment {

    String getId();

    String getAuthorUsername();

    String getContent();

    Date getPostDate();
}
