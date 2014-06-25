var MovingDivs;
MovingDivs = function () {
    function add(selector,movementType){
        var $parent,
            createdDiv;

        $parent = $(selector);
        createdDiv = $("<div></div>")
            .addClass(".moving")

    }

    //get random number between min and max inclusive
    function getRandom(min,max){
        var randomNumber;
        if((typeof min !== "number") || (typeof min !== "number") || (min>=max)){
            throw "incorrect parameters for getRandom min: "+ min +"; max:"+max;
        }
        randomNumber = min + Math.floor(Math.random()*(max-min+1));
        return randomNumber
    }
    return{
        add: add
    }
}();
