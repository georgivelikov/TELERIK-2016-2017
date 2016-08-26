function solve(args){
	var str = args[0];
    var len = 0;
    for (var i = 0; i < str.length; i += 1) {
        var char = str.charAt(i);
        
        if (char === '(') {
            len++;
        }
        else if (char === ')') {
            len--;
        }
    }

    if (len === 0) {
        console.log("Correct");
    }
    else {
        console.log("Incorrect");
    }
}

var test1 = [ '((a+b)/5-d)' ]

solve(test1);