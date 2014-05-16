function Solve(args) {
    var length,
        sequences,
        i,
        currentNumber,
        previousNumber;

    sequences = 0;
    previousNumber = 2000000001;

    for (i = 1, length = parseInt(args[0]); i <= length; i++) {
        currentNumber = parseInt(args[i]);
        if (currentNumber < previousNumber) {
            sequences += 1;
        }
        previousNumber = currentNumber;
    }

    return sequences;
}


//var input1 = [
//    '7',
//    '1',
//    '2',
//    '-3',
//    '4',
//    '4',
//    '0',
//    '1'
//]

//var input2 = [
//    '6',
//    '1',
//    '3',
//    '-5',
//    '8',
//    '7',
//    '-6'
//]

//var input3 = [
//    '9',
//    '1',
//    '8',
//    '8',
//    '7',
//    '6',
//    '5',
//    '7',
//    '7',
//    '6',
//]

//console.log(Solve(input1));
//console.log(Solve(input2));
//console.log(Solve(input3));