define(['jquery','sammy','mustache','data-persister','underscore'],function($,Sammy,Mustache,persister,_){
    'use strict';
    var MainController;
    MainController = (function(){

        function loadHomePage($context) {
            $.get('Views/home-template.html')
                .then(function(template){
                    var renderedTemplate,
                        userNameObject,
                        userName = persister.userName();

                    if(userName){
                        userNameObject = {
                            userName : userName
                        }
                    }

                    renderedTemplate = Mustache.to_html(template,userNameObject);
                    $context.$element().html(renderedTemplate);
                });
        }

        function loadChatRoom($context){
            if(persister.userName()){
                $.get('Views/chat-room-template.html')
                    .then(function (template) {
                        var renderedTemplate,
                            userNameObject,
                            userName = persister.userName();

                        if (userName) {
                            userNameObject = {
                                userName: userName
                            }
                        }

                        renderedTemplate = Mustache.to_html(template, userNameObject);
                        $context.$element().html(renderedTemplate);
                        loadChatHistory($('#chat-history'));
                    });
            } else {
               $context.redirect('#/home');
            }
        }

        function registerEvents($container){

            $container.on('click','#enter-chatroom',function(){
                var userName = $container.find('#user-name').val();
                if (userName.length > 0){
                    persister.userName(userName);
                } else if(persister.userName()) {
                }
                else {
                    alert("Please enter non empty user name");
                    return false;
                }
            });

            $container.on('click','#send-message',function(){
                persister.posts.sendNew({
                    user: persister.userName(),
                    text: $('#chat-message').val()
                }).then(function(){
                        loadChatHistory($('#chat-history'));
                    });
            })
        }

        function loadChatHistory($element){

            persister.posts.getAll()
                .then(function(data){
                    var messageHistory;
                    messageHistory = _.map(data, function(message){
                        return message.by +' : '+ message.text + '\n';
                    })
                    $element.html(messageHistory);
                    $element.scrollTop($element[0].scrollHeight);
                });
        }

        return {
            loadHomePage : loadHomePage,
            loadChatRoom : loadChatRoom,
            registerEvents : registerEvents
        }

    }());

    return MainController;
});