"use strict";

const User = require("../models/user");
const Venue = require("../models/venue");

module.exports = () => {
    return {     
        getUser(req, res) {
            let username = req.params.username;

            User.findOne({ username: username }, (err, user) => {
                if (err) {
                    res.statusMessage = "Unknown user";
                    res.sendStatus(400).end();
                    return;
                }

                let result = { user };

                res.json({ result });
            });
        },
        saveVenueToUser(req, res) {
            let body = req.body;
            let user;
            let venue;

            User.findOne({ username: body.username }, (err, foundUser) => {
                if (err) {
                    res.statusMessage = "Unknown user";
                    res.sendStatus(400).end();
                    return;
                }
                
                user = foundUser;
                let isUnique = true;
                for(let i = 0; i < user.favorites.length; i += 1){
                    if(body.googleId === user.favorites[i].googleId) {
                        isUnique = false;
                        break;
                    }
                }

                if(!isUnique){
                    res.statusMessage = "Venue already added";
                    res.sendStatus(200);
                    return;
                }
                
                Venue.findOne({ googleId: body.googleId }, (err, foundVenue) => {
                    if (err) {
                        res.statusMessage = "Unknown venue";
                        res.sendStatus(404);
                        return;
                    }

                    if(!foundVenue) {
                        let newVenueForImport = {
                            googleId: body.googleId,
                            venueName: body.venueName,
                            venueAddress: body.venueAddress,
                            comments:[]
                        }

                        Venue.create(newVenueForImport, (error, newVenue) => { 
                            if (error) {
                                res.statusMessage = "Enable to parse arguments.";
                                res.sendStatus(404).end();
                            } else {
                                venue = newVenue;
                                User.update(user, {$push: {"favorites": venue }}, function(err, response) {
                                    if (err) {
                                        res.statusMessage = "Error";
                                        res.sendStatus(404).end();
                                    } else {
                                        res.statusMessage = "Venue added successfully to user";
                                        res.sendStatus(200).end();
                                    }
                                });
                            }                      
                        });
                    } else {
                        venue = foundVenue;
                        User.update(user, {$push: {"favorites": venue }}, function(err, response) {
                            if (err) {
                                res.statusMessage = "Error";
                                res.sendStatus(404).end();
                            } else {
                                res.statusMessage = "Venue added successfully to user";
                                res.sendStatus(200).end();
                            }
                        });
                    }
                });
            });
        },
        removeVenueFromUser(req, res) {
            let body = req.body;
            let user;
            let venue;
            console.log(body);
            User.findOne({ username: body.username }, (err, foundUser) => {
                if (err) {
                    res.statusMessage = "Unknown user";
                    res.sendStatus(400).end();
                    return;
                }
                
                user = foundUser;
                
                Venue.findOne({ googleId: body.googleId }, (err, foundVenue) => {
                    if (err) {
                        res.statusMessage = "Unknown venue";
                        res.sendStatus(404);
                        return;
                    }

                    if(!foundVenue) {
                        res.statusMessage = "Unknown venue";
                        res.sendStatus(404);
                        return;
                    } else {
                        venue = {
                            googleId: foundVenue.googleId,
                            venueName: foundVenue.venueName,
                            venueAddress: foundVenue.venueAddress
                        };
                        User.update(user, {$pull: {"favorites": venue }}, function(err, response) {
                            if (err) {
                                res.statusMessage = "Error";
                                res.sendStatus(404).end();
                            } else {
                                res.statusMessage = "Venue removed successfully from user";
                                res.sendStatus(200).end();
                            }
                        });
                    }
                });
            });
        }
    };
};