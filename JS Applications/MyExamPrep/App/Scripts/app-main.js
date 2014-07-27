(function() {
    'use strict'
    require.config({
        paths: {
            'jquery' : 'Libs/jquery-2.1.1',
            'underscore' : 'Libs/underscore',
            'sammy' : 'Libs/sammy',
            'mustache': 'Libs/sammy.mustache',
            'app-config' : 'Config/app-config',
            'init' : 'Config/init',
            'data-persister' : 'Models/data-persister',
            'http-requester' : 'Models/http-requester',
            'main-controler' : 'Controlers/main-controler'
        }
    })

    require(['main-controler'],function(mainControler){
       mainControler.runApp();
    })

}());