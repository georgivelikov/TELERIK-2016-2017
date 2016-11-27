"use strict";

const mongoose = require("mongoose");

const Schema = mongoose.Schema;

let planetSchema = new Schema({
    name: {
        type: String,
        required: true,
        minlength: 2, 
        maxlength: 30,
        unique: true
    },
    superheroes: [String],
    fractions: [String]
});

const Planet = mongoose.model("planet", planetSchema);
module.exports = Planet;