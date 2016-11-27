"use strict";

module.exports = {
    initializeAuthRoutes: function(app, controllers){
        app.get("/auth/register", controllers.auth.loadRegisterPage);
        app.get("/auth/login", controllers.auth.loadLoginPage);
        app.get("/auth/logout", controllers.auth.logoutUser);

        app.post("/auth/register", controllers.auth.registerUser);
        app.post("/auth/login", controllers.auth.loginUser);
    }
};