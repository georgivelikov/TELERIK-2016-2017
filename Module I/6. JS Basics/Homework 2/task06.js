function solve(args) {
	var a = +args[0];
    var b = +args[1];
    var c = +args[2];

    var d = Math.pow(b, 2) - 4 * a * c;
    if (d < 0) {
        console.log('no real roots');
    }
    else if (d === 0) {
        var x0 = -1 * b / (2 * a);
        console.log('x1=x2=' + x0.toFixed(2));
    }
    else {
        var x2 = (-1 * b + Math.sqrt(d)) / (2 * a);
        var x1 = (-1 * b - Math.sqrt(d)) / (2 * a);

        console.log('x1=' + x1.toFixed(2) + '; x2=' + x2.toFixed(2));
    }
}

solve(['2', '5', '-3']);