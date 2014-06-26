var DomManipulation;
DomManipulation = function () {
    var buffer = [],
        BUFFER_APPEND_TRESHHOLD = 100;

    function appendChild(element, selector) {
        var parent = document.querySelector(selector);

        parent.appendChild(element);
    }

    function removeChild(parentElement, selector){
        var parent,
            children,
            i;
        parent =  document.querySelector(parentElement);
        children = parent.querySelectorAll(selector);

        for(i=children.length-1; i>=0; i--){
            children[i].remove();
        }
    }

    function addHandler(selector,eventType,eventHandler){
        var listOfTargets,
            i;
        listOfTargets = document.querySelectorAll(selector);

        for(i=0; i< listOfTargets.length;i++){
            listOfTargets[i].addEventListener(eventType,eventHandler);
        }
    }

    function appendToBuffer(selector, element){
        if(buffer[selector]){
            buffer[selector].push(element);
            if(buffer[selector].length >=BUFFER_APPEND_TRESHHOLD){
                emptyBuffer();
            }
        } else{
            buffer[selector] = [];
            buffer[selector].push(element);
        }

    }

    function emptyBuffer(){
        var selector,
            element,
            fragment;

        for(selector in buffer){
            fragment = document.createDocumentFragment();
            for(element in buffer[selector]){
                fragment.appendChild(buffer[selector][element]);
            }
            document.querySelector(selector).appendChild(fragment);
        }

        buffer = [];
    }

    function getElements(selector){
        return document.querySelectorAll(selector);
    }

    return{
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        getElements: getElements,
        BUFFER_APPEND_TRESHHOLD : BUFFER_APPEND_TRESHHOLD
    }
}();
