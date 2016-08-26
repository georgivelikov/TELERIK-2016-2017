function solve(args){
    var n = +args[0];
    var k = +args[1];
	var arr = args[2].split(' ').map(Number);
    var results = [];
    for (var i = 0; i <= n - k; i++) {
        var min = Number.MAX_SAFE_INTEGER;
        var max = Number.MIN_SAFE_INTEGER;
        for (var j = i; j < i + k; j++) {
            if (arr[j] < min) {
                min = arr[j];
            }
            if (arr[j] > max) {
                max = arr[j];
            }
        }
        results.push(max + min);
    }
    console.log(results.join(','));
}

var test1 = [
    '8',
    '4',
	'1 8 8 4 2 9 8 11',
];

solve(test1);
