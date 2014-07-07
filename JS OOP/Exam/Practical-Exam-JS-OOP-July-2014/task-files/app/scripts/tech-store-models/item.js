define(function() {
    'use strict';
    var Item;
    Item = (function() {
        var ALLOWED_TYPES =[
            'accessory',
            'smart-phone',
            'notebook',
            'pc',
            'tablet'
        ],
            MIN_NAME_CHARACTERS = 6,
            MAX_NAME_CHARACTERS = 40;

        function validateType(type){
            var isValidType = false,
                i;
            for(i=0; i<ALLOWED_TYPES.length; i++){
                if(type === ALLOWED_TYPES[i]){
                    isValidType=true;
                }
            }
            if(!isValidType){
                throw new TypeError('Invalid item type')
            }
            return type;
        }

        function validateName(name){
            if((typeof name !== 'string')|| name.length<MIN_NAME_CHARACTERS || name.length>MAX_NAME_CHARACTERS) {
                throw new TypeError('Name must be a string with length between 6 and 30 characters');
            }
            return name;
        }

        function validatePrice(price){
            if(isNaN(price)) {
                throw new TypeError('Price must be a decimal floating point number')
            }
            return price;
        }

        function Item(type, name, price) {
            this._type = validateType(type);
            this._name = validateName(name);
            this._price = validatePrice(price);
        }

        Item.prototype.getType = function(){
            return this._type;
        };

        Item.prototype.getName = function(){
            return this._name;
        };

        Item.prototype.getPrice = function(){
            return this._price;
        };

        return Item;
    })();
    return Item;
});