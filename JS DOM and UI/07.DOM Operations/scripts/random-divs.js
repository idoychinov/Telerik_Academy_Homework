﻿/* 1. Write a script that creates a number of div elements. Each div element must have the following
    Random width and height between 20px and 100px
    Random background color
    Random font color
    Random position on the screen (position:absolute)
    A strong element with text "div" inside the div
    Random border radius
    Random border color
    Random border width between 1px and 20px

    */

window.onload = function () {
    function CreateAllDivs() {
        var numberOfDivs = ((Math.random() * 9) | 0) + 1;
        for (var i = 1; i <= numberOfDivs; i++) {
            document.body.appendChild(CreateDiv());
        }

    }

    function CreateDiv() {
        var currentDiv = document.createElement("div");
        var height = Random(80, 20);
        currentDiv.style.height = height + "px";
        var width = Random(80, 20);
        currentDiv.style.width = width + "px";
        var red = Random(255);
        var green = Random(255);
        var blue = Random(255);
        currentDiv.style.backgroundColor = "rgb(" + red + "," + green + "," + blue + ")";
        red = Random(255);
        green = Random(255);
        blue = Random(255);
        currentDiv.style.color = "rgb(" + red + "," + green + "," + blue + ")";
        currentDiv.style.position = "absolute";
        var top = Random(window.innerHeight - height - 40);
        currentDiv.style.top = top + "px";
        var left = Random(window.innerWidth - width - 40);
        currentDiv.style.left = left + "px";
        var strongElement = document.createElement("strong");
        strongElement.innerHTML = "div";
        currentDiv.appendChild(strongElement);
        currentDiv.style.borderStyle = "solid";
        var borderRadius = Random(20);
        currentDiv.style.borderRadius = borderRadius + "px";
        red = Random(255);
        green = Random(255);
        blue = Random(255);
        currentDiv.style.borderColor = "rgb(" + red + "," + green + "," + blue + ")";
        var borderWidth = Random(19, 1);
        currentDiv.style.borderWidth = borderWidth + "px";

        return currentDiv;
    }

    function Random(interval, offset) {
        var randomNumber = Math.random();
        if (typeof (interval) !== "undefined" && !isNaN(interval)) {
            randomNumber = (randomNumber * interval) | 0;
        }
        if (typeof (offset) !== "undefined" && !isNaN(offset)) {
            randomNumber += offset;
        }

        return randomNumber;
    }
    CreateAllDivs();
};