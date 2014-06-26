'use strict'

var CanvasWrapper = (function(){
    var ctx,
        canvasWidth,
        canvasHeight;

    function init(selector,color){
        var canvas = document.querySelector(selector);
        canvasWidth = canvas.width;
        canvasHeight = canvas.height;
        ctx = canvas.getContext("2d");
        ctx.fillStyle = color;
        ctx.strokeStyle = color;
    }

    function validateContext(){
        if(!(ctx instanceof CanvasRenderingContext2D)){
            throw "Canvas Context is not initialized";
        }
    }

    function validateRect(x,y,width,height){
        if(x<0 || y<0 || x+width > canvasWidth || y+height >canvasHeight){
            throw "Invalid rectangle parameters";
        }
    }

    function validateCircle(x,y,r){
        if(x-r<0 || y-r<0 || x+r > canvasWidth || y+r >canvasHeight){
            throw "Invalid circle parameters";
        }
    }

    function validateLine(x1,y1,x2,y2){
        if(x1<0 || y1<0 || x1 > canvasWidth || y1 >canvasHeight ||
            x2<0 || y2<0 || x2 > canvasWidth || y2 >canvasHeight){
            throw "Invalid line parameters";
        }
    }

    function Rect(x,y,width,height){
        if (!(this instanceof Rect)) {
            return new Rect(x, y, width, height);
        }

        validateContext();
        validateRect(x,y,width,height);

        this.x = x;
        this.y = y;
        this.width = width;
        this.height = height;
        ctx.fillRect(x,y,width,height);
    }

    function Circle(x,y,r){
        if (!(this instanceof Circle)) {
            return new Circle(x,y,r);
        }

        validateContext();
        validateCircle(x,y,r);

        this.x = x;
        this.y = y;
        this.r = r;

        ctx.beginPath();
        ctx.arc(x,y,r,0,Math.PI*2,true);
        ctx.fill();
        ctx.closePath();

    }

    function Line(x1,y1,x2,y2){
        if (!(this instanceof Line)) {
            return new Line(x1,y1,x2,y2);
        }

        validateContext();
        validateLine(x1,y1,x2,y2);
        ctx.beginPath();
        ctx.moveTo(x1,y1);
        ctx.lineTo(x2,y2);
        ctx.stroke();
        ctx.closePath();

    }

    return {
        init: init,
        Rect: Rect,
        Circle: Circle,
        Line: Line
    }
}())