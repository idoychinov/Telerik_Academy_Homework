/// <reference path="jquery-2.1.1.min.js" />
window.onload = function () {
    (function ($) {
        var studentsList = [
            { firstName: "Peter", lastName: "Ivanov", grade: 3 },
            { firstName: "Milena", lastName: "Grigorova", grade: 6 },
            { firstName: "Gergana", lastName: "Borisova", grade: 12 },
            { firstName: "Boyko", lastName: "Petrov", grade: 7 },
        ];

        function generateTable(selector, data) {
            var $selectedElement = $(selector),
                $table = $("<table />"),
                $row = $("<tr />"),
                row;

            $row.append($("<th />").html("First name"))
                .append($("<th />").html("Last name"))
                .append($("<th />").html("Grade name"))
                .css("text-align","center");
            $table.append($row);

            $(data).each(function () {
                $row = $("<tr />");
                for (var i in this) {
                    $row.append($("<td />").html(this[i]));
                }
                $table.append($row);

            });

            $selectedElement.append($table).find("table, th, td")
                .css("border", "1px solid black")
                .css("border-collapse", "collapse");
        }

        generateTable("div", studentsList);
    }(jQuery));
};