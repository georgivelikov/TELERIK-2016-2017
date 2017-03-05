const mongoose = require("mongoose");

let commentSchema = mongoose.Schema({
    author: { type: String, required: true },
    text: { type: String, required: true },
    postDate: { type: Date, required: true },
});

let Comment = mongoose.model("comment", commentSchema);
module.exports = Comment;