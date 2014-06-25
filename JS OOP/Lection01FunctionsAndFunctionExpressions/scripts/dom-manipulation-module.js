var DomManipulation;
DomManipulation = function () {
    var buffer = [],
        BUFFER_APPEND_TRESHHOLD = 100,
        $fragment = $(document.createDocumentFragment());

    function appendChild(element, selector) {
        var $parent = $(selector);

        $parent.append(element);
    }

    function removeChild(parentElement, selector){
        var $parent = $(parentElement);
        //console.log($parent.html());
        //console.log($(selector).html());

        $parent.find(selector).remove();
    }

    function addHandler(target,eventType,eventHandler){
        var $target = $(target);
        $target.on(eventType,eventHandler);
    }

    function appendToBuffer(selector, element){
        if(buffer[selector]){
            addElementToBuffer(selector,element);
        } else{
            buffer[selector] = [];
            buffer[selector].push(element);
        }

    }

    function addElementToBuffer(selector, element){
        buffer[selector].push(element);
        if(buffer[selector].length >=BUFFER_APPEND_TRESHHOLD){
            $.each(buffer[selector], function(){
                $fragment.append(this)
            });
            $(selector).append($fragment);
        }
    }

    function getElements(selector){
        return $(selector);
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
