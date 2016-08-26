function solve(args) {
	var input = args[0].split('\n');
	var len = +input[0];
	var arr = input[1].split(' ');

	function countLarger(collection) {
		var counter = 0;
		for(var i = 1; i < collection.length - 1; i += 1) {
			if (+arr[i] > +arr[i - 1] && +arr[i] > +arr[i + 1]) {
				console.log(i);
				return;
			}
		}

		console.log(-1);
	}

	countLarger(arr);
}
