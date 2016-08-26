function solve(args) {
	var len = +args[0];
	var arr = args[1].split(' ').map(Number);

	arr.sort(function(a, b) {
	  return a - b;
	});

	console.log(arr.join(' '));
}
solve(['6', '3 4 1 5 2 6'])
