"use strict";

const mongoose = require("mongoose");

const Schema = mongoose.Schema;

let fractionSchema = new Schema({
    name: {
        type: String,
        required: true,
        minlength: 2, 
        maxlength: 30
    },
    alignement: {
        type: String,
        enum: ['good', 'evil', 'neutral']
    },
    members: [String],
    planets: [String]
});

const Fraction = mongoose.model("fraction", fractionSchema);
module.exports = Fraction;