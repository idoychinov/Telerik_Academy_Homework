/// <reference path="_reference.js" />
"use strict";
var svgNameSpace = "http://www.w3.org/2000/svg";
function createSVG(id, width, height) {
    var svg = document.createElementNS(svgNameSpace, "svg");
    if (id) {
        svg.setAttribute("id", id);
    }
    svg.setAttribute("width", width );
    svg.setAttribute("height", height );
    return svg;
}

function createPath(points, stroke, fill, strokeWidth) {
    var path;
    path = document.createElementNS(svgNameSpace, 'path');
    path.setAttribute('d', points);
    path.setAttribute('stroke', stroke);
    path.setAttribute('fill', fill);
    path.setAttribute('stroke-width', strokeWidth);
    return path;
}

function createCircle(x, y, r, fill) {
    var circle;
    circle = document.createElementNS(svgNameSpace, 'circle');
    circle.setAttribute('cx', x);
    circle.setAttribute('cy', y);
    circle.setAttribute('r', r);
    circle.setAttribute('fill', fill);
    return circle;
}

function createImage(x, y, width, height, href) {
    var image;
    image = document.createElementNS(svgNameSpace, 'image');
    image.setAttribute('x', x);
    image.setAttribute('y', y);
    image.setAttribute('width', width);
    image.setAttribute('height', height);
    image.setAttributeNS('http://www.w3.org/1999/xlink', 'xlink:href', href);
    return image;
}

function createText(x, y, fontSize, fontWeight, fontFamily, fill, value) {
    var text;
    text = document.createElementNS(svgNameSpace, 'text');
    text.setAttribute('x', x);
    text.setAttribute('y', y);
    text.setAttribute('font-size', fontSize);
    text.setAttribute('font-weight', fontWeight);
    text.setAttribute('font-family', fontFamily);
    text.setAttribute('fill', fill);
    text.textContent = value;
    return text;
}

function createRect(x, y, width, height, fill, stroke) {
    var rect;
    rect = document.createElementNS(svgNameSpace, 'rect');
    rect.setAttribute('x', x);
    rect.setAttribute('y', y);
    rect.setAttribute('width', width);
    rect.setAttribute('height', height);
    rect.setAttribute('fill', fill);
    rect.setAttribute('stroke', stroke);
    return rect;
}