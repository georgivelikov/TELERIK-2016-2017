/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(array) {
	if(array === undefined){
		throw new Error();
	}
	if(array.length === 0){
		return null;
	}

	if(array.some(elem => isNaN(elem))){
		throw new Error();
	}

	var sum = 0;

	for(var i = 0; i < array.length; i += 1){
		sum += +array[i];
	}

	return sum;
}

module.exports = sum;