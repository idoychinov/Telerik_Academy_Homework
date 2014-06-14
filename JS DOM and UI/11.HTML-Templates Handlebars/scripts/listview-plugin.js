/// <reference path="jquery-2.1.1.min.js" />
window.onload = function () {
    (function ($) {
        var books = [
            { id: 1, title: "JavaScript: The Good parts" },
            { id: 2, title: "Secrets of the Java Script Ninja" },
            { id: 3, title: "Core HTML5 Canvas" },
            { id: 4, title: "JavaScript Patterns" },
        ],
            students = [
                { number: 1, name: "Peter Petrov", mark: 5.5 },
                { number: 2, name: "Stamat Georgiev", mark: 4.7 },
                { number: 3, name: "Maria Todorova", mark: 6 },
                { number: 4, name: "Georgi Geshov", mark: 3.7 },
            ]

        $.fn.listview = function (collection) {
            var $this = $(this),
                $dataTemplate,
                template;

            if ($this.attr("data-template")) {
                $dataTemplate = $("[id=" + $this.attr("data-template") + "]");
            } else {
                //Task 4
                $dataTemplate = $this;
                console.log($this.html())
            }

            $dataTemplate.prepend("{{#each $reserved$For$Collection$}}");
            $dataTemplate.append("{{/each}}");

            template = Handlebars.compile($dataTemplate.html());
            $this.empty();
            $this.append(template({$reserved$For$Collection$ :collection}));
            return $this;
        }

        $("#books-list").listview(books);
        $("#students-table").listview(students);
        $('#students-table-inline').listview(students);

    }(jQuery));
}