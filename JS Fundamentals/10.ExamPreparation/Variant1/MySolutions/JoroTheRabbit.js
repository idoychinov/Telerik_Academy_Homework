function Solve(input) {
    var initialState = input[0].split(' ');
    var N = parseInt(initialState[0]);
    var M = parseInt(initialState[1]);
    var J = parseInt(initialState[2]);

    function Position(input) {
        var splitInput = input.split(' ');
        this.row = parseInt(splitInput[0]);
        this.col = parseInt(splitInput[1]);
    }

    var startingPosition = new Position(input[1]);

    var jumpSequence = [];

    for (var i = 2; i < input.length; i += 1) {
        jumpSequence.push(new Position(input[i]));
    }

    var field = [];
    var currentNumber = 0;
    for (var row = 0; row < N; row += 1) {
        field[row] = [];
        for (var col = 0; col < M; col += 1) {
            currentNumber += 1;
            field[row].push(currentNumber);
        }
    }


    var currentPosition = {
        row: startingPosition.row,
        col: startingPosition.col
    }
    var jumpSum = field[currentPosition.row][currentPosition.col];
    field[currentPosition.row][currentPosition.col] = 0;
    var jumping = true;
    var numberOfJumps = 0;
    var sequenseCurrentJump = 0;

    while (jumping) {

        numberOfJumps += 1;
        currentPosition.row += jumpSequence[sequenseCurrentJump].row;
        currentPosition.col += jumpSequence[sequenseCurrentJump].col;

        if (currentPosition.row >= N || currentPosition.col >= M || currentPosition.row <0 || currentPosition.col<0) {
            return 'escaped ' + jumpSum;
        }
        
        if (field[currentPosition.row][currentPosition.col]) {
            jumpSum += field[currentPosition.row][currentPosition.col];
            field[currentPosition.row][currentPosition.col] = 0;
        } else {
            return 'caught ' + numberOfJumps;
        }

        sequenseCurrentJump = (sequenseCurrentJump + 1) % J;
    }
}

//var input = [
//    '6 7 3',
//    '0 0',
//    '2 2',
//    '-2 2',
//    '3 -1'
//]


//console.log(Solve(input));
