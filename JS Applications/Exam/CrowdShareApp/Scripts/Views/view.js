define(['jquery','mustache'],function($,Mustache){
    'use strict';
    var Views;
    Views = (function(){

        function home($container,posts,isLogged,userName){
            loadNav($container,isLogged,userName)
                .then($.get('Templates/home-template.html')
                    .then(function (template) {
                        var renderedTemplate;
                        renderedTemplate = Mustache.to_html(template,posts);
                        $container.append(renderedTemplate);
                    }))
        }

        function notFound($container,isLogged,userName){
            loadNav($container,isLogged,userName)
                .then($.get('Templates/not-found-template.html')
                    .then(function (template) {
                        var renderedTemplate;
                        renderedTemplate = Mustache.to_html(template);
                        $container.append(renderedTemplate);
                    }))
        }

        function loadNav($container,isLogged,userName){
            return $.get('Templates/nav-template.html')
                .then(function (template) {
                    var renderedTemplate,
                        params ={
                            isLogged : isLogged,
                            userName : userName
                        }
                    renderedTemplate = Mustache.to_html(template,params);
                    $container.html(renderedTemplate);
                });
        }

        return {
            home : home,
            notFound : notFound
        }
    }());
    return Views;
});