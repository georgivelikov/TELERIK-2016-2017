"use strict";

const UserData = require("../data").users;
const encryption = require("../utils/encryption");
const passport = require("passport");

function loadRegisterPage(req, res) {
    res.render("user/register");
}

function loadLoginPage(req, res) {
    res.render("user/login");
}

function logoutUser(req, res) {
    req.logout();
    return res.redirect("/");
}

function registerUser(req, res) {
    const body = req.body;
    UserData
        .getUserByUsername(body.username)
        .then(foundUser => {
            if (!foundUser) {
                let salt = encryption.getSalt();
                let passHash = encryption.getPassHash(salt, body.password);
                let newUserData = {
                    username: body.username,
                    firstname: body.firstname,
                    lastname: body.lastname,
                    passHash: passHash,
                    salt: salt
                };

                UserData
                    .createUser(newUserData)
                    .then(() => res.redirect("/auth/login"))
                    .catch(() => {
                        res.status(500);
                        res.send("Registration failed");
                        res.end();
                    });
            } else {
                res.status(409);
                res.render("user/register", { user });
                res.end();
            }
        });
}

function loginUser(req, res, next) {
    let user = req.user;

    passport.authenticate("local", (err, userModel) => {
        if (err) {
            return next(err);
        }
        if (!userModel) {
            return res.render("user/login");
        }
        req.login(userModel, error => {
            if (error) {
                return next(error);
            }
            return res.redirect("/");
        });
    })(req, res, next);
}

module.exports = { 
    loadRegisterPage, 
    loadLoginPage,
    logoutUser,
    registerUser,
    loginUser
};