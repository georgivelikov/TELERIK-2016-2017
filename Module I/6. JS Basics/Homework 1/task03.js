function solve(args) {
	var a = +args[0];
	var b = +args[1];

	var s = a * b;
	var p = (a + b) * 2;

	console.log(s.toFixed(2) + ' ' + p.toFixed(2));
}

solve(['2.5', '3']);