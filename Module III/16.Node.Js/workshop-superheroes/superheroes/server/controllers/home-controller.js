"use strict";

const SuperheroData = require("../data").superheroes;

function loadHomePage(req, res) {
    let user = req.user
    let model = {
        content: "SUPERHEROES HOME PAGE!"
    }

    res.render("home/home", { user, model});
}

function loadAllSuperheroes(req, res) {
    let user = req.user

    SuperheroData
        .getAllSuperheroes()
        .then(superheroes => {
            res.render("home/all-superheroes", { user, superheroes });
        });    
}

module.exports = { 
    loadHomePage,
    loadAllSuperheroes
};