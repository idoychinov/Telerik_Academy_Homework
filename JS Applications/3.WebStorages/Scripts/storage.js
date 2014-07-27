define(function(){
    'use strict';
    var Storage;
    Storage = (function(){
        if (!String.prototype.startsWith) {
            String.prototype.startsWith = function(str) {
                if (this.length < str.length) {
                    return false;
                }
                for (var i = 0; i < str.length; i++) {
                    if (this[i] !== str[i]) {
                        return false;
                    }
                }
                return true;
            }
        }

        if (!window.Storage.prototype.setObject) {
            window.Storage.prototype.setObject = function setObject(key, obj) {
                var jsonObj = JSON.stringify(obj);
                this.setItem(key, jsonObj);
            };

        }
        if (!window.Storage.prototype.getObject) {
            window.Storage.prototype.getObject = function getObject(key) {
                var jsonObj = this.getItem(key);
                return JSON.parse(jsonObj);
            };
        }

        function readCookie(name) {
            var allCookies = document.cookie.split(";");
            for (var i = 0; i < allCookies.length; i++) {
                var cookie = allCookies[i];
                for (var j = 0; j < cookie.length; j++) {
                    if (cookie[j] !== " ") {
                        break;
                    }
                }
                cookie = cookie.substring(j);
                if (cookie.startsWith(name + "=")) {
                    return cookie;
                }
            }
        }

        function createCookie(name, value, days) {
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                var expires = "; expires=" + date.toGMTString();
            } else var expires = "";
            document.cookie = name + "=" + value + expires + "; path=/";
        }

        function removeCookie(name) {
            createCookie(name, "", -1);
        }

        return {
            readCookie:readCookie,
            createCookie:createCookie,
            removeCookie:removeCookie
        };


    }());

    return Storage;
});
