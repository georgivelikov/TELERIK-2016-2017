function solve(args){
	var input = args[0].split('\n');
	var str1 = input[0];
	var str2 = input[1];

	console.log(str1[1]);

	if (str1 > str2) {
		console.log('>');
	}
	else if (str1 < str2) {
		console.log('<');
	}
	else {
		console.log('=');
	}
}

solve(['hello\nhalo'])
