define(['http-requester'],function(httpRequester){
    'use strict';
    var DataPersister = (function(){

        function getAllStudent(){
            //returns promise
            return httpRequester.request('/students','GET');
        }

        function addNewStudent(student){
            return httpRequester.request('/students','POST',student);
        }

        function deleteStudent(id){
            return httpRequester.request('/students/'+id,'DELETE');
        }

        return {
            students : {
                getAll : getAllStudent,
                add : addNewStudent,
                del : deleteStudent
            }
        }

    }());

    return DataPersister;
});