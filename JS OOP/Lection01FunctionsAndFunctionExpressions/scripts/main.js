window.onload =function(){
    //  Task 1
    // append to body

    document.getElementById("add-div").addEventListener("click",function (){
        var newDiv = document.createElement("div");
        newDiv.style.backgroundColor="rgb(0,128,0)";
        DomManipulation.appendChild(newDiv,"#dom-manipulation-section");
    });

    // remove last div from body
    document.getElementById("remove-div").addEventListener("click",function (){
        DomManipulation.removeChild("#dom-manipulation-section","div:last-child");
    });

    //add handler
    document.getElementById("add-handler").addEventListener("click",function (){
        DomManipulation.addHandler("#dom-manipulation-section div","click", function(ev){
            var color =this.style.backgroundColor,
                colorComponents,
                red,
                green,
                blue,
                MAX_COLOR_COMPONENT=255;
            this.style.backgroundColor="rgb(0,0,0)"
            color = color.substring(4,color.length-1);
            colorComponents = color.split(",");
            red = MAX_COLOR_COMPONENT-colorComponents[0].trim();
            green = MAX_COLOR_COMPONENT-colorComponents[1].trim();
            blue = MAX_COLOR_COMPONENT-colorComponents[2].trim();
            this.style.backgroundColor ="rgb("+red+", "+green+", "+blue+")";
        });
        alert("Invert color on click added to the selected element");
    });

    // get elements

    document.getElementById("get-elements").addEventListener("click",function (){
        var i,
            selectedElements,
            elements="";

        selectedElements=DomManipulation.getElements("#dom-manipulation-section div");
        for(i=0; i<selectedElements.length; i++){
            elements+= selectedElements[i].tagName+', ';
        }
        alert(elements);
    });

    //add to buffer
    document.getElementById("test-buffer").addEventListener("click",function (){
        var interval,
            count=0;

        interval = setInterval(function(){
            var counter = document.querySelector("#dom-manipulation-section span em"),
                divToAdd,
                spanToAdd;

            // the if can be removed but then the timer will run indefinetly and new elements will be appended constantly
            if(count>=DomManipulation.BUFFER_APPEND_TRESHHOLD){
                clearInterval(interval);
                counter.innerText=0;
            }else {
                count++;
                if(count%(DomManipulation.BUFFER_APPEND_TRESHHOLD/10) === 0){
                    spanToAdd = document.createElement("span");
                    spanToAdd.innerHTML = "span "+count;
                    DomManipulation.appendToBuffer("#dom-manipulation-section p", spanToAdd);
                }

                divToAdd = document.createElement("div");
                divToAdd.style.backgroundColor="rgb(128,0,0)";

                DomManipulation.appendToBuffer("#dom-manipulation-section", divToAdd);
                counter.innerText=count;
            }
        },10)
    });


    // Task 2
    document.getElementById("add-moving-div-rect").addEventListener("click",function (){
        MovingDivs.add("#moving-divs-section article .moving-divs-container","rect");
    });

    document.getElementById("add-moving-div-ellipse").addEventListener("click",function (){
        MovingDivs.add("#moving-divs-section article .moving-divs-container","ellipse");
    });

    document.getElementById("remove-all-moving-divs").addEventListener("click",function (){
        MovingDivs.removeAll();
    });

    // Task 3

    function writeToConsole(type){
        var message,
            params,
            paramsList,
            paramsToApply=[],
            i;

        message = document.getElementById("console-message").value;
        params = document.getElementById("console-message-params").value;
        paramsList = params.split(",");
        if(params === ""){
            paramsToApply.push(message);
        } else
        {
            paramsToApply.push(message)
            for(i=0; i<paramsList.length;i++){
                paramsToApply.push(paramsList[i]);
            }
        }

        switch (type){
            case "message":
                ConsoleModule.writeLine.apply(null,paramsToApply);
                break;
            case "warning":
                ConsoleModule.writeWarning.apply(null,paramsToApply);
                break;
            case "error":
                ConsoleModule.writeError.apply(null,paramsToApply);
                break;
            default : throw "Incorrect input parameter type "+type;
        }
    }

    document.getElementById("write-message-to-console").addEventListener("click",function (){
        writeToConsole("message");

    });


    document.getElementById("write-warning-to-console").addEventListener("click",function (){
        writeToConsole("warning");

    });

    document.getElementById("write-error-to-console").addEventListener("click",function (){
        writeToConsole("error");

    });


}