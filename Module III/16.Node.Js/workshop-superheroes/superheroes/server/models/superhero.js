"use strict";

const mongoose = require("mongoose");

const Schema = mongoose.Schema;

let superheroSchema = new Schema({
    name: {
        type: String,
        required: true,
        minlength: 3, 
        maxlength: 60
    },
    secretIdentity: {
        type: String,
        required: true,
        unique: true,
        minlength: 3, 
        maxlength: 20
    },
    alignement: {
        enum: ['good', 'evil', 'neutral']
    },
    story: {
        type: String,
        required: true
    },
    imageUrl: {
        type: String,
        required: true
    },
    powers: [String],
    fractions: [String]
});

const Superhero = mongoose.model("superhero", superheroSchema);
module.exports = Superhero;