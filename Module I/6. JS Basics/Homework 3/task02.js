function solve(args){
	var arr = args;
	var sum = 0;
	var min = Number.MAX_SAFE_INTEGER;
	var max = Number.MIN_SAFE_INTEGER;
	var avg;

	for(var i = 0; i < arr.length; i += 1) {
		var num = +arr[i];
		sum += num;
		if (num < min) {
			min = num;
		}
		if (num > max) {
			max = num;
		}
	};

	avg = sum / arr.length;

	console.log('min=', min.toFixed(2));
	console.log('max=' + max.toFixed(2));
	console.log('sum=' + sum.toFixed(2));
	console.log('avg=' + avg.toFixed(2));
}

solve(['5', '-2', '1'])