define(['underscore'],function(_){
    'use strict';
    var Tasks;
    Tasks = (function(){
        var MIN_AGE = 18,
            MAX_AGE = 24;

        function filterStudentsByName(studnets){
            var result = _.chain(studnets)
                .filter(function(student){return student.firstName.toLowerCase() < student.lastName.toLowerCase()})
                .sortBy(function(student){return student.fullName();})
                .value()
                .reverse();
            return result;
        }

        function filterStudentsByAge(students){
            var result = _.chain(students)
                .filter(function(student){return student.age >=MIN_AGE && student.age<=MAX_AGE})
                .map(function(student) { return {firstName : student.firstName , lastName : student.lastName}})
                .value()
            return result;
        }

        function getStudentWithHighestMarks(students){
            var result = _.max(students,function(student){
                var totalMarks;
                totalMarks = _.reduce(student.marks,function(memo,mark){
                    return memo+mark;
                },0);
                return totalMarks;
            })

            return result;
        }

        function groupAnimalsBySpeciesAndSortByLegs(animals){
            var result = _.chain(animals)
                .groupBy('species')
                .sortBy(function(group){
                    return group[0].legs;
                })
                .value();

            return result;
        }

        function totalNumberOfLegs(animals){
            var result = _.reduce(animals,function(memo,animal){
                return memo+animal.legs;
            },0);

            return result;

        }


        function mostPopularAuthor(books){
            var result,
                counts,
                max;

            counts = _.countBy(books,'author');
            max = _.max(counts);

            // This way it works if there are more than one author with the max number of books;

            result = _.chain(counts)
                .pairs()
                .filter(function(author){
                    return author[1] == max;
                })
                .map(function(author){
                    return {
                        name: author[0],
                        books: author[1]
                    }
                })
                .value();
            return result;
        }

        function findMostCommonNames(people,nameType){
            var nameGroup,
                maxNameCount,
                mostCommonName;

            nameGroup = _.groupBy(people,nameType);

            maxNameCount= _.max(nameGroup,function(sameName){return sameName.length}).length;
            mostCommonName = _.chain(nameGroup)
                .filter(function(name){return name.length===maxNameCount })
                .map(function(name){return {
                    nameType : nameType,
                    name: name[0][nameType],
                    count: 2
                }})
                .value();
            return mostCommonName;
        }

        function mostCommonNames(people){

            return _.union(findMostCommonNames(people,'lastName'),findMostCommonNames(people,'firstName'));



        }

        return {
            filterStudentsByName : filterStudentsByName,
            filterStudentsByAge : filterStudentsByAge,
            getStudentWithHighestMarks : getStudentWithHighestMarks,
            groupAnimalsBySpeciesAndSortByLegs: groupAnimalsBySpeciesAndSortByLegs,
            totalNumberOfLegs: totalNumberOfLegs,
            mostPopularAuthor: mostPopularAuthor,
            mostCommonNames: mostCommonNames,
        }
    }());

    return Tasks;
});