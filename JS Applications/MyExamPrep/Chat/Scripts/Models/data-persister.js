define(['http-requester'],function(httpRequester){
    'use strict';
    var DataPersister = (function(){

        function getAllPosts(){
            //returns promise
            return httpRequester.request('posts','GET');
        }

        function sendNewPost(post){
            //post validations. If it contains exactly two arguments user and text

            //returns promise
            return httpRequester.request('posts','POST',post);
            //,{'Access-Control-Allow-Origin':'*'}
        }

        function userName(name){
            if(name !== null && name !== undefined){
                window.sessionStorage.setItem('UserName',name);
            } else {
                return window.sessionStorage.getItem('UserName');
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