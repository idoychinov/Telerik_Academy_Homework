define(['jquery','sammy','mustache','data-persister','underscore'],function($,Sammy,Mustache,persister,_){
    'use strict';
    var MainController;
    MainController = (function(){

        // for some reason views doesn't want to register with define!!!
        function home($container,posts,isLogged,userName){

            loadNav($container,isLogged,userName)
                .then($.get('Templates/home-template.html')
                    .then(function (template) {
                        var renderedTemplate;
                        renderedTemplate = Mustache.to_html(template,posts);
                        $container.append(renderedTemplate);
                    }))
        }

        function login($container,isLogged){

            loadNav($container,isLogged)
                .then($.get('Templates/loggin-template.html')
                    .then(function (template) {
                        var renderedTemplate;
                        renderedTemplate = Mustache.to_html(template);
                        $container.append(renderedTemplate);
                    }))
        }

        function register($container,isLogged,userName){
            loadNav($container,isLogged,userName)
                .then($.get('Templates/register-template.html')
                    .then(function (template) {
                        var renderedTemplate;
                        renderedTemplate = Mustache.to_html(template);
                        $container.append(renderedTemplate);
                    }))
        }

        function notFound($container,isLogged,userName){
            loadNav($container,isLogged,userName)
                .then($.get('Templates/not-found-template.html')
                    .then(function (template) {
                        var renderedTemplate;
                        renderedTemplate = Mustache.to_html(template);
                        $container.append(renderedTemplate);
                    }))
        }

        function loadNav($container,isLogged,userName){
            return $.get('Templates/nav-template.html')
                .then(function (template) {
                    var renderedTemplate,
                        params ={
                            isLogged : isLogged,
                            userName : userName
                        }
                    renderedTemplate = Mustache.to_html(template,params);
                    $container.html(renderedTemplate);
                });
        }


        function homePage($container) {
            var posts={};

            home($container,posts,persister.isLoggedIn(),persister.userSession().username);

        }

        function notFoundPage($container) {
            notFound($container);
        }

        function logInPage($container) {
            login($container);
        }

        function registerPage($container) {
            register($container);
        }

        function addPostPage($container) {
            notFound($container);
        }

        function registerEvents($context){
            var $container = $context.$element();


            $container.on('click','#login-button',function(){

                var username = $('#user-name').val(),
                    password = $('#password').val(),
                    errorMessage =$('#error'),
                    authCode;
                errorMessage.html('');
                if(!username || username.length<6 || username.length>40){
                    errorMessage.html('username must be between 6 and 40 symbols')
                    return false;
                }
                if(!password || password.length<6){
                    errorMessage.html('password must be at least 6 symbols')
                    return false;
                }
                authCode = CryptoJS.SHA1(username+password).toString();
                persister.auth(username,authCode,
                function(data){
                    console.log(data);
                    persister.userSession(data.username,data.authKey);
                    window.location.href='#/home';
                },
                function(err){
                    errorMessage.html(JSON.parse(err.responseText).message);
                })
                return false;
            })

            $container.on('click','#register-button',function(){
                var username = $('#user-name').val(),
                    password = $('#password').val(),
                    errorMessage =$('#error'),
                    authCode;
                errorMessage.html('');
                if(!username || username.length<6 || username.length>40){
                    errorMessage.html('username must be between 6 and 40 symbols')
                    return false;
                }
                if(!password || password.length<6){
                    errorMessage.html('password must be at least 6 symbols')
                    return false;
                }
                authCode = CryptoJS.SHA1(username+password).toString();
                persister.user.register(username,authCode,
                    function(data){
                        window.location.href='#/home';
                    },
                    function(err){
                        errorMessage.html(JSON.parse(err.responseText).message);
                    })
                return false;
            })

            $container.on('click','#logout',function(){
                var authCode=persister.userSession().authCode,
                    errorMessage =$('#error');

                    persister.user.logout(authCode,
                    function(data){
                        persister.userSession({username: '', authKey: ''});
                        window.location.href='#/home';
                    },
                    function(err){
                        errorMessage.html(JSON.parse(err.responseText).message);
                    })
                return false;
            })

        }


        return {
            homePage : homePage,
            notFoundPage : notFoundPage,
            logInPage : logInPage,
            registerPage : registerPage,
            addPostPage : addPostPage,
            registerEvents : registerEvents
        }

    }());

    return MainController;
});