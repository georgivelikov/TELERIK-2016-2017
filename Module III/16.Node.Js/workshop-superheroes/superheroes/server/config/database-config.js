"use strict";

const mongoose = require("mongoose");
const connectionStrings = {
        local: "mongodb://localhost:27017/SuperheroesDb",
        remote: "does not exists!"
    }

mongoose.Promise = global.Promise;

module.exports = {
    initializeConnection: function () {
        mongoose.connect(connectionStrings.local);
    }
};