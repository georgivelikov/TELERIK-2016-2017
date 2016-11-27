/* globals require module */
"use strict";

const mongoose = require("mongoose"),
    Schema = mongoose.Schema;

mongoose.Promise = global.Promise;

let SimpleMovieSchema = new Schema({
    name: {
        type: String,
        required: true
    },
    imdbId: {
        type: String,
        required: true
    },
});

//  /title/tt0067992/?ref_=adv_li_tt
function extractImdbIdFromUrl(url) {
    let index = url.indexOf("/?ref");
    return url.substring("/title/".length, index);
}


let SimpleMovie;
SimpleMovieSchema.statics.getSimpleMovieByNameAndUrl =
    function(name, url) {
        let imdbId = extractImdbIdFromUrl(url);
        return new SimpleMovie({ name, imdbId });
    };

SimpleMovieSchema.virtual('imdbUrl').get(function () {
    return `http://imdb.com/title/${this.imdbId}/?ref_=adv_li_tt`
});



SimpleMovie = mongoose.model("SimpleMovie", SimpleMovieSchema);
module.exports = SimpleMovie;