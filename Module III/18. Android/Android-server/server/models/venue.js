const mongoose = require("mongoose");

let venueSchema = mongoose.Schema({
    googleId: { type: String, required: true },
    venueName: { type: String, required: true },
    venueAddress: { type: String, required: true },
    comments:  [{
        author: String,
        text: String,
        postDate: Date
    }]
});

let Venue = mongoose.model("venue", venueSchema);
module.exports = Venue;