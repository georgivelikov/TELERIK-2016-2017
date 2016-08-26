function solve(args) {
	const radius = 2;
	var x = +args[0];
	var y = +args[1];

	var d = Math.sqrt(Math.pow(x, 2) + Math.pow(y, 2));
	if (d <= radius) {
		console.log('yes' + d.toFixed(2));
	}
	else {
		console.log('no ' + d.toFixed(2));
	}
}

solve(['-1', '2'])