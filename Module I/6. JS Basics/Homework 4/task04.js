function solve(args){
	var input = args[0].split('\n');
	var n = +input[0];
	var arr = [];

	for(var i = 0; i < n; i += 1) {
		arr[i] = +input[i + 1];
	};

	var max = Number.MIN_SAFE_INTEGER;
	var current = 1;
	for(var j = 1; j < n; j += 1) {
		if (arr[j] > arr[j - 1]) {
			current += 1;
		}
		else {
			if (max < current) {
				max = current;
			}

			current = 1;
		}
	};

	if (max < current) {
		max = current;
	}
	
	console.log(max);
}

solve(['10\n2\n1\n1\n2\n3\n3\n2\n2\n2\n1'])