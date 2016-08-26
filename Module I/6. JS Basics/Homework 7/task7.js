function solve(args){
	var text = '' + args[0];
     
    var regex = /(.*?):\/\/(.*?)\/(.*)/gm;
    var arr = regex.exec(text);
    console.log("protocol: " + arr[1]);
    console.log("server: " + arr[2]);
    console.log("resource: /" + arr[3]);
}

var test1 = [
    'http://telerikacademy.com/Courses/Courses/Details/239'
];

solve(test1);