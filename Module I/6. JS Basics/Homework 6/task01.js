function solve(args) {
	var x1 = +args[0];
	var y1 = +args[1];
	var x2 = +args[2];
	var y2 = +args[3];
	var x3 = +args[4];
	var y3 = +args[5];
	var x4 = +args[6];
	var y4 = +args[7];
	var x5 = +args[8];
	var y5 = +args[9];
	var x6 = +args[10];
	var y6 = +args[11];

	var line1 = Math.sqrt(Math.pow(x1 - x2, 2) + Math.pow(y1 - y2, 2));
	var line2 = Math.sqrt(Math.pow(x3 - x4, 2) + Math.pow(y3 - y4, 2));
	var line3 = Math.sqrt(Math.pow(x5 - x6, 2) + Math.pow(y5 - y6, 2));

	console.log(line1.toFixed(2));
	console.log(line2.toFixed(2));
	console.log(line3.toFixed(2));

	if (line1 + line2 <= line3) {
		console.log('Triangle can not be built');
	}
	else if (line2 + line3 <= line1) {
		console.log('Triangle can not be built');
	}
	else if (line1 + line3 <= line2) {
		console.log('Triangle can not be built');
	}
	else {
		console.log('Triangle can be built');
	}
}

solve([
  '7', '7', '2', '2',
  '5', '6', '2', '2',
  '95', '-14.5', '0', '-0.123'
])