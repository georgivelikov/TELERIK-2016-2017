function solve(args) {
	var arr = args[0].split(' ').map(Number);
	
	function getMax(collection) {
		var max = Number.MIN_SAFE_INTEGER;
		for(var i = 0; i < collection.length; i += 1) {
			if (+arr[i] > max) {
				max = arr[i];
			}
		}

		return max;
	}

	var result = getMax(arr);
	console.log(result);
}