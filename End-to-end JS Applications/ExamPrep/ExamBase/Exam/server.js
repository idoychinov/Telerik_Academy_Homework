var express = require('express');

var env = process.env.NODE_ENV || 'development';

var app = express();
var config = require('./server/config/config')[env];

require('./server/config/express')(app, config);
require('./server/config/mongoose')(config);
require('./server/config/passport')();
require('./server/config/routes')(app);

app.listen(config.port);
console.log("Server running on port: " + config.port);

//var enc = require('./server/utilities/encryption');

//var cipher = enc.encrypt('pesho', 'jljljl');
//console.log(enc.decrypt(cipher, 'jljljl'));
