function solve(args) {
	var len = +args[0];
	var arr = args[1].split(' ');
	var num = +args[2];

	function countAppearance(number, collection) {
		var counter = 0;
		for(var i = 0; i < collection.length; i += 1) {
			if (+arr[i] === num) {
				counter++;
			}
		}

		return counter;
	}

	console.log(countAppearance(num, arr));
}