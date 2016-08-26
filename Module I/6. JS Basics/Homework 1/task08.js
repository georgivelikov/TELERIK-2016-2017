function solve(args) {
	var a = +args[0];
	var b = +args[1];
	var h = +args[2];

	var s = ((a + b) / 2) * h;

	console.log(s.toFixed(7));
}