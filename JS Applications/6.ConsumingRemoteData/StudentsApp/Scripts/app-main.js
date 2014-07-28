(function() {
    'use strict'
    require.config({
        paths: {
            'jquery' : 'Libs/jquery-2.1.1',
            'underscore' : 'Libs/underscore',
            'sammy' : 'Libs/sammy',
            'mustache': 'Libs/mustache',
            'app-config' : 'Config/app-config',
            'init' : 'Config/init',
            'data-persister' : 'Models/data-persister',
            'http-requester' : 'Models/http-requester',
            'main-controller' : 'Controllers/main-controller'
        }
    })

    require(['jquery','sammy','main-controller','app-config'],function($,Sammy,mainController,appConfig){
        Sammy(appConfig.appContainer, function () {
            this.get('#/home', function ($context) {
                mainController.loadHomePage($context)
            });

            this.get(/.*/, function ($context) {
                $context.redirect('#/home')
            });

            mainController.registerEvents(this.$element());

        }).run('#/home');



    })

}());