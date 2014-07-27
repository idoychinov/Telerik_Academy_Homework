define(function(){
    'use strict';
    var AppConfig;

    AppConfig = (function(){
        var dataSources,
            menuMapping;

        dataSources ={
				server: 'http://crowd-chat.herokuapp.com',
				port: '',
				resources: {
                    'posts' : '/posts'
				}
			};

        menuMapping ={

        };

        return {
            dataSources : dataSources,
            menuMapping : menuMapping
        }
    }());

    return AppConfig;
});