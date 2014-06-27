var SnakeRenderer = function(){
    var ctx;

    function init(canvasObject){
        ctx = canvasObject.getContext("2d");

    }

    return {
        init:init
    }
}();