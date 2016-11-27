"use strict";

module.exports = {
    initializeHomeRoutes: function(app, controllers){
        app.get("/", controllers.home.loadHomePage);
        app.get("/all-superheroes", controllers.home.loadAllSuperheroes);
    }
};