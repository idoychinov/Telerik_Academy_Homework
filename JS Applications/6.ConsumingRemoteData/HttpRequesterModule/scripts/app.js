(function () {
    'use strict';
    require(['httpRequester'], function () {
        $('#get-data').on('click', function getData() {
            httpRequester.getJSON('http://crowd-chat.herokuapp.com/posts')
                .then(function (data) {$('#result').append(displayMessages(data)) },
                function (error) { $('#result').html(error.responseText) });
        });

        function displayMessages(data) {
            debugger;
            var $list = $('<ul />'),
                i,
                number;

            for (i in data) {
                number = parseInt(i)+1;
                $('<li/>').html('#'+number+' User: '+data[i].by+' Message: '+data[i].text).appendTo($list);
            };

            return $list;
        }
    });
}());