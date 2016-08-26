function solve(args){
	var dimensions = args[0].split(' ');
	var rows = +dimensions[0];
	var cols = +dimensions[1];

	var board = [];
	for (var i = 0; i < rows; i++) {
		var cRow = [];
		for (var j = 0; j < cols; j++) {
			cRow[j] = ' ';
		}
		board.push(cRow);
	}
	
	var debries = args[1].split(';');
	for (var i = 0; i < debries.length; i++) {
		var cDeb = debries[i].split(' ');
		board[cDeb[0]][cDeb[1]] = 'x';
	}

	var tankRows = {};
	var tankCols = {};

	board[0][0] = '0';
	tankRows[0] = 0;
	tankCols[0] = 0;

	board[0][1] = '1';
	tankRows[1] = 0;
	tankCols[1] = 1;

	board[0][2] = '2';
	tankRows[2] = 0;
	tankCols[2] = 2;

	board[0][3] = '3';
	tankRows[3] = 0;
	tankCols[3] = 3;

	board[rows - 1][cols - 1] = '4';
	tankRows[4] = rows - 1;
	tankCols[4] = cols - 1;

	board[rows - 1][cols - 2] = '5';
	tankRows[5] = rows - 1;
	tankCols[5] = cols - 2;

	board[rows - 1][cols - 3] = '6';
	tankRows[6] = rows - 1;
	tankCols[6] = cols - 3;

	board[rows - 1][cols - 4] = '7';
	tankRows[7] = rows - 1;
	tankCols[7] = cols - 4;

	var koceTanks = 4;
	var cykiTanks = 4;

	for (var t = 3; t < args.length; t += 1) {
		//console.log(t - 1);
		//console.log(board);
		var command = args[t].split(' ');
		var type = command[0];
		var tankId = +command[1];
		var currentRow = tankRows[tankId];
		var currentCol = tankCols[tankId];

		var dir;

		if (type == 'mv') {
			var n = +command[2];
			dir = command[3];
			while(n > 0){
				if (dir == 'l') {
					currentCol--;
					if (currentCol < 0) {
						currentCol++;
						break;
					}
					else if(board[currentRow][currentCol] != ' '){
						currentCol++;
						break;
					}
				}
				if(dir == 'r'){
					currentCol++;
					if (currentCol >= cols) {
						currentCol--;
						break;
					}
					else if(board[currentRow][currentCol] != ' '){
						currentCol--;
						break;
					}
				}
				if(dir == 'u'){
					currentRow--;
					if (currentRow < 0) {
						currentRow++;
						break;
					}
					else if(board[currentRow][currentCol] != ' '){
						currentRow++;
						break;
					}
				}
				if(dir == 'd'){
					currentRow++;
					if (currentRow >= rows) {
						currentRow--;
						break;
					}
					else if(board[currentRow][currentCol] != ' '){
						currentRow--;
						break;
					}
				}

				n--;
			}
			var cr = tankRows[tankId];
			var cc = tankCols[tankId];
			board[cr][cc] = ' ';
			board[currentRow][currentCol] = tankId + '';
			//console.log(board);
			tankRows[tankId] = currentRow;
			tankCols[tankId] = currentCol;
		}
		else {
			dir = command[2];
			while(true){
				if (dir == 'l') {
					currentCol--;
				}
				if (dir == 'r') {
					currentCol++;
				}
				if (dir == 'd') {
					currentRow++;
				}
				if (dir == 'u') {
					currentRow--;
				}
				if (currentRow >= rows || currentRow < 0 || currentCol >= cols || currentCol < 0) {
					break;
				}
				if (board[currentRow][currentCol] == 'x') {
					board[currentRow][currentCol] = ' ';
					break;
				}
				if (board[currentRow][currentCol] != 'x' && board[currentRow][currentCol] != ' ') {
					var hitId = board[currentRow][currentCol] * 1;
					board[currentRow][currentCol] = ' ';
					if (hitId < 4) {
						koceTanks--;
						console.log(`Tank ${hitId} is gg`);
						if (koceTanks == 0) {
							console.log('Koceto is gg');
							return;
						}
					}
					else {
						cykiTanks--;
						console.log(`Tank ${hitId} is gg`);
						if (cykiTanks == 0) {
							console.log('Cuki is gg');
							return;
						}
					}
					
					break;
				}
			}
		}
	}

	
}

var test1 = [
    '5 5',
    '2 0;2 1;2 2;2 3;2 4',
    '13',
    'mv 7 2 l',
    'x 7 u',
    'x 0 d',
    'x 6 u',
    'x 5 u',
    'x 2 d',
    'x 3 d',
    'mv 4 1 u',
    'mv 4 4 l',
    'mv 1 1 l',
    'x 4 u',
    'mv 4 2 r',
    'x 2 d'
];

solve(test1);
