/* globals console require setTimeout Promise */
'use strict';

const httpRequester = require("./utils/http-requester");
const htmlParser = require("./utils/html-parser");
const queuesFactory = require("./data-structures/queue");
const modelsFactory = require("./models");
const constants = require("./config/constants");
const waiter = require("./utils/wait");

let movieDetailsArray = [];
let actorsArray = [];

require("./config/mongoose")(constants.connectionString);

let urlsQueue = queuesFactory.getQueue();
let urlsQueueMovieDetails = queuesFactory.getQueue();
let urlsQueueActors = queuesFactory.getQueue();

constants.genres.forEach(genre => {
    for (let i = 0; i < constants.pagesCount; i += 1) {
        let url = `http://www.imdb.com/search/title?genres=${genre}&title_type=feature&0sort=moviemeter,asc&page=${i+1}&view=simple&ref_=adv_nxt`;
        urlsQueue.push(url);
    }
});

function getMoviesFromUrl(url) {
    console.log(`Working with ${url}`);
    httpRequester.get(url)
        .then((result) => {
            const selector = ".col-title span[title] a";
            const html = result.body;
            return htmlParser.parseSimpleMovie(selector, html);
        })
        .then(movies => {
            let dbMovies = movies.map(movie => {
                return modelsFactory.getSimpleMovie(movie.title, movie.url);
            });

            modelsFactory.insertManySimpleMovies(dbMovies);

            return waiter.wait(1000);
        })
        .then(() => {
            if (urlsQueue.isEmpty()) {
                return;
            }
            getMoviesFromUrl(urlsQueue.pop());
        })
        .catch((err) => {
            console.dir(err, { colors: true });
        });
}

function getMovieDetailsFromUrl(url) {
    httpRequester.get(url)
        .then((result) => {
            const titleSelector = "div.title_wrapper h1[itemprop='name']";
            const imgSrcSelector = ".poster a img";
            const actorsSelector = "span[itemprop='actors'] a";
            const summarySelector = ".summary_text";
            const directorSelector = "span[itemprop='director'] a span";

            const html = result.body;
            return htmlParser.parseMovieDetails(titleSelector, imgSrcSelector, actorsSelector, summarySelector, directorSelector, html);
        })
        .then(movieDetails => {
            let movieDetailsDb = modelsFactory.getMovieDetails
            (
                movieDetails.title, movieDetails.director, movieDetails.summary, movieDetails.imgSrc, movieDetails.actorsArray
            );

            movieDetailsArray.push(movieDetailsDb);

            return waiter.wait(1000);
        })
        .then(() => {
            if (urlsQueueMovieDetails.isEmpty()) {
                modelsFactory.insertManyMovieDetails(movieDetailsArray);
                console.log("ready");
                return;
            }
            getMovieDetailsFromUrl(urlsQueueMovieDetails.pop());
        })
        .catch((err) => {
            console.dir(err, { colors: true });
        });
}

function getActorFromUrl(url) {
    httpRequester.get(url)
        .then((result) => {
            const nameSelector = "h1.header span[itemprop='name']";
            const bioSelector = "div[itemprop='description']";
            const imgSrcSelector = "img#name-poster"

            const html = result.body;
            return htmlParser.parseActor(nameSelector, bioSelector, imgSrcSelector, html);
        })
        .then(actor => {
            let actorDb = modelsFactory.getActor
            (
                actor.name, actor.imgSrc, actor.bio
            );
            actorsArray.push(actorDb);
            return waiter.wait(1000);
        })
        .then(() => {
            if (urlsQueueActors.isEmpty()) {
                modelsFactory.insertManyActors(actorsArray);
                return;
            }
            getActorFromUrl(urlsQueueActors.pop());
        })
        .catch((err) => {
            console.dir(err, { colors: true });
        });
}

const asyncPagesCount = 15;

Array.from({ length: asyncPagesCount })
    .forEach(() => getMoviesFromUrl(urlsQueue.pop()));

modelsFactory.getMovies()
    .then(function(result){
        for(let i = 0; i < result.length; i++){
            var movieId = result[i].imdbId;
            var url = `http://www.imdb.com/title/${movieId}/?ref_=adv_li_tt`;
            urlsQueueMovieDetails.push(url);
        }

        Array.from({ length: 2000 })
            .forEach(() => getMovieDetailsFromUrl(urlsQueueMovieDetails.pop()));
    })

modelsFactory.getAllMoviesDetails()
    .then(function(result){
        for(let i = 0; i < 20; i++){
            for(let j = 0; j < result[i].actors.length; j++){
                let url = "http://www.imdb.com/" + result[i].actors[j].link;
                urlsQueueActors.push(url);
            }
        }

        Array.from({ length: 50 })
             .forEach(() => getActorFromUrl(urlsQueueActors.pop()));    
    })
