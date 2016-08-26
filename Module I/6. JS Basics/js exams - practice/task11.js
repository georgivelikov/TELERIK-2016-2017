function solve(args){
    var s = +args[0];
    var c = 0;
    i = 4;
    j = 3;
    k = 10;
    for (var i = 0; i <= s; i++) {
        for (var j = 0; j <= s; j++) {
            for (var k = 0; k <= s; k++) {
                if (i * 3 + j * 4 + k * 10 == s) {
                    c++;
                }
                
            }
            
        }    
    }

    console.log(c);
}

var test1 = [
	'40',
];

solve(test1);