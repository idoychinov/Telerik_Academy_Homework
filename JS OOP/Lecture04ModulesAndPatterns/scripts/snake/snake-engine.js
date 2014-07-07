define(['snake/snake-objects','snake/snake-renderer'],function(Objects,Renderer) {
    'use strict'
    var Engine;

    Engine = (function() {
        var TILE_SIZE = 10,
            TOTAL_HORIZONTAL_TILES=100,
            TOTAL_VERTICAL_TILES = 50,
            SNAKE_START_SIZE= 5,
            DELLEY = 4;

        function generateRandomFood(snake){
            var x,
                y,
                i,
                snakePart,
                inSnake;

            do {
                inSnake = false;
                x = Math.floor(Math.random() * TOTAL_HORIZONTAL_TILES);
                y = Math.floor(Math.random() * TOTAL_VERTICAL_TILES);

                snakePart=snake.head;
                for(i=0; i< snake.size;i++){
                    if(x===snakePart.x && y === snakePart.y){
                        inSnake = true;
                        break;
                    }
                    snakePart = snakePart.next;
                }

            } while(inSnake)
            return new Objects.Food(x,y);
        }

        function Engine(canvasID) {
            this._canvas = document.getElementById(canvasID);
            this._canvas.width = TILE_SIZE*TOTAL_HORIZONTAL_TILES;
            this._canvas.height = TILE_SIZE*TOTAL_VERTICAL_TILES+100;
            this._renderer = new Renderer(canvasID,{tileSize:TILE_SIZE, horizontal_tiles:TOTAL_HORIZONTAL_TILES, verticalTiles: TOTAL_HORIZONTAL_TILES});
            this._snake = new Objects.Snake(TOTAL_HORIZONTAL_TILES/2,TOTAL_VERTICAL_TILES/2,SNAKE_START_SIZE,0);
            this._lives =3;
            this._points =0;
            this._food=generateRandomFood(this._snake);
        }

        Engine.prototype.start = function(){
            var animation,
                renderer=this._renderer,
                snake=this._snake,
                pause=false,
                food =this._food,
                lives = this._lives,
                points = this._points,
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

            })

            renderer.drawStats(this._snake.size,this._lives,this._points);
            animation = window.requestAnimationFrame(gameLoop);

            function gameLoop(){
                if(pause)
                {
                   return;
                }
                renderCycle = (renderCycle +1)%DELLEY;
                if(!renderCycle) {
                    renderer.enqueForDelete(snake);
                    renderer.executeDelete();
                    snake.move();

                    if(snake.head.x<0 || snake.head.x>=TOTAL_HORIZONTAL_TILES || snake.head.y<0 || snake.head.y>=TOTAL_VERTICAL_TILES){
                        snake = new Objects.Snake(TOTAL_HORIZONTAL_TILES/2,TOTAL_VERTICAL_TILES/2,SNAKE_START_SIZE,0);
                        lives=lives-1;
                        renderer.drawStats(snake.size,lives,points);
                        if(lives === 0){
                            renderer.drawGameOver();
                            return;
                        }
                    }

                    if(snake.head.x === food.x && snake.head.y=== food.y){
                        snake.size++;
                        food=generateRandomFood(snake);

                        points+=10;
                        renderer.drawStats(snake.size,lives,points);
                    } else {
                        //no food found
                        var tail = snake.tail;
                        snake.tail = snake.tail.prev;
                        snake.tail.next = null;
                        tail.prev = null;
                    }

                    renderer.enqueForRender(snake);
                    renderer.enqueForRender(food);
                    renderer.executeRender();
                }
                window.requestAnimationFrame(gameLoop);
           }

        }



        return Engine;
    }())
    return Engine;
})