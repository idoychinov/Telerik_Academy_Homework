define(['jquery','underscore','app-config'],function($,_,config){
    'use strict';
    var HttpRequester;

        HttpRequester= (function(){

        function httpRequest(dataItem,requestType,requestData){
            var requestSettings,
                fullURL,
                url,
                port,
                resource;
            if(!_.has(config.dataSources.resources,dataItem)){
                throw new RangeError('Invalid data item type');
            }

            if(!_.contains(['POST','GET','DELETE','PUT'],requestType)){
                throw new RangeError('Invalid request type');
            }

            if(!requestData){
                requestData = '';
            }

            port = config.dataSources.port.toString();
            if(!port){
                port = ':'+port;
            }

            resource = config.dataSources.resources[dataItem];

            url = config.dataSources.server.toString();

            fullURL = url+port+resource;

            requestSettings ={
                url: fullURL,
                type : requestType,
                contentType : 'application/json',
                timeout:5000,
                data: JSON.stringify(requestData)
            };

            /*
            if(!requestHeaders){
                requestSettings.beforeSend =function(xhr) {
                       //to do for multiple headers
                       xhr.setRequestHeader(requestHeaders.header, requestHeaders.value);
                    };
            }
            */

            // returns promise
            return $.ajax(requestSettings);
        }

        return {
            request : httpRequest
        }
    }());

    return HttpRequester;
});