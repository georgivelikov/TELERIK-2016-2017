"use strict";

const SuperheroData = require("../data").superheroes;
const UserData = require("../data").users;

function loadAddSuperheroPage(req, res) {
    return res.render("user/add-superhero");
}

function loadShowFavoritsPage(req, res) {
    var user = req.user;

    return res.render("user/show-favorites", { user } );
}

function loadAddToFavoritesPage(req, res) {
    return res.render("user/add-to-favorites");
}

function removeFromFavorites(req, res) {
    let name = req.query.name;
    let user = req.user;

    SuperheroData.getSuperheroByName(name)
        .then((requestedSuperhero) => {
            if(requestedSuperhero){
                return UserData.updateUser(user.id, { $pull: { "favorites": { "_id": requestedSuperhero._id } } }, true)
            } 
        })
        .then(() => {
            res.redirect("/user/show-favorites");
        })
        .catch(() => {
            res.status(500);
            res.send("Removing Superhero failed");
            res.end();
        });
}

function AddSuperhero(req, res) {
    const body = req.body;
    SuperheroData.createSuperhero(body)
        .then((createdSuperhero) => {
            console.log(createdSuperhero);
            res.redirect("/")
        })
        .catch(() => {
            res.status(500);
            res.send("Adding Superhero failed");
            res.end();
        });
}

function AddSuperheroToFavorites(req, res) {
    const body = req.body;
    const user = req.user;

    SuperheroData.getSuperheroByName(body.name)
        .then((requestedSuperhero) => {
            if(requestedSuperhero){
                return UserData.updateUser(user.id, { $push: { "favorites": requestedSuperhero } }, true)
            } 
        })
        .then(() => {
            res.redirect("/");
        })
        .catch(() => {
            res.status(500);
            res.send("Adding Superhero failed");
            res.end();
        });
}

module.exports = { 
    loadAddSuperheroPage,
    loadShowFavoritsPage,
    loadAddToFavoritesPage,
    removeFromFavorites,
    AddSuperhero,
    AddSuperheroToFavorites,

};