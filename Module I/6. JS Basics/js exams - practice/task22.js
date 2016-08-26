function solve(args){
    var dimensions = args[0].split(' ');
    var rows = +dimensions[0];
    var cols = +dimensions[1];
    
    var jumps = 0;
    var currentRow = rows - 1;
    var currentCol = cols - 1;
    var directions = [];
    for (var i = 1; i < args.length; i++) {
        directions.push(args[i].split(''))
    }

    var matrix = [];
    for (var i = 0; i < rows; i++) {
        var starting = Math.pow(2, i);
        var rowArr = [];
        for (var j = 0; j < cols; j++) {
            rowArr.push(starting);
            starting--;
        }
        matrix.push(rowArr);
    }
    var sum = 0;
    var taken = [];

    for (var i = 0; i < rows; i++) {
        var takenRowArr = [];
        for (var j = 0; j < cols; j++) {
            takenRowArr[j] = false;
        }
        taken.push(takenRowArr);
    }

    while(true){
        if (currentRow < 0 || currentRow >= rows || currentCol < 0 || currentCol >= cols) {
            console.log('Go go Horsy! Collected ' + sum + ' weeds');
            return;
        }

        if (taken[currentRow][currentCol] == true) {
            console.log('Sadly the horse is doomed in '+ jumps + ' jumps');
            return;
        }
        else {
            taken[currentRow][currentCol] = true;
        }
        sum += +matrix[currentRow][currentCol];
        jumps++;
        var dir = directions[currentRow][currentCol];
        if (dir == '1') {
            currentRow -= 2;
            currentCol += 1;
        }
        else if(dir == '2'){
            currentRow -= 1;
            currentCol += 2;
        }
        else if(dir == '3'){
            currentRow += 1;
            currentCol += 2;
        }
        else if(dir == '4'){
            currentRow += 2;
            currentCol += 1;
        }
        else if(dir == '5'){
            currentRow += 2;
            currentCol -= 1;
        }
        else if(dir == '6'){
            currentRow += 1;
            currentCol -= 2;
        }
        else if(dir == '7'){
            currentRow -= 1;
            currentCol -= 2;
        }
        else if(dir == '8'){
            currentRow -= 2;
            currentCol -= 1;
        }
    }


}

var test1 = [
'3 5',
'54361',
'43326',
'52188',
];
 
solve(test1);