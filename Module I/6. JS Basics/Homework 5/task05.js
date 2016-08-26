function solve(args) {
	var len = +args[0];
	var arr = args[1].split(' ');

	function countLarger(collection) {
		var counter = 0;
		for(var i = 1; i < collection.length - 1; i += 1) {
			if (+arr[i] > +arr[i - 1] && +arr[i] > +arr[i + 1]) {
				counter++;
			}
		}

		return counter;
	}

	console.log(countLarger(arr));
}
