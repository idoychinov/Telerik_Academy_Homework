define(function() {
    'use strict'
    var GameObjects;

    GameObjects = (function() {
        var directions = [
            {x:1,y:0},
            {x:0,y:1},
            {x:-1,y:0},
            {x:0,y:-1}
        ]
        function GameObject(x, y) {
            this.x = x;
            this.y = y;
            this.color = 'white';
        }

        function SnakeBodyPart(x,y) {
            GameObject.call(this,x,y);
            this.next = null;
            this.prev = null;
            this.color = 'black';
        }

        SnakeBodyPart.prototype = new GameObject();

        function Snake(x,y,size,direction) {
            var previous,
                current,
                i;
            GameObject.call(this,x,y);
            this.direction = direction;
            this.head = new SnakeBodyPart(x,y);
            this.head.color ='red';
            previous = this.head;
            for ( i = 1; i<size; i++){
                current = new SnakeBodyPart(x-i,y);
                previous.next = current;
                current.prev = previous;
                previous = current;
            }
            this.tail = previous;
            this.size = size;
        }

        Snake.prototype = new GameObject();

        Snake.prototype.move = function(){
            var next = this.head.next,
                newPart;

            newPart = new SnakeBodyPart(this.head.x,this.head.y);
            next.prev = newPart;
            newPart.next = next;
            newPart.prev = this.head;
            this.head.next = newPart;

            this.head.x += directions[this.direction].x;
            this.head.y += directions[this.direction].y;
        }

        function Food(x,y) {
            GameObject.call(this,x,y);
            this.color = 'white';
        }

        Food.prototype = new GameObject();

        return {
            Snake: Snake,
            Food: Food
        }
    }())
    return GameObjects;
})