const mongoose = require("mongoose");

let userSchema = mongoose.Schema({
    username: { type: String, unique: true },
    passHash: { type: String, required: true },
    favorites:  [{
        googleId: { type: String, required: true },
        venueName: { type: String, required: true },
        venueAddress: { type: String, required: true }
    }]
});

let User = mongoose.model("user", userSchema);
module.exports = User;