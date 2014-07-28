define(['jquery','sammy','mustache','data-persister','underscore'],function($,Sammy,Mustache,persister,_){
    'use strict';
    var MainController;
    MainController = (function(){

        function loadHomePage($context) {
            $.get('Views/home-template.html')
                .then(function(template){
                    var renderedTemplate;
                    renderedTemplate = Mustache.to_html(template);
                    $context.$element().html(renderedTemplate);
                    persister.students.getAll()
                        .then(function(data){
                            var $list = $('#all-students');
                            for(var i=0; i< data.students.length;i++){
                                $('<li />')
                                    .html('Name: '+data.students[i].name+ ' Grade: '+data.students[i].grade)
                                    .data('student-id-data',data.students[i].id)
                                    .append($('<input class="delete-student" type="button" value="delete">'))
                                    .appendTo($list);
                            }
                        });
                });
        }



        function registerEvents($container){

            $container.on('click','#add-student',function(){
                var student={};

                student.name = $('#student-name').val();
                student.grade = $('#student-grade').val();
                console.log(student)

                persister.students.add(student).then(function(){
                    $('student-name').val('');
                    $('student-grade').val('');
                    $('<li />')
                        .html('Name: '+student.name+ ' Grade: '+student.grade)
                        .append($('<input class="delete-student" type="button" value="delete">'))
                        .appendTo($('#all-students'));
                })
            });

            $container.on('click','.delete-student',function(){
                var $parentLi = $(this).parent(),
                    id=$parentLi.data('student-id-data');
                persister.students.del(id).then(function(){
                    $parentLi.remove();
                })
            })
        }


        return {
            loadHomePage : loadHomePage,
            registerEvents : registerEvents
        }

    }());

    return MainController;
});