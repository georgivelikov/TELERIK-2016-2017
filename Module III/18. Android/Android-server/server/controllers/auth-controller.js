"use strict";

const User = require("../models/user");
const config = require("../config");

module.exports = () => {
    return {
        registerUser(req, res) {
            let body = req.body;

            User.findOne({ username: body.username }, (err, user) => {
                if (err) {
                    res.statusMessage = "Unknown";
                    res.sendStatus(404);
                    return;
                }

                if (user) {
                    res.statusMessage = "Username already exists.";
                    res.sendStatus(404);              
                } else {
                    User.create(body, (error, newUser) => {
                        if (error) {
                            res.statusMessage = "Enable to parse arguments.";
                            res.sendStatus(404).end();
                        } else {
                            let result = {
                                username: newUser.username,
                                _id: newUser._id
                            };

                            res.json({ result });
                        }                      
                    });
                }
            })
        },
        loginUser(req, res, next) {
            User.findOne({ username: req.body.username, passHash: req.body.passHash }, (err, user) => {
                if (err) {
                    res.statusMessage = "Unknown";
                    res.sendStatus(400).end();
                    return;
                }

                if (!user) {
                    res.statusMessage = "Invalid username or password.";
                    res.sendStatus(404).end();                             
                } else {
                    let result = {
                        username: user.username,
                        _id: user._id
                    };

                    res.json({ result });
                }
            });
        },
        logoutUser(req, res) {
            req.logout();
            res.sendStatus(200);
        }
    };
};