(function() {
    'use strict'
    require.config({
        paths: {
            'jquery' : 'Libs/jquery-2.1.1',
            'underscore' : 'Libs/underscore',
            'sammy' : 'Libs/sammy',
            'mustache': 'Libs/mustache',
            'rsvp':'Libs/rsvp-latest.amd',
            'app-config' : 'Config/app-config',
            'init' : 'Config/init',
            'views' : 'Views/view',
            'data-persister' : 'Models/data-persister',
            'http-requester' : 'Models/http-requester',
            'main-controller' : 'Controllers/main-controller'

        }
    })

    require(['jquery','sammy','main-controller','app-config'],function($,Sammy,mainController,appConfig){

        Sammy(appConfig.appContainer, function () {
            this.get('#/home', function ($context) {
                mainController.homePage($context.$element())
            });

            this.get('#/login', function ($context) {
                mainController.logInPage($context.$element())
            });

            this.get('#/register', function ($context) {
                mainController.registerPage($context.$element())
            });

            this.get('#/addPost', function ($context) {
                mainController.addPostPage($context.$element())
            });
            this.get(/.*/,function ($context) {
                mainController.notFound($context.$element())
            });

            mainController.registerEvents(this);


        }).run('#/home');



    })

}());