"use strict";

const authRouter = require("./auth-router");
const homeRouter = require("./home-router");
const userRouter = require("./user-router");

module.exports = {
    initializeRoutes: function(app, controllers) {
        authRouter.initializeAuthRoutes(app, controllers);
        homeRouter.initializeHomeRoutes(app, controllers);
        userRouter.initializeUserRoutes(app, controllers);

        app.all("*", (req, res) => {
            res.status(404);
            res.render("default-not-found");
            res.end();
        });
    }
};