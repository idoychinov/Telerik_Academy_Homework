'use strict';


var CONNECTION_STRING = 'mongodb://localhost:27017/ChatDB';

var mongoose = require('mongoose'),
    User = require('./models/user'),
    Message = require('./models/message');

var db;

function init(){
    if(db){
        return;
    }

    mongoose.connect(CONNECTION_STRING);
    db = mongoose.connection;
    db.on('error', console.error.bind(console, 'Connection error: '));
    db.once('open',function(error){
        if(error){
            console.error(error.message);
        }
    });
}

function sendMessage (messageData, callback){
    init();

    if(messageData == undefined || messageData.from == undefined || messageData.to == undefined)
    {
        console.error("Incorrect message data");
        return;
    }

    User.findOne({username: messageData.to},function(error,result){
        if(!result){
            return;}
        var to = result;


        User.findOne({username: messageData.from},function(error,result) {
            if(!result){
                return;}
            var from = result;

            var message = new Message({
                from : from._id,
                to: to._id,
                text: messageData.text || '',
                time : Date.now()
            });

            message.save(callback);
        });
    });
};


function registerUser (userData,callback){
    init();
    if(userData == undefined || userData.name == undefined || userData.pass == undefined)
    {
        console.error("Incorrect user data");
        return;
    }

    if(User.uniqueUsername(userData.name,function(){
        var user = new User({
            username: userData.name,
            password : userData.pass
        })

        return user.save(callback);
    }));
};

function getMessages (users,callback){
    init();
    if(users == undefined || users.with == undefined || users.and == undefined)
    {
        console.error("Incorrect users data");
        return;
    }

    var query = User.findOne({username: users.with}, function (error, result) {
        if(!result){
            return;}
        var first = result._id;

        User.findOne({username: users.and}, function (error, result) {
            if(!result){
                return;}

            var second = result._id;

            Message
                .find()
                .where('from').in([first, second])
                .where('to').in([first, second])
                .populate('from to')
                .exec(callback);
        });
    });

    return query;
};

module.exports = {

    registerUser : registerUser,
    sendMessage : sendMessage,
    getMessages : getMessages,
    exit : function(){
        db.close();
    }
}