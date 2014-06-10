/// <reference path="_reference.js" />
"use strict";
window.onload = function () {
    var svgMean = createSVG("Mean", 800, 500);
    DrawMean(svgMean);
    var svgWin = createSVG("Windows8", 1055, 600);
    DrawWindows(svgWin);
    document.body.appendChild(svgMean);
    document.body.appendChild(svgWin);

}


function DrawMean(svg)
{
    var path, text, circle, image;

    circle = createCircle('450', '130', '60', '#3E3F37');
    svg.appendChild(circle);

    path = createPath('M 450 110 C420 130 450 160 450 160', '#5EB14A', '#5EB14A', 'none');
    svg.appendChild(path);

    path = createPath('M 450 110 C480 130 450 160 450 160', '#449644', '#449644', 'none');
    svg.appendChild(path);

    circle = createCircle('450', '200', '60', '#282827');
    svg.appendChild(circle);

    text = createText('405', '210', '24px', 'bold', 'Arial', '#F3F3F2', 'express')
    svg.appendChild(text);

    circle = createCircle('450', '270', '60', '#E23337');
    svg.appendChild(circle);

    path = createPath('M 450 250 L470 260 L450 330', '#B3B3B3', '#B63032', '2');
    svg.appendChild(path);

    path = createPath('M 450 250 L430 260 L450 330', '#B3B3B3', '#E23337', '2');
    svg.appendChild(path);

    path = createPath('M 430 310 L450 256 L470 310', '#F1F0F0', 'E23337', '3');
    svg.appendChild(path);

    path = createPath('M 432 310 L450 260 L450 310Z', 'none', '#E13638', 'none');
    svg.appendChild(path);

    path = createPath('M 450 310 L450 260 L468 310Z', 'none', '#B63032', 'none');
    svg.appendChild(path);

    circle = createCircle('450', '340', '60', '#8EC74E');
    svg.appendChild(circle);

    image = createImage('400', '315', '100', '50', 'images/node.jpg');
    svg.appendChild(image);

    text = createText('340', '150', '40px', 'bold', 'Arial', '#3E3F37', 'M')
    svg.appendChild(text);

    text = createText('340', '220', '40px', 'bold', 'Arial', '#231F20', 'E')
    svg.appendChild(text);

    text = createText('340', '290', '40px', 'bold', 'Arial', '#E23337', 'A')
    svg.appendChild(text);

    text = createText('340', '360', '40px', 'bold', 'Arial', '#8EC74E', 'N')
    svg.appendChild(text);
}

function DrawWindows(svg)
{
    var rect, text, path, image;

    rect = createRect('0', '0', '1058', '662', '#06173F', 'none');
    svg.appendChild(rect);

    text = createText('100', '80', '44', 'none', 'Segoe UI', '#B0BDD7', 'Start');
    svg.appendChild(text);

    text = createText('906', '67', '21.5', 'none', 'Arial', '#FFFFFF', 'Richard');
    svg.appendChild(text);

    text = createText('952', '84', '11.5', 'none', 'Arial', '#FFFFFF', 'Perry');
    svg.appendChild(text);

    rect = createRect('101', '154', '99', '99', '#2D89EE', 'none');
    svg.appendChild(rect);

    rect = createRect('206', '154', '99', '99', '#5BA51A', 'none');
    svg.appendChild(rect);

    rect = createRect('312', '154', '204', '99', '#AB1A3B', 'none');
    svg.appendChild(rect);

    rect = createRect('523', '154', '204', '99', '#008B18', 'none');
    svg.appendChild(rect);

    rect = createRect('101', '260', '99', '99', '#54429A', 'none');
    svg.appendChild(rect);

    rect = createRect('206', '260', '99', '99', '#2574EB', 'none');
    svg.appendChild(rect);

    rect = createRect('312', '260', '204', '99', '#54429A', 'none');
    svg.appendChild(rect);

    rect = createRect('523', '260', '204', '99', '#D14828', 'none');
    svg.appendChild(rect);

    rect = createRect('774', '154', '204', '99', '#54429A', 'none');
    svg.appendChild(rect);

    rect = createRect('774', '260', '204', '99', '#008B18', 'none');
    svg.appendChild(rect);

    rect = createRect('101', '365', '204', '99', '#D14828', 'none');
    svg.appendChild(rect);

    rect = createRect('312', '365', '204', '99', '#008B18', 'none');
    svg.appendChild(rect);

    rect = createRect('523', '365', '99', '99', '#000', 'none');
    svg.appendChild(rect);

    rect = createRect('629', '365', '99', '99', '#2D89EE', 'none');
    svg.appendChild(rect);

    rect = createRect('880', '365', '99', '99', '#012A6B', 'none');
    svg.appendChild(rect);

    rect = createRect('774', '365', '99', '99', '#D14828', 'none');
    svg.appendChild(rect);

    rect = createRect('986', '154', '72', '99', '#FFFFFF', 'none');
    svg.appendChild(rect);

    rect = createRect('986', '260', '72', '99', '#0071B3', 'none');
    svg.appendChild(rect);

    rect = createRect('986', '365', '72', '99', '#2D89EE', 'none');
    svg.appendChild(rect);

    rect = createRect('629', '470', '99', '99', '#5BA51A', 'none');
    svg.appendChild(rect);

    rect = createRect('523', '470', '99', '99', '#AB1A3B', 'none');
    svg.appendChild(rect);

    rect = createRect('312', '470', '204', '99', '#2D89EE', 'none');
    svg.appendChild(rect);

    rect = createRect('101', '470', '204', '99', '#1F7982', 'none');
    svg.appendChild(rect);

    rect = createRect('774', '470', '205', '99', '#BABCC2', 'none');
    svg.appendChild(rect);

    text = createText('115', '244', '9.5', 'none', 'Arial', '#FFFFFF', 'Store');
    svg.appendChild(text);

    text = createText('215', '244', '9.5', 'none', 'Arial', '#FFFFFF', 'XBox Live Games');
    svg.appendChild(text);

    text = createText('325', '244', '9.5', 'none', 'Arial', '#FFFFFF', 'Photos');
    svg.appendChild(text);

    text = createText('536', '244', '9.5', 'none', 'Arial', '#FFFFFF', 'Calendar');
    svg.appendChild(text);

    text = createText('656', '203', '56', 'none', 'Arial', '#FFFFFF', '12');
    svg.appendChild(text);

    text = createText('661', '214', '9', 'none', 'Arial', '#FFFFFF', 'monday');
    svg.appendChild(text);

    text = createText('115', '349', '9.5', 'none', 'Arial', '#FFFFFF', 'Maps');
    svg.appendChild(text);

    text = createText('218', '349', '9.5', 'none', 'Arial', '#FFFFFF', 'Internet Explorer');
    svg.appendChild(text);

    text = createText('325', '349', '9.5', 'none', 'Arial', '#FFFFFF', 'Messaging');
    svg.appendChild(text);

    text = createText('586', '286', '11.5', 'none', 'Arial', '#FFFFFF', 'Mike Gibbs, Troll Scout');
    svg.appendChild(text);

    text = createText('586', '300', '11.5', 'none', 'Arial', '#FFFFFF', 'and 5 others commented');
    svg.appendChild(text);

    text = createText('586', '314', '11.5', 'none', 'Arial', '#FFFFFF', 'on your photo.');
    svg.appendChild(text);

    text = createText('115', '455', '9.5', 'none', 'Arial', '#FFFFFF', 'Video');
    svg.appendChild(text);

    text = createText('325', '390', '19', 'none', 'Arial', '#FFFFFF', 'Devon Hypnotize');
    svg.appendChild(text);

    text = createText('325', '403', '10.5', 'none', 'Arial', '#FFFFFF', 'something they can do about him');
    svg.appendChild(text);

    text = createText('325', '415', '10.5', 'none', 'Arial', '#FFFFFF', 'pile of books and scrollnext to');
    svg.appendChild(text);

    text = createText('502', '456', '13.5', 'none', 'Arial', '#FFFFFF', '3');
    svg.appendChild(text);

    text = createText('640', '455', '9.5', 'none', 'Arial', '#FFFFFF', 'Solitaire');
    svg.appendChild(text);

    text = createText('115', '559', '9.5', 'none', 'Arial', '#FFFFFF', 'Desktop');
    svg.appendChild(text);

    text = createText('325', '559', '9.5', 'none', 'Arial', '#FFFFFF', 'Weather');
    svg.appendChild(text);

    text = createText('536', '559', '9.5', 'none', 'Arial', '#FFFFFF', 'Camera');
    svg.appendChild(text);

    text = createText('640', '559', '9.5', 'none', 'Arial', '#FFFFFF', 'Xbox Companion');
    svg.appendChild(text);

    text = createText('790', '244', '9.5', 'none', 'Arial', '#FFFFFF', 'Music');
    svg.appendChild(text);

    text = createText('790', '349', '9.5', 'none', 'Arial', '#FFFFFF', 'Finance');
    svg.appendChild(text);

    text = createText('790', '455', '9.5', 'none', 'Arial', '#FFFFFF', 'Reader');
    svg.appendChild(text);

    text = createText('890', '390', '16', 'none', 'Arial', '#FFFFFF', 'Windows');
    svg.appendChild(text);

    text = createText('890', '410', '16', 'none', 'Arial', '#FFFFFF', 'Explorer');
    svg.appendChild(text);

    text = createText('998', '455', '9.5', 'none', 'Arial', '#FFFFFF', 'SkyDrive');
    svg.appendChild(text);

    image = createImage('985', '50', '30', '30', 'images/ownPhoto.jpg');
    svg.appendChild(image);

    image = createImage('102', '430', '200', '180', 'images/fish.png');
    svg.appendChild(image);

    image = createImage('523', '365', '99', '99', 'images/pinBall.jpg');
    svg.appendChild(image);

    image = createImage('630', '365', '99', '99', 'images/solitare.jpg');
    svg.appendChild(image);

    image = createImage('515', '270', '80', '80', 'images/MikeGibbs.jpg');
    svg.appendChild(image);

    image = createImage('774', '470', '205', '99', 'images/WordPress.jpg');
    svg.appendChild(image);

    image = createImage('890', '430', '30', '30', 'images/WindowsExplorer.png');
    svg.appendChild(image);

    image = createImage('986', '154', '72', '99', 'images/2s.png');
    svg.appendChild(image);
    
    image = createImage('120', '170', '60', '60', 'images/store.png');
    svg.appendChild(image);

    image = createImage('215', '160', '80', '80', 'images/XboxLiveGames.png');
    svg.appendChild(image);

    image = createImage('840', '160', '80', '80', 'images/music.png');
    svg.appendChild(image);

    image = createImage('380', '160', '80', '80', 'images/photos.png');
    svg.appendChild(image);

    image = createImage('380', '265', '80', '80', 'images/messaging.png');
    svg.appendChild(image);

    image = createImage('120', '275', '60', '60', 'images/maps.png');
    svg.appendChild(image);

    image = createImage('215', '260', '80', '80', 'images/IE.png');
    svg.appendChild(image);

    image = createImage('840', '270', '80', '80', 'images/finance.png');
    svg.appendChild(image);

    image = createImage('165', '375', '80', '80', 'images/video.png');
    svg.appendChild(image);

    image = createImage('995', '375', '70', '70', 'images/skyDrive.png');
    svg.appendChild(image);

    image = createImage('785', '375', '70', '70', 'images/reader.png');
    svg.appendChild(image);

    image = createImage('375', '475', '80', '80', 'images/weather.png');
    svg.appendChild(image);

    image = createImage('530', '475', '80', '80', 'images/camera.png');
    svg.appendChild(image);

    image = createImage('640', '475', '80', '80', 'images/XBoxCompanion.png');
    svg.appendChild(image);
}