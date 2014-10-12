var mongoose = require('mongoose'),
    encryption = require('../../utilities/encryption');
    //validate = require('mongoose-validator');

module.exports.init = function () {
    //var nameValidator = [
    //  validate({
    //        validator: 'isLength',
    //        arguments: [2, 50],
    //        message: 'Name should be between 2 and 20 characters.'
    //    }),
    //  //validate({
    //  //      validator: 'isAlphanumeric',
    //  //      passIfEmpty: true,
    //  //      message: 'Name should contain alpha-numeric characters only'
    //  //  })
    //];

    var userSchema = mongoose.Schema({
        username: { type: String, require: '{PATH} is required', unique: true },    //validate: nameValidator 
        salt: String,
        hashPass: String,
        points: Number,
        role: String
    });

    userSchema.method({
        authenticate: function(password) {
            if (encryption.generateHashedPassword(this.salt, password) === this.hashPass) {
                return true;
            }
            else {
                return false;
            }
        }
    });

    var User = mongoose.model('User', userSchema);
};


