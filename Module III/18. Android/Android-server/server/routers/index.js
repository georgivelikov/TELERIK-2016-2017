"use strict";

const fs = require("fs");
const path = require("path");

module.exports = ({ app, config, controllers }) => {
    const routersFolderPath = path.join(config.rootPath, "server/routers");
    const routersFileNames = fs.readdirSync(routersFolderPath);


    routersFileNames.filter(file => file.includes("-router"))
        .forEach(file => require(`${__dirname}/${file}`)({ app, controllers }));

    app.all("*", (req, res) => {
        res.status(404);
        res.json(404)
        res.end();
    });
};