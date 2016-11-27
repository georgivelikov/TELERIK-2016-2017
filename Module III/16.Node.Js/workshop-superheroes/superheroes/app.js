"use strict";

const express = require("express");
const config = require("./server/config");
// const userValidator = require("./server/utils/user-validator");

const app = express();
const rootPath = config.rootPath;
config.setupConfigurations(app, rootPath);

const http = require("http").Server(app);

//require("./server/routers")(app, config, userValidator);

http.listen(config.port);
console.log(`Server listens on ${config.port}`);