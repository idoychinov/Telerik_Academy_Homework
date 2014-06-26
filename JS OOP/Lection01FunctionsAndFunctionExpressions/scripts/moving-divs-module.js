var MovingDivs;
MovingDivs = function () {
    var divsList =[],
        divTemplate,
        MOVEMENT_DELTA=1,
        MOVEMENT_DEVIATION=100,
        ELLIPSE_SEMIMAJOR= 0.7,// multiplier for X movement component (1 for circular movement), making this greater than 1 can cause the dive to move outside the bounds of the parent element
        ELLIPSE_SEMIMINOR = 1; // multiplier for Y movement component (1 for circular movement), making this greater than 1 can cause the dive to move outside the bounds of the parent element

    divTemplate = document.createElement("div");
    divTemplate.className="moving";

    function moveDivs(){
        var i;
        for(i in divsList){
            performMovement(divsList[i]);
        }
        window.requestAnimationFrame(moveDivs);
    }

    function performMovement(element){
            var direction,
                angle,
                rectMovementDirections = [
                    {x:1,y:0},
                    {x:0,y:1},
                    {x:-1,y:0},
                    {x:0,y:-1}
                ];
            if(element.movementType === "rect"){
                direction = (element.currentPosition / MOVEMENT_DEVIATION) |0;
                element.div.style.top = (parseInt(element.div.style.top) + rectMovementDirections[direction].y)+"px";
                element.div.style.left = (parseInt(element.div.style.left) +rectMovementDirections[direction].x)+"px";
                element.currentPosition = (element.currentPosition+MOVEMENT_DELTA) % (MOVEMENT_DEVIATION*4);
            } else if(element.movementType==="ellipse"){
                angle=(Math.PI * (element.currentPosition)) / 180;
                element.div.style.top = (element.centerY + (ELLIPSE_SEMIMINOR*Math.sin(angle)*MOVEMENT_DEVIATION/2))+"px";
                element.div.style.left = (element.centerX +(ELLIPSE_SEMIMAJOR*Math.cos(angle)*MOVEMENT_DEVIATION/2))+"px";
                element.currentPosition = (element.currentPosition+MOVEMENT_DELTA) % 360;
            }
    }

    // doesn't work correctly under IE
    function add(selector,movementType){
        var parent,
            createdDiv,
            parentWidth,
            parentHeight,
            parameters;

        parent = document.querySelector(selector);
        createdDiv = divTemplate.cloneNode(true);

        createdDiv.style.backgroundColor = "rgb("+ getRandom(0,255) + ", " +getRandom(0,255)+", " +getRandom(0,255)+")";
        createdDiv.style.borderColor = "rgb("+ getRandom(0,255) + ", " +getRandom(0,255)+", " +getRandom(0,255)+")";
        createdDiv.style.fontSize = getRandom(12,24)+"px";
        parentWidth = parseInt(window.getComputedStyle(parent).width);
        parentHeight = parseInt(window.getComputedStyle(parent).height);
        createdDiv.style.top = getRandom(0,parentHeight-50-MOVEMENT_DEVIATION)+"px";
        createdDiv.style.left = getRandom(0,parentWidth-50-MOVEMENT_DEVIATION)+"px";
        parent.appendChild(createdDiv);
        if(movementType==="rect"){
            parameters = {
                div: createdDiv,
                movementType:"rect",
                currentPosition:0
            }
        } else if(movementType==="ellipse"){
            parameters = {
                div: createdDiv,
                movementType:"ellipse",
                currentPosition:0,
                centerX: parseInt(createdDiv.style.left) + (MOVEMENT_DEVIATION/2),
                centerY: parseInt(createdDiv.style.top) + (MOVEMENT_DEVIATION/2)
            }
        }

        divsList.push(parameters);

    }

    function removeAll() {
        var i;
        for(i in divsList){
            divsList[i].div.remove();
        }

        divsList=[];
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

    window.requestAnimationFrame(moveDivs);

    return{
        add: add,
        removeAll: removeAll
    }
}();
