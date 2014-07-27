define(['jquery','sammy','mustache','data-persister'],function($,Sammy,Mustache,persister){
    'use strict';
    var MainControler;
    MainControler= (function(){

        function runApp() {
            Sammy('#main', function () {

                /* persister.posts.sendNew({
                 user: 'Bender',
                 text: 'was here'
                 })
                 .then(function(data){
                 console.log(data);
                 });

                 persister.posts.getAll()
                 .then(function(data){
                 console.log(data);
                 });
                 */


                this.use('Mustache'),
                    this.get('#/home', function () {
                        this.userName = persister.userName();
                        this.partial('Views/home-template.html');
/*
                        $tempElement= $('<div/>').load('Views/home-template.html',function(){
                            var template,
                                user = persister.userName();
                            debugger;
                            template = Mustache.parse($tempElement.html());
                            self.$element().html(template(user))
                        });*/
                    }),
                    this.get(/.*/, function () {
                        this.$element().html('Page not found')
                    })

                registerEvents();

            }).run('#/home');
        }

        function registerEvents(){

        }

        return {
            runApp : runApp
        }

    }());

    return MainControler;
});