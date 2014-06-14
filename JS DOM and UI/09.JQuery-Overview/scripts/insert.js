/// <reference path="jquery-2.1.1.min.js" />
window.onload = function () {
    (function ($) {
        function insertElement(selector, element, insertBefore) {
            $selectedElement = $(selector);
            if (insertBefore) {
                $selectedElement.before(element);
            } else {
                $selectedElement.after(element);
            }
        }

        insertElement("#insert-after", "<div>Inserted after second div</div>", false);
        insertElement("#insert-before", "<div>Inserted before fifth div</div>", true);

    }(jQuery));
};