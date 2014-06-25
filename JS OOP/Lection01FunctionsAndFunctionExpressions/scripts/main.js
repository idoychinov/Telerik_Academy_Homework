$(document).ready(function(){
    //  Task 1
    // append to body
    $("#add-div").on("click",function (){
        DomManipulation.appendChild($("<div />"),"#dom-manipulation-section");
    });

    // remove last div from body
    $("#remove-div").on("click",function (){
        DomManipulation.removeChild("#dom-manipulation-section","div:last-child");
    });

    //add handler
    $("#add-handler").on("click",function (){
        DomManipulation.addHandler("#dom-manipulation-section div","click", function(){
            var $this = $(this),
                color =$this.css("background-color"),
                colorComponents,
                red,
                green,
                blue,
                MAX_COLOR_COMPONENT=255;

            color = color.substring(4,color.length-1);
            colorComponents = color.split(",");
            red = MAX_COLOR_COMPONENT-colorComponents[0].trim();
            green = MAX_COLOR_COMPONENT-colorComponents[1].trim();
            blue = MAX_COLOR_COMPONENT-colorComponents[2].trim();
            $this.css("background-color","rgb("+red+", "+green+", "+blue+")");
        });
        alert("Invert color on click added to the selected element");
    });

    // get elements

    $("#get-elements").on("click",function (){
        var elements="";
        $.each(DomManipulation.getElements("#dom-manipulation-section div"),function(){
            elements+= this.tagName+"\n";
        })
        alert(elements);
    });

    //add to buffer
    $("#test-buffer").on("click",function (){
        var interval,
            count=0;

        interval = setInterval(function(){
            // the if can be removed but then the timer will run indefinetly and new elements will be appended constantly
            if(count>=DomManipulation.BUFFER_APPEND_TRESHHOLD){
                clearInterval(interval);
                $("#dom-manipulation-section span em").text(0);
            }else {
                count++;
                DomManipulation.appendToBuffer("#dom-manipulation-section", $("<div/>"));
                $("#dom-manipulation-section span em").html(count);
            }
        },10)
    });


    // Task 2
    MovingDivs.add();
})