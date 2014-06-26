var ConsoleModule;
ConsoleModule = function () {

    function messageText(args){
        var message = args[0].toString(),
            params=[],
            i,
            formattedMessage;
        if(args[1]){
            for(i=1; i<args.length;i++){
                params.push(args[i].toString());
            }
            formattedMessage = message;

            for(i=0; i<params.length; i++){
                formattedMessage= formattedMessage.split("{"+i+"}").join(params[i]);
            }

            return formattedMessage;
        } else {
            return message;
        }
    }

    function writeLine(){
        console.log(messageText(arguments));
    }

    function writeWarning(){
        console.warn(messageText(arguments));
    }

    function writeError(){
        console.error(messageText(arguments));
    }

    return{
        writeLine: writeLine,
        writeWarning: writeWarning,
        writeError: writeError
    }
}();
