"use strict";

const encryption = require("../utils/encryption");
const mongoose = require("mongoose");

const Schema = mongoose.Schema;

const userSchema = mongoose.Schema({
    username: { type: String, unique: true, required: true },
    firstname: { type: String, required: true },
    lastname: { type: String, required: true },
    passHash: { type: String, required: true },
    salt: { type: String, required: true },
    roles: [String],
    favorites: []
});

userSchema.methods = {
    isValidPassword(password) {
        let realPassHash = this.passHash;
        let currentPassHash = encryption.getPassHash(this.salt, password);
        let isValid = currentPassHash === realPassHash;

        return isValid;
    }
};

const User = mongoose.model("user", userSchema);
module.exports = User;