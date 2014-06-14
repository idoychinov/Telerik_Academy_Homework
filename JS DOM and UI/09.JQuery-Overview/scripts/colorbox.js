/// <reference path="jquery-2.1.1.min.js" />
window.onload = function () {
    (function ($) {
        var $colorPicker = $("#body-background");
        $colorPicker.parent().css("margin", "200px");
        $colorPicker.on("change", function () {
            $("body").css("background-color", $colorPicker.val());
        });
    }(jQuery));
};