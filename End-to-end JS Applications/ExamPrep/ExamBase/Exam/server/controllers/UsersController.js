var encryption = require('../utilities/encryption'),
    users = require('../data/users');

var CONTROLLER_NAME = 'users';

users.seedInitialUsers();

module.exports = {
    getRegister: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/register')
    },
    postRegister: function(req, res, next) {
        var newUserData = req.body;

        if (newUserData.username.length < 2 || newUserData.username.length > 20) {
            req.session.error = 'Username must be between 2 and 20 characters!';
            return res.redirect('/register');
        }
        if (newUserData.password.length < 6) {
            req.session.error = 'Password must be at least 6 symbols long!';
            return res.redirect('/register');
        }
        if (newUserData.password != newUserData.confirmPassword) {
            req.session.error = 'Passwords do not match!';
            return res.redirect('/register');
        }
        else {
            newUserData.role = "user";
            newUserData.salt = encryption.generateSalt();
            newUserData.hashPass = encryption.generateHashedPassword(newUserData.salt, newUserData.password);
            users.create(newUserData, function(err, user) {
                if (err) {
                    req.session.error = 'Failed to register new user: ' + err;
                    res.redirect('/register');
                    //console.log('Failed to register new user: ' + err);
                    return;
                }
                
                req.logIn(user, function(err) {
                    if (err) {
                        res.status(400);
                        req.session.error = err.toString();
                        return; //res.send({reason: err.toString()}); // TODO
                    }
                    else {
                        res.redirect('/');
                    }
                })
            });
        }
    },
    getLogin: function(req, res, next) {
        res.render(CONTROLLER_NAME + '/login');
    },
    getProfile: function (req, res, next) {
        res.render(CONTROLLER_NAME + '/profile');
    },
    update: function (req, res, next) {
        console.log(req.params.id);
        if (req.user._id == req.body._id || req.user.role.indexOf('admin') > -1) {
            var updatedUserData = req.body;
            if (updatedUserData.password && updatedUserData.password.length > 2) {
                updatedUserData.salt = encryption.generateSalt();
                updatedUserData.hashPass = encryption.generateHashedPassword(updatedUserData.salt, updatedUserData.password);
            }
            
            users.update(req.body._id, updatedUserData, function () {
                //res.redirect('/user/' + req.user._id)
                res.end();
            })
        }
        else {
            req.session.error = 'You do not have permission!';
        }
    },
    getAll: function (req, res, next) {
        users.all(function (err, data) {
            if (err) {
                req.session.error = 'Cannot get users: ' + err
                    //console.log("Can't get users.")
            } else {
                res.render(CONTROLLER_NAME + '/users-list', { users: data });
            }
        });
    },
    deleteUser: function (req, res, next) {
      users.delete(req.params.id, function (err) {
            if (err) {
                req.session.error = 'Cannot delete user: ' + err
            }
            else {
                res.status(200);
                res.end();
                //res.redirect('/users');
            }
        });
    },
};