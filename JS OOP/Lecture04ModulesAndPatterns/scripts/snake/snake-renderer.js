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

        return Renderer;
    }())
    return Renderer;
})