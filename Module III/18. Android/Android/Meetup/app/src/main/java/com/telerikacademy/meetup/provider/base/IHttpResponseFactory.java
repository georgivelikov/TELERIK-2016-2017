package com.telerikacademy.meetup.provider.base;

import com.telerikacademy.meetup.util.base.IHttpResponse;

import java.util.List;
import java.util.Map;

public interface IHttpResponseFactory {

    IHttpResponse createResponse(
            final Map<String, List<String>> headers, final String body,
            final String message, final int code);
}
