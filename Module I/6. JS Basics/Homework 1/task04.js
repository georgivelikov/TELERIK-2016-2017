function solve(args) {
	var str = args[0];
	if (str.length <= 2) {
		console.log('false 0');
	}
	else {
		var index = str.length - 3;
		if (str[index] == 7) {
			console.log('true');
		}
		else {
			console.log('false ' + str[index]);
		}
	}
}

solve(['777777'])