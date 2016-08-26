function solve(args){
    var pattern = args[0];
	pattern = pattern.toLowerCase();
	var text = args[1];
	text = text.toLowerCase();

	var index = 0;
	var counter = 0;

	while (true) {
		index = text.indexOf(pattern, index);
		if (index >= 0) {
			counter++;
		}
		else {
			break;
		}
		index++;
	}

	console.log(counter);
}

var test1 = [
    'in',
    'We are living in an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.'
];

solve(test1);