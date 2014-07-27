define(['http-requester'],function(httpRequester){
    'use strict';
    var DataPersister = (function(){
        var sessionUserName;

        function getAllPosts(){
            //returns promise
            return httpRequester.request('posts','GET');
        }

        function sendNewPost(post){
            //post validations. If it contains exaclty two arguments user and text

            //returns promise
            return httpRequester.request('posts','POST',post,{'Access-Control-Allow-Origin':'*'});
        }

        function userName(name){
            if(name !== null && name !== undefined){
                window.sessionStorage.setItem('UserName',name);
                sessionUserName = name;
            } else {
                return sessionUserName;
            }
        }

        return {
            posts : {
                getAll : getAllPosts,
                sendNew : sendNewPost
            },
            userName : userName

        }

    }());

    return DataPersister;
});