const passport = require("passport");
const LocalStrategy = require("passport-local").Strategy;
const User = require("../models/user");
const FacebookStrategy = require("passport-facebook").Strategy;

const JwtStrategy = require('passport-jwt').Strategy;
const ExtractJwt = require('passport-jwt').ExtractJwt;

function jwtCallback(wt_payload, done) {
    User.findOne({ id: jwt_payload.sub }, (err, user) => {
        if (err) {
            return done(err, false);
        }

        if (user) {
            return done(null, user);
        }

        return done(null, false);
    });
}

function facebookCallback(accessToken, refreshToken, profile, cb) {
    // User.findOrCreate({ facebookId: profile.id }, function (err, user) {
    //     return cb(err, user);
    // });
    console.log(accessToken);
    console.log(refreshToken);
    console.log(profile);
}

module.exports = app => {
    app.use(passport.initialize());

    let jwtStrategy = new JwtStrategy({
        jwtFromRequest: ExtractJwt.fromAuthHeader(),
        secretOrKey: 'secret',
        audience: "localhost:3000"
    }, jwtCallback);

    passport.use(jwtStrategy);
    let fbStrategy = new FacebookStrategy({
        clientID: "239648519799357",
        clientSecret: "10303234548430a9d92896f2700cd659",
        callbackURL: "http://localhost:8080/auth/facebook/callback"
    }, facebookCallback);

    passport.use(fbStrategy);
};