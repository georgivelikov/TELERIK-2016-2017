"use strict";

const mongoose = require("mongoose");
const passport = require("passport");
const LocalStrategy = require("passport-local").Strategy;
const UsersData = require('../data').users;

module.exports = {
    initializeLocalStrategy: function(){
        passport.use(
            new LocalStrategy({
                usernameField: "username",
                passwordField: "password"
            }, 
            (username, password, done) => {
                UsersData
                    .getUserByUsername(username)
                    .then((resultUser, err) => {
                        if (err) {
                            return done(err);
                        } else if (!resultUser) {
                            done(null, false, { message: "Incorrect credentials." });
                        } else if (!resultUser.isValidPassword(password)) {
                            done(null, false, { message: "Incorrect credentials." });
                        } else {
                            return done(null, resultUser);
                        }
                    });
            }));
    },
    setSerializationProcedure: function(){
        passport.serializeUser((user, done) => {
            done(null, user._id);
        });
    },
    setDeserializationProcedure: function(){
        passport.deserializeUser((id, done) => {
            UsersData.getUserById(id)
                .then((resultUser, err) =>{
                    done(err, resultUser);
                });
            });
    }
}