var auth = require('./auth'),
    controllers = require('../controllers');

module.exports = function(app) {
    app.get('/register', controllers.users.getRegister);
    app.post('/register', controllers.users.postRegister);

    app.get('/login', controllers.users.getLogin);
    app.post('/login', auth.login);
    app.get('/logout', auth.isAuthenticated, auth.logout);

    app.get('/users/:id', auth.isAuthenticated, controllers.users.getProfile);
    //app.post('/profile', auth.isAuthenticated, controllers.users.updateProfile);
    app.delete('/users/:id', auth.isInRole('admin'), controllers.users.deleteUser);
    app.post('/users/:id', auth.isAuthenticated, controllers.users.update);

    app.get('/users', auth.isInRole('admin'), controllers.users.getAll);


    app.get('/unauthorized', function (req, res) {
        res.render('unauthorized');
    });
    // app.get('/upload', auth.isAuthenticated, controllers.files.getUpload);
    // app.post('/upload', auth.isAuthenticated, controllers.files.postUpload);
    // app.get('/upload-results', auth.isAuthenticated, controllers.files.getResults);

    // app.get('/files/download/:id', controllers.files.download);
    
	app.get('/', function (req, res) {
        res.render('index');
    });

    app.get('*', function(req, res) {
        res.render('index');
    });
};