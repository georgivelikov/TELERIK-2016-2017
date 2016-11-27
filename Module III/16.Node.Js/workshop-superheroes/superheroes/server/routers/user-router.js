"use strict";

module.exports = {
    initializeUserRoutes: function(app, controllers){
        app.get("/user/add-superhero", controllers.user.loadAddSuperheroPage);
        app.get("/user/show-favorites", controllers.user.loadShowFavoritsPage);
        app.get("/user/add-to-favorites", controllers.user.loadAddToFavoritesPage);
        app.get("/user/remove-from-favorites", controllers.user.removeFromFavorites);

        app.post("/user/add-superhero", controllers.user.AddSuperhero);
        app.post("/user/add-to-favorites", controllers.user.AddSuperheroToFavorites);
    }
};