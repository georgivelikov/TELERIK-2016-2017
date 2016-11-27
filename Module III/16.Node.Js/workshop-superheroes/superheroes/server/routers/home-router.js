"use strict";

module.exports = {
    initializeHomeRoutes: function(app, controllers){
        app.get("/", controllers.home.loadHomePage);
    }
};