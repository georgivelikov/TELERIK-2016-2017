function solve(args){
	var arr = args[0].split(' ').map(Number);
	var indexOfLast = 0;
	var max = Number.MIN_SAFE_INTEGER;

	for (var i = 1; i < arr.length; i += 1) {
		var h = arr[i];
		if (i !== arr.length - 1) {
			if (h > arr[i - 1] && h > arr[i + 1]) {
				var currentSum = 0;
				for (var j = indexOfLast; j <= i; j += 1) {
					currentSum += arr[j];
				}

				if (currentSum > max) {
					max = currentSum;
				}

				indexOfLast = i;
			}
		}
		else {
			currentSum = 0;
			for (var k = indexOfLast; k <= i; k += 1) {
				currentSum += arr[k];
			}

			if (currentSum > max) {
				max = currentSum;
			}
		}
	}

	console.log(max);
}

var test1 = [
    "5 1 7 4 8"
];

var test2 = [
    "5 1 7 6 5 6 4 2 3 8"
];

solve(test1);
