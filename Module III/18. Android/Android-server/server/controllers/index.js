/* globals module require __dirname */
"use strict";

const path = require("path");
const fs = require("fs");

module.exports = ({ app, config, passport }) => {
    let controllers = {};
    fs.readdirSync(__dirname)
        .filter(file => file.includes("-controller"))
        .forEach(file => {
            let controllerModule = require(path.join(__dirname, file))({ app, config, passport });

            let moduleName = file.substring(0, file.indexOf("-controller"));
            controllers[moduleName] = controllerModule;
        });

    return controllers;
};