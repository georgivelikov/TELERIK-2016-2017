function solve(args){
	var input = +args[0];

	for(var i = input; i >= 2 ; i -= 1) {
		var isPrime = true;
		for(var j = 2; j <= Math.sqrt(i); j += 1) {
			if (i % j === 0) {
				isPrime = false;
				break;
			}
		}

		if (isPrime) {
			console.log(i);
			return;
		}
	}
}

solve(['126'])