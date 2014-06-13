/// <reference path="_references.js" />
"use strict";

window.onload = function () {
    var stage = new Kinetic.Stage({
        container: 'canvas-container',
        width: 800,
        height: 500
    });

    var layer = new Kinetic.Layer();
    var imageObj = new Image();
    imageObj.onload = function () {
        var marioSprite = new Kinetic.Sprite({
            x: 300,
            y: 353,
            image: imageObj,
            animation: 'idle',
            animations: {
                idle: [
                    99, 35, 101, 141,
                    227, 28, 111, 147,
                    374, 36, 101, 139,
                    484, 28, 147, 147,
                    649, 37, 101, 138
                ],
                jump: [
                    /*TODO*/
                ]
            },
            framerate: 7,
            frameIndex: 0,
            scaleX: 0.5,
            scaleY: 0.5
            
        })
        layer.add(marioSprite);
        stage.add(layer);
        marioSprite.start();
    };

    imageObj.src = "images/mario-8-bitdiagram.png";

    var paper = new Raphael(document.getElementById("svg-container"), 800, 500);

    var backgroundOne = paper.image("images/Mario_background.jpg", 0, 0, 800, 500);
    var backgroundTwo= paper.image("images/Mario_background.jpg", 750, 0, 800, 500);
    var currentOffset = 0;
    requestAnimationFrame(animateBackground);

    function animateBackground() {

    backgroundOne.attr({
        x: -currentOffset
    })
    
    backgroundTwo.attr({
        x: 800-currentOffset
    })
    currentOffset = (currentOffset+1) % 800;
    requestAnimationFrame(animateBackground);
    }

}