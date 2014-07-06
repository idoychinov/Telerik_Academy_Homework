define(['snake/snake-objects','snake/snake-renderer'],function(Objects,Renderer) {
    'use strict'
    var Engine;

    Engine = (function() {
        var TILE_SIZE = 10,
            TOTAL_HORIZONTAL_TILES=100,
            TOTAL_VERTICAL_TILES = 50,
            SNAKE_START_SIZE= 5,
            DELLEY = 2;


        function Engine(canvasID) {
            this._canvas = document.getElementById(canvasID);
            this._canvas.width = TILE_SIZE*TOTAL_HORIZONTAL_TILES;
            this._canvas.height = TILE_SIZE*TOTAL_VERTICAL_TILES+100;
            this._renderer = new Renderer(canvasID,{tileSize:TILE_SIZE, horizontal_tiles:TOTAL_HORIZONTAL_TILES, verticalTiles: TOTAL_HORIZONTAL_TILES});
            this._snake = new Objects.Snake(TOTAL_HORIZONTAL_TILES/2,TOTAL_VERTICAL_TILES/2,SNAKE_START_SIZE,0);
        }

        Engine.prototype.start = function(){
            var animation,
                renderer=this._renderer,
                snake=this._snake,
                next,
                pause=false,
                renderCycle=0;

            document.addEventListener('keydown',function(ev){
                var key = ev.keyCode || window.event.keyCode;

                switch (key)
                {
                    case 37:
                        if(snake.direction !== 0) {
                            snake.direction = 2;
                        }
                        break;
                    case 38:
                        if(snake.direction !== 1) {
                            snake.direction = 3;
                        }
                        break;
                    case 39:
                        if(snake.direction !== 2) {
                            snake.direction = 0;
                        }
                        break;
                    case 40:
                        if(snake.direction !== 3) {
                            snake.direction = 1;
                        }
                        break;
                    case 27:
                        pause = !pause;
                        if(!pause){
                            animation = window.requestAnimationFrame(gameLoop);
                        }
                        break;
                }

                console.log(snake.direction)
            })


            renderer.enqueForRender(snake);
            renderer.executeRender();

            animation = window.requestAnimationFrame(gameLoop);

            function gameLoop(){
                if(pause)
                {
                   return;
                }
                renderCycle= (renderCycle +1)%DELLEY;
                if(!renderCycle) {
                    renderer.enqueForDelete(snake);
                    renderer.executeDelete();
                    snake.move();
                    renderer.enqueForRender(snake);
                    renderer.executeRender();
                }
                window.requestAnimationFrame(gameLoop);
           }

        }



        return Engine;
    }())
    return Engine;
})