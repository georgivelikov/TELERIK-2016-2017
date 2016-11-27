"use strict";

const express = require("express");
const path = require("path");
const expressSession = require("express-session");
const cookieParser = require("cookie-parser");
const bodyParser = require("body-parser");
const passport = require("passport");

module.exports = {
    initializeExpressViewEngine: function(app, rootPath){
        app.set("view engine", "pug");
        app.set("views", path.join(rootPath, "server/views/"));
        
    },
    initializePublicFilesPath(app, rootPath){
        app.use(express.static(path.join(rootPath, "public")));
    },
    initializeMiddlewares: function(app){
        app.use(cookieParser());
        app.use(bodyParser.urlencoded({ extended: true }));
        app.use(expressSession({
            secret: "brucewaine",
            resave: true,
            saveUninitialized: true
        }));
        app.use(passport.initialize());
        app.use(passport.session());
    }   
};