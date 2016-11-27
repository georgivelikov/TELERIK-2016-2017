/* globals require module */
"use strict";
const SimpleActor = require("./simple-actor-model");

const mongoose = require("mongoose"),
    Schema = mongoose.Schema;

let MovieDetailsSchema = new Schema({
    imgSrc: {
        type: String,
    },
    title: {
        type: String,
    },
    desctiption: {
        type: String,
    },
    director: {
        type: String,
    },
    actors: []
});

MovieDetailsSchema.statics.getMovieDetails =
    function(title, director, summary, imgSrc, actors) {
        return new MovieDetails(
            { title: title, 
              director: director,
              desctiption: summary,
              imgSrc: imgSrc,
              actors: actors 
            });
    };

mongoose.model("MovieDetails", MovieDetailsSchema);
const MovieDetails = mongoose.model("MovieDetails");
module.exports = MovieDetails;
