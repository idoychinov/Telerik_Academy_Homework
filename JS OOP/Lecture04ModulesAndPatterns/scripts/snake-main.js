var SnakeMain = function () {
    function startGame(){
        var canvas;
        canvas = document.getElementById("snake-game-canvas");
        console.log(canvas);
    }

    return {
        startGame: startGame
    }

}();

SnakeMain.startGame();