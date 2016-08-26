function solve(args) {
	var a = +args[0];
    var b = +args[1];
    var c = +args[2];

    args.sort(function(a, b){
        return b - a;
    });
    var output = '';
    for (var i = 0; i < args.length; i++) {
        output += args[i] + ' ';
    }
    output.trim();
    console.log(output);
}

solve(['11', '1', '5']);