function solve(args){
    var s = +args[0];
    c1 = +args[1];
    c2 = +args[2];
    c3 = +args[3];
    var max = Number.MIN_SAFE_INTEGER;
    for (var i = 0; i <= s; i++) {
        for (var j = 0; j <= s; j++) {
            for (var k = 0; k <= s; k++) {
                var currentSum = i * c1 + j * c2 + k * c3;
                if (currentSum > max && currentSum <= s) {
                    max = currentSum;
                }
                if(currentSum > s){
                    break;
                }
            }
        }    
    }

    console.log(max);
}

var test1 = [
	'110',
    '19',
    '29',
    '39'
];

solve(test1);