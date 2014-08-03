define(['jquery','rsvp'],function($,RSVP){
    'use strict';
    var HttpRequester;
    HttpRequester= (function(){

        function request(requestParams){
            var promise = new RSVP.Promise(function (resolve, reject) {

                requestParams.success = function (data) {
                    resolve(data);
                };

                requestParams.error =function (err) {
                    reject(err);
                }

                $.ajax(requestParams);
            });
            return promise;
        }

        function get(requestURL){
            var requestParams={
                url: requestURL,
                type: 'GET',
                contentType: "application/json"
            };

            return request(requestParams);

        }

        function post(requestURL,data,sessionKey){
            var requestParams={
                url: requestURL,
                type: 'POST',
                contentType: "application/json",
                data: JSON.stringify(data)
            };

            if(sessionKey){
                requestParams.beforeSend = function(xhr) {
                    xhr.setRequestHeader("X-SessionKey", sessionKey);
                }
            }
            return request(requestParams);
        }

        function put(requestURL,sessionKey){
            var requestParams={
                url: requestURL,
                type: 'PUT',
                contentType: "application/json",
                data: 'true'
            };

            if(sessionKey){
                requestParams.beforeSend = function(xhr) {
                    xhr.setRequestHeader("X-SessionKey", sessionKey);
                }
            }
            return request(requestParams);
        }

        return {
            get : get,
            post : post,
            put : put
        }

    }());

    return HttpRequester;
});