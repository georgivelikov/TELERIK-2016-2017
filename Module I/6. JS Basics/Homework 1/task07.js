function solve(args) {
	var x = +args[0];

	var maxDivisor = Math.sqrt(x);
	var isPrime = true;

	if (x < 2) {
		console.log(false);
		return;
	}

	for (var i = 2; i <= maxDivisor; i += 1) {
		if (x % i === 0) {
			isPrime = false;
		}
	}

	console.log(isPrime);
}