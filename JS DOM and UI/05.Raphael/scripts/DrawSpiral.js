/// <reference path="_reference.js" />
"use strict";
window.onload = function () {
    var paperS = Raphael(10, 10, 400, 300);
    var centralPoint = "M" + 250 + ' ' + 150,
        spiralPoints = [centralPoint];

    for (var i = 0; i < 720; i++) {
        var angle = 0.1 * i,
            x = 250 + (0 + 2 * angle) * Math.cos(angle),
            y = 150 + (0 + 2 * angle) * Math.sin(angle);

        spiralPoints.push('L ' + x + ' ' + y);

    }

    var spiralPointsStr = '';
    for (var point in spiralPoints) {
        spiralPointsStr += spiralPoints[point] +' ';
    }

    paperS.path(spiralPointsStr);
}