"use strict";

const mongoose = require("mongoose");

const Schema = mongoose.Schema;

let powerSchema = new Schema({
    name: {
        type: String,
        required: true,
        minlength: 3, 
        maxlength: 35,
        unique: true
    },
    superheroes: [String]
});

const Power = mongoose.model("power", powerSchema);
module.exports = Power;