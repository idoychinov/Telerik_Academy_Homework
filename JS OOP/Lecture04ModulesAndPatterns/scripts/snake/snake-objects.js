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
        }

        function SnakeBodyPart(x,y) {
            GameObject.call(this,x,y);
            this.next = null;
            this.color = 'black';
        }

        SnakeBodyPart.prototype = new GameObject();

        function SnakeHeadPart(x,y) {
            GameObject.call(this,x,y);

            this.next = null;
            this.color = 'red';
        }

        SnakeHeadPart.prototype = new GameObject();

        function Snake(x,y,size,direction) {
            var previous,
                current,
                i;
            GameObject.call(this,x,y);
            this.direction = direction;
            this.head = new SnakeHeadPart(x,y);
            previous = this.head;
            for ( i = 1; i<size; i++){
                current = new SnakeBodyPart(x-i,y);
                previous.next = current;
                previous = current;
            }
            this.tail = previous;
        }

        Snake.prototype = new GameObject();

        Snake.prototype.move = function(){
            var next = this.head.next,
                prev =this.head;
            this.head.next= new SnakeBodyPart(this.head.x,this.head.y);
            this.head.next.next = next;
            this.head.x += directions[this.direction].x;
            this.head.y += directions[this.direction].y;


            if(next){
                if(next.next) {
                    prev = next;
                    next = next.next;
                } else
                {
                    prev.next=null;
                }
            }


        }

        function Food() {

        }

        Food.prototype = new GameObject();

        return {
            Snake: Snake,
            Food: Food
        }
    }())
    return GameObjects;
})