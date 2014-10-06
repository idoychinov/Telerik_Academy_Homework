'use strict';

var mongoose = require('mongoose');

var userSchema = new mongoose.Schema({
    username: {type: String, required: true},
    password: {type: String, required: true}
});

userSchema.path('password').validate(function (value) {
    return value.length >= 6;
}, "Password must be at least 6 symbols");

userSchema.path('username').validate(function (value) {
    return value.length >= 2 && value.length <= 20;
}, "Password must be between 2 and 20 symbols");

userSchema.statics.uniqueUsername = function (username, callback) {
    User.find()
        .where('username').equals(username)
        .exec(function (err, users) {
            if (err) throw err;
            if (users.length !== 0) {
                console.error('Username already exists')
            }
            callback();
        });
};


var User = mongoose.model('User', userSchema);

module.exports = User;