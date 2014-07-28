define(['jquery','underscore','app-config'],function($,_,config){
    'use strict';
    var HttpRequester;

        HttpRequester= (function(){

        function httpRequest(resource,requestType,requestData){
            var requestSettings,
                fullURL,
                url,
                port;

            if(!_.contains(['POST','GET','DELETE','PUT'],requestType)){
                throw new RangeError('Invalid request type');
            }

            port = config.dataSources.port.toString();
            if(port){
                port = ':'+port;
            }

            url = config.dataSources.server.toString();

            fullURL = url+port+resource;

            requestSettings ={
                url: fullURL,
                type : requestType,
                contentType : 'application/json',
                timeout:5000
            };

            if(requestData !==null && requestData !==undefined){
                requestSettings.data=JSON.stringify(requestData);
            }

            return $.ajax(requestSettings);
        }

        return {
            request : httpRequest
        }
    }());

    return HttpRequester;
});