"use strict";

const path = require("path");
const rootPath = path.join(__dirname, "/../../");

const databaseConfig = require('./database-config');
const expressConfig = require('./express-config');
const passportConfig = require('./passport-config');
const router = require("../routers");
const controllers = require("../controllers");

module.exports = {
    port: process.env.PORT || 8080,
    rootPath: rootPath,
    setupConfigurations: function(app, rootPath){
        //database
        databaseConfig.initializeConnection();

        //express
        expressConfig.initializeExpressViewEngine(app, rootPath);
        expressConfig.initializePublicFilesPath(app, rootPath);
        expressConfig.initializeMiddlewares(app);
        
        //passport
        passportConfig.initializeLocalStrategy();
        passportConfig.setSerializationProcedure();
        passportConfig.setDeserializationProcedure();

        //routers
        router.initializeRoutes(app, controllers);
    }
};