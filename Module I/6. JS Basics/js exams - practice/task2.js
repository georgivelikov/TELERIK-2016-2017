function solve(args){
    var rows = +args[0];
    var cols = +args[1];
    var board = [];
    for (var k = 2; k < 2 + rows; k++) {
        board.push(args[k]);
    }

    var t = +args[2 + rows];

    function getCell(coordinates, matrix) {
        var targetRow = rows - (+coordinates[1]);
        var targetCol = coordinates[0].charCodeAt() - 97;

        return matrix[targetRow][targetCol];
    }

    function getRow(coordinates, matrix) {
        var targetRow = rows - (+coordinates[1]);
        return targetRow;
    }

    function getCol(coordinates, matrix) {
        var targetCol = coordinates[0].charCodeAt() - 97;
        return targetCol;
    }

    for (var index = 3 + rows; index < args.length; index++) {
        var commandString = args[index];
        var coords = commandString.split(' ');
        var currentRow = getRow(coords[0], board);
        var currentCol = getCol(coords[0], board);
        var targetRow = getRow(coords[1], board);
        var targetCol = getCol(coords[1], board);

        if(getCell(coords[0], board) === 'Q'){
            if(getCell(coords[1], board) === '-'){
                if(currentRow === targetRow){ 
                    var isFree = true;
                    if(currentCol < targetCol){
                        for(var i = targetCol; i > currentCol; i -= 1){
                            if(board[currentRow][i] !== '-'){
                                isFree = false;
                                break;
                            }
                        }
                    }
                    else{
                        for(var i = targetCol; i < currentCol; i += 1){
                            if(board[currentRow][i] !== '-'){
                                isFree = false;
                                break;
                            }
                        }
                    }

                    if(isFree){
                        console.log('yes');
                    }
                    else {
                        console.log('no');
                    }
                }
                else if(currentCol === targetCol){
                    var isFree = true;
                    if(currentRow < targetRow){
                        for(var i = targetRow; i > currentRow; i -= 1){
                            if(board[i][currentCol] !== '-'){
                                isFree = false;
                                break;
                            }
                        }
                    }
                    else{
                        for(var i = targetRow; i < currentRow; i += 1){
                            if(board[i][currentCol] !== '-'){
                                isFree = false;
                                break;
                            }
                        }
                    }

                    if(isFree){
                        console.log('yes');
                    }
                    else {
                        console.log('no');
                    }
                }
                else if(Math.abs(targetRow - currentRow) === Math.abs(targetCol - currentCol)){
                    var isFree = true;
                    var deltaR = 0;
                    var deltaC = 0;
                    var diff = Math.abs(targetRow - currentRow)
                    if(currentRow > targetRow){
                        deltaR = 1;
                    }
                    else {
                        deltaR = -1;
                    }
                    if(currentCol > targetCol){
                        deltaC = 1;
                    }
                    else {
                        deltaC = -1;
                    }
                    var i = targetRow;
                    var j = targetCol;
                    for(var counter = 0; counter < diff; counter++, i += deltaR, j += deltaC){
                        if(board[i][j] !== '-'){
                            isFree = false;
                            break;
                        }
                    }

                    if(isFree){
                        console.log('yes');
                    }
                    else {
                        console.log('no');
                    }

                }
                else {
                    console.log('no');
                }
            }
            else {
                console.log('no');
            }
        }
        else if(getCell(coords[0], board) === 'K'){
            if(getCell(coords[1], board) === '-'){
                if(currentRow - 2 === targetRow && currentCol - 1 === targetCol) {
                    console.log('yes');
                }
                else if(currentRow - 2 === targetRow && currentCol + 1 === targetCol) {
                    console.log('yes');
                }
                else if(currentRow + 2 === targetRow && currentCol - 1 === targetCol){
                    console.log('yes');
                }
                else if(currentRow + 2 === targetRow && currentCol + 1 === targetCol){
                    console.log('yes');
                }
                else if(currentRow + 1 === targetRow && currentCol + 2 === targetCol){
                    console.log('yes');
                }
                else if(currentRow + 1 === targetRow && currentCol - 2 === targetCol){
                    console.log('yes');
                }
                else if(currentRow - 1 === targetRow && currentCol + 2 === targetCol){
                    console.log('yes');
                }
                else if(currentRow - 1 === targetRow && currentCol - 2 === targetCol){
                    console.log('yes');
                }
                else {
                    console.log('no');
                }
            }
            else {
                console.log('no');
            }
        } 
        else {
            console.log('no');
        }
    }
}

var test1 = [
	'3',
    '4',
    '--K-',
    'K--K',
    'Q--Q',
    '12',
    'd1 b3',
    'a1 a3',
    'c3 b2',
    'a1 c1',
    'a1 b2',
    'a1 c3',
    'a2 c1',
    'd2 b1',
    'b1 b2',
    'c3 a3',
    'a2 a3',
    'd1 d3'
];

var test2 = [

];

solve(test1);
