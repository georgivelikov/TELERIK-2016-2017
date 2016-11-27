/* globals module require Promise */
"use strict";

const jsdom = require("jsdom").jsdom,
    doc = jsdom(),
    window = doc.defaultView,
    $ = require("jquery")(window);

module.exports = {
    parseSimpleMovie: function (selector, html) {
        $("body").html(html);
        let items = [];
        $(selector).each((index, item) => {
            const $item = $(item);

            items.push({
                title: $item.html(),
                url: $item.attr("href")
            });
        });

        return Promise.resolve()
            .then(() => {
                return items;
            });
    },

    parseMovieDetails: function (titleSelector, imgSrcSelector, actorsSelector, summarySelector, directorSelector, html) {
        $("body").html(html);
        
        let title = $(titleSelector).html();
        let imgSrc = $(imgSrcSelector).attr('src');   
        let director = $(directorSelector).html();
        let summary = $(summarySelector).html();
        let actors = $(actorsSelector);

        title = fixTitle(title);

        let actorsArray = [];

        actors.each((index, item) => {
            let $item = $(item);
            let link = $item.attr("href");
            let name = $item.html();

            name = fixActorName(name);

            let currentActor = {
                name,
                link
            }
            actorsArray.push(currentActor);
        });

        let movieDetails = {
            title,
            imgSrc,
            director,
            summary,
            actorsArray
        }
        return Promise.resolve()
            .then(() => {
                return movieDetails;
            });
    },
    parseActor: function(nameSelector, bioSelector, imgSrcSelector, html){
        $("body").html(html);

        let name = $(nameSelector).html();
        let imgSrc = $(imgSrcSelector).attr('src');   
        let bio = $(bioSelector).html();
        let movies = [];

        bio = fixBio(bio).trim();

        let actor = {
            name,
            imgSrc,
            bio,
            movies
        }
        return Promise.resolve()
            .then(() => {
                return actor;
            });
    }
};

function fixTitle(title){
    var regex = /&[\s\S]+/g
    title = title.replace(regex, "");
    
    return title;
}

function fixActorName(name){
    var regex = />([\w\s]+)</g
    var match = regex.exec(name);
    if(match){
        return match[1];
    } else {
        return name;
    }
}

function fixBio(bio){
    var regex = /<[\s\S]+/g
    bio = bio.replace(regex, "");
    
    return bio;
}