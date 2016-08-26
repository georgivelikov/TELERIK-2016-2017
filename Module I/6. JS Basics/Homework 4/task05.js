function solve(args){
	var n = args[0].split('\n')[0];
	var arr = args[0].split('\n').splice(1, +n).map(Number);

	var result = selectionSort(arr);

	console.log(arr.join('\n'));

	function selectionSort(items){
	    var len = items.length,
	        min;

	    for (var i = 0; i < len; i++){
	        min = i;

	        for (var j= i + 1; j < len; j++){
	            if (items[j] < items[min]){
	                min = j;
	            }
	        }

	        if (i != min){
	            swap(items, i, min);
	        }
	    }

	    return items;
	}

	function swap(items, i, min) {
		var current = items[i];
		items[i] = items[min];
		items[min] = current;

	}
}


