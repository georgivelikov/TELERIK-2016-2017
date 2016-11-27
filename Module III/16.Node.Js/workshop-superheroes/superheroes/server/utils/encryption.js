"use strict";

const crypto = require("crypto");

module.exports = {
    getSalt() {
        let salt = crypto.randomBytes(128).toString("base64");
        return salt;
    },
    getPassHash(salt, password) {
        let passHash = crypto
            .createHmac("sha256", salt)
            .update(password)
            .digest("hex");
            
        return passHash;
    }
};