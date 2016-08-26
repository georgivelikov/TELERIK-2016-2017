function solve(args){
	var obj = JSON.parse(args[0]);
	var text = ""+args[1];
	for (var key in obj) {
		//if (obj.hasOwnProperty(key)) {
			var element = obj[key];
			var pattern = '#{' + key + '}';
			var reg = new RegExp(pattern , 'g');

			text = text.replace(reg, element);
		//}
	}

	console.log(text);
}

var test1 = [
    '{ "name": "John", "age": 13 }', // options as JSON
    'My name is #{name} and I am #{age}-years-old' // template
]

solve(test1);
