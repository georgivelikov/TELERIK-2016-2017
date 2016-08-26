function solve(args){
	var arr = args[0].split('\n').map(Number);
	var map = {};

	for(var i = 1; i < arr.length; i += 1) {
		if (!map[arr[i]]) {
			map[arr[i]] = 0;
		}

		map[arr[i]] += 1;
	}

	var max = Number.MIN_SAFE_INTEGER;
	var maxItem;
	for(var item in map){
		if (map[item] > max) {
			max = map[item];
			maxItem = item;
		}
	}

	console.log(maxItem + ' (' + max + ' times)');
}
