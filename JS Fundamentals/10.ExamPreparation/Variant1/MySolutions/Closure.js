var firstTest = [
    '(+ 1 2)', 
'(+ 5 2 7 1)',
'(- 4 2)',
'(- 4)',
'(/ 2)'


];



function Solve(input) {
    var operator;
    var parameters=[];
    for(var i=0; i<input.length;i++){
        var currentRow = input[i].trim();
        for (var j = 0; j < currentRow.length; j++) {
            var currentSymbol = currentRow[j];
            if (currentSymbol == ' ') {
                continue;
            }

            if(isMathOperator(currentSymbol))
            {
                operator=currentSymbol;
                continue;
            }

            if (!isNaN(currentSymbol)) {
                // if(symbol == Number(symbol) )
                parameters.push(parseInt(currentSymbol));
            }

            function calculate(operator,parameters){
                if (parameters.length == 1) {
                    return parameters[0];
                }

                var result = parameters[0];
                for (var i = 0; i < length; i++) {
                    switch (operator) {
                        case '+': result += parameters[i]; break;
                        case '-': result -= parameters[i]; break;
                        case '*': result *= parameters[i]; break;
                        case '/': if (parameters[i] == 0) {
                            return 'Error';
                        }
                            result /= parameters[i];
                            result = parseInt(result);
                            break;
                    }
                }
            }
        }
        return result;
    }

    function isMathOperator(symbol) {
        if(symbol=='+' || symbol == '-'|| symbol =='*' || symbol == '/'){
            return true;
        }
        return false;
    }
}

console.log(Solve(firstTest));