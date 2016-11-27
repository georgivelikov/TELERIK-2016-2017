/* globals module require */

const SimpleMovie = require("./simple-movie-model");
const SimpleActor = require("./simple-actor-model");
const MovieDetails = require("./movie-details-model");

module.exports = {
    getSimpleMovie(name, url) {
        return SimpleMovie.getSimpleMovieByNameAndUrl(name, url);
    },
    insertManySimpleMovies(movies) {
        SimpleMovie.insertMany(movies);
    },
    getMovies() {
        return new Promise((resolve, reject) => {
            SimpleMovie
                .where({})
                .exec((err, data) => {
                    resolve(data);
                })
        })
    },
    getAllMoviesDetails() {
        return new Promise((resolve, reject) => {
            MovieDetails
                .where({})
                .exec((err, data) => {
                    resolve(data);
                })
        })
    },
    getMovieDetails(title, director, summary, imgSrc, actors) {
        return MovieDetails.getMovieDetails(title, director, summary, imgSrc, actors);
    },
    insertMovieDetails(movieDetails){
        movieDetails.save();
    },
    insertManyMovieDetails(manyMovieDetails){
        MovieDetails.insertMany(manyMovieDetails);
    },
    getActor(name, imgSrc, bio){
        return SimpleActor.getActor(name, imgSrc, bio);
    },
    insertActor(actor){
        actor.save();
    },
    insertManyActors(manyActors){
        SimpleActor.insertMany(manyActors);
    },
};