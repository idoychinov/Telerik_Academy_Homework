/// <reference path="jquery-2.1.1.min.js" />
window.onload = function () {
    (function ($) {

        $.fn.dropdown = function () {
            var $this = $(this),
                $listContainer,
                $listOptions,
                $option;

            //$this.hide();

            $listContainer = $("<div />")
                .addClass("dropdown-list-container")

            $listOptions = $("<ul />")
                .addClass("dropdown-list-options")
                .css("list-style-type","none")
                .on("click", "li", onOptionSelect)
                .appendTo($listContainer);

            $this.children().each(function () {
                $option = $(this);
                $("<li />")
                .addClass("dropdown-list-option")
                .attr("data-value", $option.val())
                .html($option.html())
                .appendTo($listOptions);
            })

            $this.after($listContainer);

            function onOptionSelect() {
                $this.children("option[value=" + $(this).attr("data-value") + "]")
                    .attr("selected", "selected");
            }

            return $this;
        }

        $("#dropdown").dropdown();

    }(jQuery));
}