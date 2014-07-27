(function() {
    'use strict';

    require.config({
        paths: {
            jquery: 'Libs/jquery',
            underscore: 'Libs/underscore',
            handlebars: 'Libs/handlebars',
            tasks: 'game-logic',
            alphanum: 'Libs/jquery.alphanum',
            storage : 'storage'
        },
        'shim' : {
            'handlebars': {
                exports: 'Handlebars'
            }
        }
    });

    require(['jquery', 'game-logic', 'storage','underscore', 'alphanum'], function ($, GameLogic,storage,_, alphanum) {
        var currentNumber,
            guessedNumber,
            currentGuessResult,
            turn =0;
        $('#number-input').numeric({
            allowMinus: false,
            allowThouSep: false,
            allowDecSep: false,
            maxDigits: 4,
            min: 1000,
            max : 9999
        });

        currentNumber = GameLogic.generateNumber();

        //For easier testing purposes and verification of the game logic
        console.log(currentNumber);

        $('body').on('keypress', function(e){
            var turnResult,
                displayMessage = $('#display-message'),
                turnHistory = $('#turn-history ul'),
                name,
                highscore;
            if(e.keyCode === 13){
                guessedNumber =$('#number-input').val();
                if(!guessedNumber || GameLogic.isInvalidNumber(guessedNumber)){
                    $('#display-message').html('The input number is invalid. It must be four digits in the range 1000 - 9999 with four different digits');
                } else {
                    turn++;
                    currentGuessResult = GameLogic.getRamsAndSheep(currentNumber,guessedNumber);
                    turnResult = 'Rams: '+currentGuessResult.rams + ' Sheep: '+currentGuessResult.sheep;
                    displayMessage.html(turnResult);
                    $('<li/>').append('Turn '+turn+' : '+ turnResult).appendTo(turnHistory)

                    if(currentGuessResult.rams===4){
                        var name = prompt('Congratulations you\'ve beaten the game in '+turn+' turns. Please enter your name.')
                        if(name || name === 0){
                            highscore = localStorage.getItem('highscore');

                            if(!highscore){
                                highscore = [];
                            } else {
                                highscore = JSON.parse(highscore);
                            }

                            highscore.push({
                                name: name,
                                turns: turn
                            });

                            localStorage.setItem('highscore',JSON.stringify(highscore));

                            alert(JSON.stringify(_.sortBy(highscore,function(score){
                                return score.turns;
                            })))
                        }


                    }
                }

            }

        })

    })
}())