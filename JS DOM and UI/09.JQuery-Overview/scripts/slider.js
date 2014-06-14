/// <reference path="jquery-2.1.1.min.js" />
(function ($) {
    function slider(selector, interval, elements) {
        var currentIndex = 0,
            $slider = $(selector),
            $next,
            $prev,
            intervalTimer,
            isSlideShow = !isNaN(interval) && interval > 0;

        $slider.css("margin", "200px"); // to be removed, not part of the functionality. Used just for easy initial positioning in order to show the slider.

        $(elements).each(function () {
            $("<div />")
                .append(this)
                .addClass("slide")
                .css("position", "absolute")
                .hide()
                .appendTo($slider);
        });

        $next = $("<input />")
            .attr("type", "button")
            .attr("id", "next-slide")
            .attr("value", "Next")
            .on("click", nextSlide);
        $slider.after($next);
        $prev = $("<input />")
            .attr("type", "button")
            .attr("id", "prev-slide")
            .attr("value", "Prev")
            .on("click", previousSlide);
        $slider.after($prev);

        $slider.children().first().show();

        if(isSlideShow){
            startSlideshow();
        }

        function startSlideshow() {
            if(intervalTimer){
                clearInterval(intervalTimer);
            }
            if (isSlideShow) {
                intervalTimer = setInterval(nextSlide,interval*1000)
            }
        }

        function nextSlide() {
            $($slider.children()[currentIndex]).hide();
            currentIndex = (currentIndex + 1) % $slider.children().length;
            $($slider.children()[currentIndex]).show();
            if (isSlideShow) {
                startSlideshow();
            }
        }

        function previousSlide() {
            $($slider.children()[currentIndex]).hide();
            if (currentIndex == 0) {
                currentIndex = $slider.children().length - 1;
            } else {
                currentIndex = (currentIndex - 1) % $slider.children().length;
            }
            $($slider.children()[currentIndex]).show();
            if (isSlideShow) {
                startSlideshow();
            }
        }
    }

    window.onload = function () {
        var selector = "#slider-control",
        interval = 2,
        elements = ['<h1>Test</h1>',
            '<img src="jquery-mark-dark.gif" alt="logo" />',
            '<ul><li><a href="#">link</a></li><li>text</li></ul>'
        ];

        slider(selector, interval, elements);
    };

}(jQuery));