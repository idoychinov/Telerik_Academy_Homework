define(['snake/snake-engine'], function (Engine) {
    var SnakeMain;
    SnakeMain = (function(){
        function SnakeMain(canvasID){
            this._canvasID = canvasID;
        }
        SnakeMain.prototype.startGame = function (){
            var engine = new Engine(this._canvasID);
            engine.start();
        }
        return SnakeMain;
    }())
    return SnakeMain;
});