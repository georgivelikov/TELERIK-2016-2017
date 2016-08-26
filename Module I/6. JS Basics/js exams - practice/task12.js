function solve(args){
    var dimensions = args[0].split(' ');
    var rows = +dimensions[0];
    var cols = +dimensions[1];
    var sum = 0;
    var currentRow = 0;
    var currentCol = 0;
    var matrix = [];
    for (var i = 0; i < rows; i++) {
        var takenRow = [];
        var starting = Math.pow(2, i);
        for (var j = 0; j < cols; j++) {
            takenRow[j] = starting;
            starting++;
        }
        matrix.push(takenRow);
    }
    var sum = 1;
    var board = [];
    for (var i = 1; i < args.length; i++) {
        var line = args[i].split(' ');
        board.push(line);
    }
    var counter = 0;
    while(counter < 100){
        if (board[currentRow][currentCol] == 'dr') {
            currentRow++;
            currentCol++;
            if (currentRow >= rows || currentRow < 0 || currentCol >= cols || currentCol < 0) {
                console.log("successed with " + sum);
                return;
            }
            if (matrix[currentRow][currentCol] === 0) {
                console.log('failed at ('+ currentRow + ', ' + currentCol + ')');
                return;
            }
        }
        else if(board[currentRow][currentCol] == 'dl'){
            currentRow++;
            currentCol--;
            if (currentRow >= rows || currentRow < 0 || currentCol >= cols || currentCol < 0) {
                console.log("successed with " + sum);
                return;
            }
            if (matrix[currentRow][currentCol] === 0) {
                console.log('failed at ('+ currentRow + ', ' + currentCol + ')');
                return;
            }
        }
        else if(board[currentRow][currentCol] == 'ul'){
            currentRow--;
            currentCol--;
            if (currentRow >= rows || currentRow < 0 || currentCol >= cols || currentCol < 0) {
                console.log("successed with " + sum);
                return;
            }
            if (matrix[currentRow][currentCol] === 0) {
                console.log('failed at ('+ currentRow + ', ' + currentCol + ')');
                return;
            }
            
        }
        else if(board[currentRow][currentCol] == 'ur'){
            currentRow--;
            currentCol++;
            if (currentRow >= rows || currentRow < 0 || currentCol >= cols || currentCol < 0) {
                console.log("successed with " + sum);
                return;
            }
            if (matrix[currentRow][currentCol] === 0) {
                console.log('failed at ('+ currentRow + ', ' + currentCol + ')');
                return;
            }
        }
        sum += matrix[currentRow][currentCol];
        matrix[currentRow][currentCol] = 0;
        counter++;
    }
}

var test1 = [
  '3 5',
  'dr dl dl ur ul',
  'dr dr ul ul ur',
  'dl dr ur dl ur'   
];



solve(test1);