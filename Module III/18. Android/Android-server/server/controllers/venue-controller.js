"use strict";

const User = require("../models/user");
const Venue = require("../models/venue");
const Comment = require("../models/comment");

const config = require("../config");

module.exports = () => {
    return {
        postComment(req, res) {
        let body = req.body;
            Venue.findOne({ googleId: body.googleId }, (err, venue) => {
                if (err) {
                    res.statusMessage = "Unknown venue";
                    res.sendStatus(404);
                    return;
                }

                let commentForImport = {
                    author: body.author,
                    text: body.text,
                    postDate: body.postDate
                };

                if(!venue) { 
                    let newVenueForImport = {
                        googleId: body.googleId,
                        venueName: body.venueName,
                        venueAddress: body.venueAddress,
                        comments:[]
                    }

                    Venue.create(newVenueForImport, (error, newVenue) => {
                        if (error) {
                            res.statusMessage = "Enable to parse arguments when creating new venue for the comment";
                            res.sendStatus(404).end();
                            return;
                        } 

                        Comment.create(commentForImport, (error, newComment) => {
                            if (error) {
                                res.statusMessage = "Enable to parse arguments when creating new comment after new venue is created";
                                res.sendStatus(404).end();
                            } else {
                                Venue.update(newVenue, {$push: {"comments": newComment }}, function(err, reponse) {
                                    if (err) {
                                        res.statusMessage = "Error";
                                        res.sendStatus(404).end();
                                    } else {
                                        res.statusMessage = "Comment added successfully";
                                        res.sendStatus(200).end();
                                    }
                                });
                            }                      
                        });
                    });
                } else {
                    Comment.create(commentForImport, (error, newComment) => {
                        if (error) {
                            res.statusMessage = "Enable to parse arguments when creating comment for existing venue";
                            res.sendStatus(404).end();
                        } else {
                            Venue.update(venue, {$push: {"comments": newComment }}, function(err, response) {
                                if (err) {
                                    res.statusMessage = "Error";
                                    res.sendStatus(404).end();
                                } else {
                                    res.statusMessage = "Comment added successfully";
                                    res.sendStatus(200).end();
                                }
                            });
                        }                      
                    });
                }
            })
        },
        getVenue(req, res, next) {
            let googleId = req.params.googleId;

            Venue.findOne({ googleId: googleId }, (err, venue) => {
                if (err) {
                    res.statusMessage = "Unknown venue";
                    res.sendStatus(400).end();
                    return;
                }

                let result = { venue };

                res.json({ result });
            });
        },
        isVenueSavedToUser(req, res, next) {
            let googleId = req.params.googleId;
            let username = req.params.username;

            User.findOne({ username: username }, (err, user) => {
                if (err) {
                    res.statusMessage = "Unknown user";
                    res.sendStatus(400).end();
                    return;
                }

                let isSavedToUser = false;
                if(user) {
                    for(let i = 0; i < user.favorites.length; i += 1) {
                        if(googleId === user.favorites[i].googleId) {
                            isSavedToUser = true;
                            break;
                        }
                    }
                }
                
                let result = { 
                    isSavedToUser
                };

                res.json({ result });
                
            });
        },

    };
};