'use strict';

var mongoose = require('mongoose');

var messageSchema = new mongoose.Schema({
    from: {type: mongoose.Schema.ObjectId, ref: 'User', required: true},
    to: {type: mongoose.Schema.ObjectId,  ref: 'User', required: true},
    text: String,
    time: Date
});

var Message = mongoose.model('Message', messageSchema);

module.exports = Message;
