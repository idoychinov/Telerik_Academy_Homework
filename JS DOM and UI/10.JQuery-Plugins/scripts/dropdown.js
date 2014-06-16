/// <reference path="jquery-2.1.1.min.js" />
window.onload = function () {
    (function ($) {

        $.fn.dropdown = function () {
            var $originalDropdown = $(this),
                $listContainer,
                $listOptions,
                $option;

            $originalDropdown.hide();

            $listContainer = $("<div />")
                .addClass("dropdown-list-container")

            $listOptions = $("<ul />")
                .addClass("dropdown-list-options")
                .css("list-style-type", "none")
                .css("border", "1px solid black")
                .css("padding", "2px")
                .css("display","inline-block")
                .on("click", "li", onOptionSelect)
                .appendTo($listContainer);

            $originalDropdown.children().each(function () {
                $option = $(this);
                $("<li />")
                .addClass("dropdown-list-option")
                .attr("data-value", $option.val())
                .html($option.html())
                .hide()
                .appendTo($listOptions);
            })

            $listOptions.children().first().show();
            $originalDropdown.after($listContainer);

            function onOptionSelect() {
                $originalDropdown.children().removeAttr("selected");
                $originalDropdown.children("option[value=" + $(this).attr("data-value") + "]")
                    .attr("selected", "selected");
                $listOptions.find(".dropdown-list-option").toggle();
                $(this).show();
            }

            return $originalDropdown;
        }

        $("#dropdown").dropdown();

    }(jQuery));
}