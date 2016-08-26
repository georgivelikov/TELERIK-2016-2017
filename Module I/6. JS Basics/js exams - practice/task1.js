function solve(args){
	var arr = args[0].split(' ').map(Number);

	var maxCounter = Number.MIN_SAFE_INTEGER;
	var prevPeekIndex = 0;
	for (var i = 1; i < arr.length - 1; i += 1) {
		if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1]) { // peek found
			if (i - prevPeekIndex > maxCounter) {
				maxCounter = i - prevPeekIndex;
			}

			prevPeekIndex = i;
		}
	}
	if (arr.length - 1 - prevPeekIndex > maxCounter) {
		console.log(arr.length - 1 - prevPeekIndex);
		return;
	}
	console.log(maxCounter);
}

var test1 = [
	'5 1 7 6 3 6 4 2 3 8',
];

solve(test1);
