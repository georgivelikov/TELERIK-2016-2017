"use strict";

const mongoose = require("mongoose");

const Schema = mongoose.Schema;

let citySchema = new Schema({
    name: {
        type: String,
        required: true,
        minlength: 2, 
        maxlength: 30,
        unique: true
    },
    country: {
        type: String,
        required: true
    }
});

const City = mongoose.model("city", citySchema);
module.exports = City;