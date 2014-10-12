var User = require('mongoose').model('User'),
    encryption = require('../utilities/encryption')

module.exports = {
    create: function(user, callback) {
        User.create(user, callback);
    },
    all: function (callback) {
        User.find({}).exec(callback);
    },
    delete: function (id, callback) {
        User.remove({ _id: id }).exec(callback);
    },
    update: function (id, user, callback) {
        User.update({ _id: id }, user, callback);
    },

    seedInitialUsers: function () {
        User.find({}).exec(function (err, collection) {
            if (err) {
                console.log('Cannot find users: ' + err);
                return;
            }
            
            if (collection.length === 0) {
                var salt;
                var hashedPwd;
                
                salt = encryption.generateSalt();
                hashedPwd = encryption.generateHashedPassword(salt, 'Admin');
                User.create({ username: 'admin', salt: salt, hashPass: hashedPwd, role: 'admin' });
                salt = encryption.generateSalt();
                hashedPwd = encryption.generateHashedPassword(salt, 'Pesho');
                User.create({ username: 'pehso', salt: salt, hashPass: hashedPwd, role: 'user' });
                salt = encryption.generateSalt();
                hashedPwd = encryption.generateHashedPassword(salt, 'Gosho');
                User.create({ username: 'gosho', salt: salt, hashPass: hashedPwd, role: 'user' });
                salt = encryption.generateSalt();
                hashedPwd = encryption.generateHashedPassword(salt, 'Ivan');
                User.create({ username: 'ivan', salt: salt, hashPass: hashedPwd, role: 'user' });
                console.log('Users added to database...');
            }
        });
    }
};