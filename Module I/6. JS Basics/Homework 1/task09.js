function solve(args) {
	var cX = 1;
    var cY = 1;
    var r = 1.5;
    var top = 1;
    var left = -1;
    var w = 6;
    var h = 2;

    var x = +args[0];
    var y = +args[1];
    var output = "";
    if (Math.pow(x - cX, 2) + Math.pow(y - cY, 2) <= Math.pow(r, 2))
    {
        output += "inside circle ";
    }
    else
    {
        output += "outside circle ";
    }

    if (x >= left && x <= left + w && y >= top - h && y <= top)
    {
        output += "inside rectangle";
    }
    else
    {
        output += "outside rectangle";
    }

    console.log(output);
}