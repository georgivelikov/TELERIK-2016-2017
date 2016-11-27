/* globals require module */
"use strict";

const mongoose = require("mongoose"),
    Schema = mongoose.Schema;

let SimpleActorSchema = new Schema({
    imgSrc: {
        type: String,
    },
    name: {
        type: String,
    },
    bio: {
        type: String,
    },
    movies: {
        type: [],
    }
});

let SimpleActor;

SimpleActorSchema.virtual.imdbUrl = function() {
    return `http://imdb.com/title/${this.imdbId}/?ref_=adv_li_tt`;
};

SimpleActorSchema.statics.getActor =
    function(name, imgSrc, bio) {
        return new SimpleActor(
            { name: name, 
              imgSrc: imgSrc,
              bio: bio,
              movies: []
            });
    };

mongoose.model("SimpleActor", SimpleActorSchema);
SimpleActor = mongoose.model("SimpleActor");
module.exports = SimpleActor;