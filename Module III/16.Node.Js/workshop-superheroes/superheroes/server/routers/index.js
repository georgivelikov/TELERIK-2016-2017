"use strict";

const authRouter = require("./auth-router");
const homeRouter = require("./home-router");

module.exports = {
    initializeRoutes: function(app, controllers) {
        authRouter.initializeAuthRoutes(app, controllers);
        homeRouter.initializeHomeRoutes(app, controllers);

        app.all("*", (req, res) => {
            res.status(404);
            res.render("default-not-found");
            res.end();
        });
    }
};