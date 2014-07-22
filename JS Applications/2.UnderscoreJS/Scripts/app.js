(function() {
    'use strict';

    require.config({
        paths: {
            jquery: 'Libs/bower_components/jquery/dist/jquery',
            underscore: 'Libs/bower_components/underscore/underscore',
            handlebars: 'Libs/bower_components/handlebars/handlebars',
            tasks: 'tasks',
            data: 'data'
        },
        'shim' : {
            'handlebars': {
                exports: 'Handlebars'
            }
        }
    });

    require(['jquery', 'tasks', 'data', 'handlebars','underscore'], function ($, Tasks, Data, Handlebars,_) {
        var template,
            allTasks = [],
            singleElementResult =[],
            result,
            processedResult;
        //Task 1
        allTasks.push({
            name: 'Task 1',
            description: 'Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.Print the students in descending order by full name. Use Underscore.js',
            input: Data.students,
            output: Tasks.filterStudentsByName(Data.students)

        })

        //Task 2

        allTasks.push({
            name: 'Task 2',
            description: 'Write function that finds the first name and last name of all students with age between 18 and 24. Use Underscore.js',
            input: Data.students,
            output: Tasks.filterStudentsByAge(Data.students)

        })

        //Task 3

        singleElementResult.push(Tasks.getStudentWithHighestMarks(Data.students));
        allTasks.push({
            name: 'Task 3',
            description: 'Write a function that by a given array of students finds the student with highest marks',
            input: Data.students,
            output: singleElementResult
        })

        //Task 4

        result =  Tasks.groupAnimalsBySpeciesAndSortByLegs(Data.animals);
        processedResult = _.map(result, function(arr){
            return {
                'species' : arr[0].species,
                'count' : arr.length,
                'legs': arr[0].legs
            }
        })
        allTasks.push({
            name: 'Task 4',
            description: 'Write a function that by a given array of animals, groups them by species and sorts them by number of legs',
            input: Data.animals,
            output: processedResult

        })


        //Task 5
        singleElementResult= [];
        singleElementResult.push({
            totalLegs: Tasks.totalNumberOfLegs(Data.animals)
        });

        allTasks.push({
            name: 'Task 5',
            description: 'By a given array of animals, find the total number of legs',
            input: Data.animals,
            output: singleElementResult

        })

        //Task 6

        allTasks.push({
            name: 'Task 6',
            description: 'By a given collection of books, find the most popular author (the author with the highest number of books)',
            input: Data.books,
            output: Tasks.mostPopularAuthor(Data.books)

        })

        //Task 7

        allTasks.push({
            name: 'Task 7',
            description: 'By an array of people find the most common first and last name. Use underscore.',
            input: Data.people,
            output: Tasks.mostCommonNames(Data.people)

        })

        template = Handlebars.compile($('#tasks-template').html());
        $('#all-tasks').append(template({tasks: allTasks}));

    })
}())