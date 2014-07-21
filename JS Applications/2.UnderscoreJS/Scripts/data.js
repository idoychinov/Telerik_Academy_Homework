define(function(){
    'use strict';
    var Data;
    Data = (function(){
        function Student(firstName,lastName,age,marks){
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.marks = marks;
        }

        Student.prototype.fullName = function(){
            return this.firstName + ' ' + this.lastName;

        }

        function Animal(species,legs){
            this.species = species;
            this.legs = legs;
        }

        function Book(name,author){
            this.name = name;
            this.author = author;
        }

        function Person (firstName, lastName){
            this.firstName = firstName;
            this.lastName = lastName;
        }

        var students = [
            new Student('Petur', 'Ivanov', 21, [5,3,5,6,4]),
            new Student('Mariq', 'Nikolaeva', 17, [6,3,4,5]),
            new Student('Dimitar', 'Vasilev', 18, [2,3,5,4,5]),
            new Student('Raia', 'Petrova', 23, [5,4,6,3,3]),
            new Student('Haralampi', 'Haralampiev', 29, [6,6,5,5,6])
        ];

        var animals = [
            new Animal('cow',4),
            new Animal('dog',4),
            new Animal('monkey',2),
            new Animal('bee',6),
            new Animal('cow',4),
            new Animal('spider',8),
            new Animal('centipede',100),
            new Animal('spider',8),
            new Animal('cat',4),
            new Animal('fly',6),
            new Animal('monkey',2),
        ];

        // Those are mostly series of books, but it's too late (01:00) to go and search for individual books :)
        var books = [
            new Book ('A Song of Fire and Ice','George R. R. Martin'),
            new Book ('The Lord of the Rings','J.R.R. Tolkein'),
            new Book ('Discworld','Terry Pratchet'),
            new Book ('The Hobbit','J.R.R. Tolkein'),
            new Book ('Mistborn', 'Branden Sanderson'),
            new Book ('The Wheel of Time', 'Robert Jordan'),
            new Book ('Malazan book of the fallen', 'Steven Erikson'),
            new Book ('Silmarillion','J.R.R. Tolkein'),
            new Book ('Elantris','Branden Sanderson')
        ];

        var people = [
            new Student('Petur', 'Ivanov'),
            new Student('Mariq', 'Nikolaeva'),
            new Student('Dimitar', 'Vasilev'),
            new Student('Raia', 'Petrova'),
            new Student('Haralampi', 'Haralampiev')
        ];

        return {
            students : students,
            animals : animals,
            books : books,
            people : people
        }
    }());

    return Data;
});
