function solve(args){
	var text = args[0];
    String.prototype.htmlEscape = function () {
        var escapedStr = String(this).replace(/\s/g, '&nbsp;');
        return escapedStr;
    };

    console.log(text.htmlEscape());

}

var test1 = [
    'We are living in'
];

solve(test1);