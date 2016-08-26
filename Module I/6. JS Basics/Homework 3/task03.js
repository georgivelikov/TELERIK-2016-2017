function solve(args){
	var n = +args[0];
	var counter = n;
	var output = '';
	for(var i = 1; i <= counter; i += 1) {
		for(var j = i; j <= n; j += 1) {
			output += j + ' ';
		};
		console.log(output.trim());
		n += 1;
		output = '';
	};
}

solve(['3'])