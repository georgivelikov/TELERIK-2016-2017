package com.telerikacademy.meetup.util;

import com.telerikacademy.meetup.util.base.IValidator;

public class Validator implements IValidator {

    private static final int MIN_USERNAME_LEN = 4;
    private static final int MIN_PASSWORD_LEN = 6;

    public boolean isUsernameValid(String username) {
        if (username.length() < MIN_USERNAME_LEN || username.trim().length() == 0) {
            return false;
        }

        return true;
    }

    public boolean isPasswordValid(String password) {
        if (password.length() < MIN_PASSWORD_LEN || password.trim().length() == 0) {
            return false;
        }

        return true;
    }
}
