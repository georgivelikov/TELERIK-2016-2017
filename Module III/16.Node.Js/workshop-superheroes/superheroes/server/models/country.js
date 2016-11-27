"use strict";

const mongoose = require("mongoose");

const Schema = mongoose.Schema;

let countrySchema = new Schema({
    name: {
        type: String,
        required: true,
        minlength: 2, 
        maxlength: 30,
        unique: true
    },
    planet: {
        type: String,
        required: true
    }
});

const country = mongoose.model("country", countrySchema);
module.exports = country;