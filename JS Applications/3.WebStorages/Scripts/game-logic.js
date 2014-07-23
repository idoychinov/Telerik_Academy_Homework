define(['underscore'],function(_){
    'use strict';
    var GameLogic;
    GameLogic = (function(){

        function generateNumber(){
            var randomNNumber;

            do {
                randomNNumber = Math.floor((Math.random() * 9000) + 1000);
            } while(isInvalidNumber(randomNNumber));

            return randomNNumber;
        }

        function isInvalidNumber(number){
            var numberAsString,
                isIncorrectNumber;
            numberAsString=number.toString();
            //TODO refactor as function that checks combinations in order to work for different lenght numbers
            isIncorrectNumber = numberAsString[0] === numberAsString[1] ||
                numberAsString[0] === numberAsString[2] ||
                numberAsString[0] === numberAsString[3] ||
                numberAsString[1] === numberAsString[2] ||
                numberAsString[1] === numberAsString[3] ||
                numberAsString[2] === numberAsString[3];

            return isIncorrectNumber;
        }

        function getRamsAndSheep(currentNumber,guessedNumber){
            var rams=0,
                sheep=0,
                currecntNumberAsString=currentNumber.toString(),
                guessedNumberAsString=guessedNumber.toString(),
                i,
                j,
                len;

            if(currecntNumberAsString.length !== guessedNumberAsString.length){
                throw {
                    message: 'Inconsistent numbers length. Current and guessed number must be with equal length'
                }
            }

            for(i=0, len=currecntNumberAsString.length; i<len; i++){
                for(j=0; j<len; j++){
                    if(currecntNumberAsString[i]===guessedNumberAsString[j]){
                        if(i===j){
                            rams++;
                        }else {
                            sheep++;
                        }
                    }
                }
            }


            return {
                rams: rams,
                sheep: sheep
            }
        }

        return {
            generateNumber : generateNumber,
            getRamsAndSheep : getRamsAndSheep,
            isInvalidNumber : isInvalidNumber

        }
    }());

    return GameLogic;
});