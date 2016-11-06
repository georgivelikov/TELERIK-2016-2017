/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(n1, n2) {
	if(isNaN(n1) || isNaN(n2) || n1 === undefined || n2 === undefined){
		throw new Error();
	}

	var start = +n1;
	var end = +n2;
	var result = [];

	for (var i = start; i <= end; i+= 1) {
		var current = i;
		var isPrime = true;
		for (var j = 2; j < current; j += 1) { // possible bottleneck
			if(current % j === 0 && current !== 2){
				isPrime = false;
				break;
			}
		}

		if((isPrime && current > 1) || current === 2){
			result.push(current);
		}
	}

	return result;
}

module.exports = findPrimes;
