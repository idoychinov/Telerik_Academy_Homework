/// <reference path="jquery-2.1.1.min.js" />
window.onload = function () {
    (function ($) {

        $.fn.messageBox = function () {
            var $messageBox = $(this),
                messageIsShown = false; 

            function success(message) {
                if (messageIsShown) {
                    setTimeout(function (message) { $messageBox.success(message) }, 4000); // currently does not work
                } else{
                    showMessage("Success: "+ message);
                }
            }
             
            function error(message) {
                if (messageIsShown) {
                    setTimeout(function (message) { $messageBox.error(message) }, 4000);
                } else {
                    showMessage("Error: " + message);
                }
            }

            function showMessage(message) {
                messageIsShown = true;
                $message =$("<span />").text(message);
                $messageBox.append($message.fadeIn(1000, function () { 
                    setTimeout(function(){$message.hide();messageIsShown=false;}, 3000);
                    })
                )
            }

            return {
                success: success,
                error: error
            }
        }

        //Test the plugin
        var msgBox1 = $('#message-box').messageBox();
        var msgBox2 = $('#other-message-box').messageBox();
        msgBox1.success('Success message');
        setTimeout(function () { msgBox2.error('Error message') },5000);

        //TODO fix it so it can be used with more than one message in succession without the box bugging
        //msgBox1.success('Success message');
        //msgBox1.error('Error message');


    }(jQuery));
}