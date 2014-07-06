(function () {
    require(["snake/snake-main"], function(Snake){
        var snakeGame = new Snake('snake-game-canvas');
        snakeGame.startGame();
    });
}());

