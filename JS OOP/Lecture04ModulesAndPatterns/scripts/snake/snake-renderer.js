define(['snake/snake-objects'],function(Objects) {
    'use strict'
    var Renderer;
    Renderer = (function() {
        var BACKGROUND_COLOR = 'green';

        function Renderer(canvasID, tileSettings) {
            var canvas;

            canvas = document.getElementById(canvasID);
            this.ctx = canvas.getContext('2d');
            this.ctx.beginPath();
            this.ctx.fillStyle=BACKGROUND_COLOR;
            this.ctx.fillRect(0,0,canvas.width,canvas.height-100);
            this._tileSize = tileSettings.tileSize;
            this._horizontalTiles = tileSettings.horizontal_tiles;
            this._verticalTiles = tileSettings.verticalTiles;
            this._objectsToRender=[];
            this._objectsToDelete=[];
        }

        Renderer.prototype.enqueForRender = function(obj){
            if(obj instanceof Objects.Snake){
                var current = obj.head;
                while(current){
                    this._objectsToRender.push(current);
                    current = current.next;
                }
            }else {
                this._objectsToRender.push(obj);
            }
        }

        Renderer.prototype.enqueForDelete = function(obj){
            if(obj instanceof Objects.Snake){
                var current = obj.head;
                while(current){
                    this._objectsToDelete.push(current);
                    current = current.next;
                }
            }else {
                this._objectsToDelete.push(obj);
            }
        }

        Renderer.prototype.executeRender = function(){

            for(var obj in this._objectsToRender){
                var current = this._objectsToRender[obj];
                this.ctx.beginPath();
                this.ctx.fillStyle=current.color;
                this.ctx.fillRect(current.x*this._tileSize,current.y*this._tileSize,this._tileSize,this._tileSize);
            }
            this._objectsToRender=[];
        }

        Renderer.prototype.executeDelete = function(){

            for(var obj in this._objectsToDelete){
                var current = this._objectsToDelete[obj];
                this.ctx.beginPath();
                this.ctx.fillStyle=BACKGROUND_COLOR;
                this.ctx.fillRect(current.x*this._tileSize,current.y*this._tileSize,this._tileSize,this._tileSize);
            }

            this._objectsToDelete=[];
        }

        Renderer.prototype.drawStats = function(size,lives,points){
            this.ctx.fillStyle = 'blue';
            //to refactor with parameters not fixed values
            this.ctx.fillRect(0,500,1000,100);
            this.ctx.fillStyle = 'yellow';
            this.ctx.font="30px Georgia";
            this.ctx.fillText("Snake Size: "+size,50,540);
            this.ctx.fillText("Lives: "+lives,450,540);
            this.ctx.fillText("Points: "+points,750,540);
            this.ctx.font="18px Georgia";
            this.ctx.fillText("Esc for Pause",450,590);
        }

        Renderer.prototype.drawGameOver = function(){
            this.ctx.fillStyle = 'yellow';
            this.ctx.font="80px Georgia";
            this.ctx.fillText("Game Over",300,300);
        }

        return Renderer;
    }())
    return Renderer;
})