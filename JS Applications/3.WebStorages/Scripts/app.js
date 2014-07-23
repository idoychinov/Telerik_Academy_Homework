(function() {
    'use strict';

    require.config({
        paths: {
            jquery: 'Libs/jquery',
            underscore: 'Libs/underscore',
            handlebars: 'Libs/handlebars',
            tasks: 'game-logic',
            alphanum: 'Libs/jquery.alphanum'
        },
        'shim' : {
            'handlebars': {
                exports: 'Handlebars'
            }
        }
    });

    require(['jquery', 'game-logic', 'alphanum'], function ($, GameLogic,alphanum) {
        var currentNumber,
            guessedNumber,
            currentGuessResult,
            turn =0;
        $('#number-input').numeric();

        currentNumber = GameLogic.generateNumber();

        //For easier testing purposes and verification of the game logic
        console.log(currentNumber);

        $('body').on('keypress', function(e){
            if(e.keyCode === 13){
                guessedNumber =$('#number-input').val();
                if(!guessedNumber || GameLogic.isInvalidNumber(guessedNumber)){
                    alert('The input number is invalid. It must be four digits in the range 1000 - 9999 with four different digits');
                } else {
                    turn++;
                    currentGuessResult = GameLogic.getRamsAndSheep(currentNumber,guessedNumber);
                    console.log(currentGuessResult)
                    alert('Rams: '+currentGuessResult.rams + ' Sheep: '+currentGuessResult.sheep);

                    // High Score to do
                }

            }

        })

    })
}())