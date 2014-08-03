define(function(){
    'use strict';
    var AppConfig;

    AppConfig = (function(){

        return{
            serviceRoot : 'http://localhost:3000',
            appContainer : "#main-container"
        }
    }());

    return AppConfig;
});