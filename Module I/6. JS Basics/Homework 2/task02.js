function solve(args) {
	var a = +args[0];
    var b = +args[1];
    var c = +args[2];

    var symbol = '';

    if (a === 0 || b === 0 || c === 0) {
    	symbol = 0;
    }
    else {
    	if (a > 0) {
			if (b > 0) {
				if (c > 0) {
					symbol = '+';
				}
				else {
					symbol = '-';
				}
			}
			else {
				if (c > 0) {
					symbol = '-';	
				}
				else {
					symbol = '+';
				}

			}
    	}
    	else {
			if (b > 0) {
				if (c > 0) {
					symbol = '-';
				}
				else {
					symbol = '+';
				}
			}
			else {
				if (c > 0) {
					symbol = '+';
				}
				else {
					symbol = '-';
				}
			}
    	}
    }

    console.log(symbol);
}