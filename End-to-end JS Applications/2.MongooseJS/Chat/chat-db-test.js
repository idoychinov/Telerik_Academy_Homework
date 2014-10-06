'use strict';

var chatDb = require("./chat-db");

chatDb.registerUser({name: 'Guncho', pass:'123456'}, function(){
    chatDb.registerUser({name: 'Muncho', pass:'123456'},function(){
        chatDb.sendMessage({from: 'Guncho', to: 'Muncho', text : 'Just testing'}, viewMessages);
    });
});

function viewMessages() {
    chatDb.getMessages({with: 'Guncho', and: 'Muncho'}, function (error, result) {
        for (var i in result) {
            var message = result[i];
            console.log('{ From: '+message.from.username + ' To: '+message.to.username + ' Text: '+message.text + ' Send at: '+message.time)+ ' }';
            chatDb.exit();
        }
    })
}
