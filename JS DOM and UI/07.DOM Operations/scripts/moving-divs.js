window.onload = function () {
    /* 2.Write a script that creates 5 div elements and moves them in circular path with
        interval of 100 milliseconds*/

    var angle = 0,
        timer;

    function MoveDivs() {
        var currentAngle, divOffset;
        var divs = document.getElementsByTagName("div");
        for (var i = 0, length = divs.length; i < length; i++) {
            divOffset = (i * 72) - 18; // angle offset for each dive. Currently calculated for 5 divs 360/5 = 72 degrees offset and additional -18 to center the divs at page load.
            currentAngle = (Math.PI * (angle + divOffset)) / 180;
            divs[i].style.left = (Math.cos(currentAngle) * 200 + 500) + "px";
            divs[i].style.top = (Math.sin(currentAngle) * 200 + 300) + "px";;
        }
        angle += 1;

    }

    function StartAnimation() {
        document.getElementById("start").style.display = "none";
        document.getElementById("stop").style.display = "block";
        timer = setInterval(MoveDivs, 100);
    }

    function StopAnimation() {
        document.getElementById("start").style.display = "block";
        document.getElementById("stop").style.display = "none";
        clearInterval(timer);
    }


    (function () {
        MoveDivs();
        document.getElementById("start").addEventListener('click', StartAnimation);
        document.getElementById("stop").addEventListener('click', StopAnimation);

    })()
}