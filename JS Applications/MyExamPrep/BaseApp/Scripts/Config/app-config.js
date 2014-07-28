define(function(){
    'use strict';
    var AppConfig;

    AppConfig = (function(){
        var dataSources,
            menuMapping;
        // TODO make fluent api for resources and include menuMapping and data resource Mapping. Use _ to filter two objects each containing one of the two elements in order to provide separate interfaces.
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
            menuMapping : menuMapping,
            appContainer : "#main-container"
        }
    }());

    return AppConfig;
});