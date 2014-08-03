define(['http-requester','app-config','underscore'],function(httpRequester,appConfig){
    'use strict';
    var DataPersister = (function(){
        /*

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
*/

        function isLoggedIn(){
            if(localStorage.getItem('sessionKey')){
                return true;
            } else {
                return false;
            }
        }

        function userSession(sessionParams){
            if(sessionParams){
                localStorage.setItem('username',sessionParams.username);
                localStorage.setItem('sessionKey',sessionParams.sessionKey);
            } else {
                return {
                    username : localStorage.getItem('username'),
                    sessionKey : localStorage.getItem('sessionKey')
                }
            }
        }


        function register(userName,authCode,success,error){
            var body = {
                'username':userName,
                'authCode': authCode
            };
            httpRequester.post(appConfig.serviceRoot+'/user',body)
                .then(success,error);
        }

        function auth(userName,authCode,success,error){
            var body = {
                'username':userName,
                'authCode': authCode
            };
            httpRequester.post(appConfig.serviceRoot+'/auth',body)
                .then(success,error);;
        }

        function logout(sessionKey,success,error){
            httpRequester.put(appConfig.serviceRoot+'/user',sessionKey)
                .then(success,error);;
        }

        function getPosts(filter,success,error){
            httpRequester.get(appConfig.serviceRoot+'/posts'+filter)
                .then(success,error);;
        }

        function addNew(postContent,success,error){
            httpRequester.post(appConfig.serviceRoot+'/post',postContent,sessionKey)
                .then(success,error);;
        }

        return {
            user : {
                register : register,
                logout : logout
            },
            auth : auth,
            posts : {
                getPosts : getPosts,
                addNew : addNew
            },
            isLoggedIn : isLoggedIn,
            userSession : userSession

        }

    }());

    return DataPersister;
});