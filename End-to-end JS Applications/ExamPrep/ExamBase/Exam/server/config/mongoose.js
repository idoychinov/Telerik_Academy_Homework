var mongoose = require('mongoose'),
    mongooseCachebox = require('mongoose-cachebox'),
    UserModel = require('../data/models/User');
//cache
var options = {
    cache: true, // start caching
    ttl: 30 // 30 seconds
};

// adding mongoose cachebox
mongooseCachebox(mongoose, options);

module.exports = function(config) {
    mongoose.connect(config.db);
    var db = mongoose.connection;

    db.once('open', function(err) {
        if (err) {
            console.log('Database could not be opened: ' + err);
            return;
        }

        console.log('Database up and running...')
    });

    db.on('error', function(err){
        console.log('Database error: ' + err);
    });

    UserModel.init();
};