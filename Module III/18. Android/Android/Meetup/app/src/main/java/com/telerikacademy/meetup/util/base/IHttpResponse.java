package com.telerikacademy.meetup.util.base;

import java.util.List;
import java.util.Map;

public interface IHttpResponse {

    Map<String, List<String>> getHeaders();

    String getBody();

    String getMessage();

    int getCode();
}
