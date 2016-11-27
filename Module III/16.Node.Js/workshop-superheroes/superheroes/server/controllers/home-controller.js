"use strict";

function loadHomePage(req, res) {
    let user = req.user
    let model = {
        content: "SUPERHEROES HOME PAGE!"
    }

    res.render("home/home", { user, model});
}

module.exports = { loadHomePage };