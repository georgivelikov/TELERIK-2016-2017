function solve(args) {
	var a = +args[0];
    var b = +args[1];
    var c = +args[2];
	var biggest;
    if (a >= b) {
    	if (a >= c) {
    		biggest = a;
    	}
    	else {
    		biggest = c;
    	}
    }
    else {
    	if (b >= c) {
    		biggest = b;
    	}
    	else {
    		biggest = c;
    	}
    }

    console.log(biggest);
}