function solve(args){
	var input = args[0].split('\n').map(Number);
	var arr = input.splice(1, +input[0])
	
	function binaryIndexOf(searchElement, collection) {
	    'use strict';
	 
	    var minIndex = 0;
	    var maxIndex = collection.length - 1;
	    var currentIndex;
	    var currentElement;
	 
	    while (minIndex <= maxIndex) {
	        currentIndex = (minIndex + maxIndex) / 2 | 0;
	        currentElement = collection[currentIndex];
	 
	        if (currentElement < searchElement) {
	            minIndex = currentIndex + 1;
	        }
	        else if (currentElement > searchElement) {
	            maxIndex = currentIndex - 1;
	        }
	        else {
	            return currentIndex;
	        }
	    }
	 
	    return -1;
	}
	var result = binaryIndexOf(+input[input.length - 1], arr);
	console.log(result);
}

solve(['4\n3\n13\n23\n33\n32\n13'])
