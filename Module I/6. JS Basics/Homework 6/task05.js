function solve(args) {
	var max = Number.MAX_SAFE_INTEGER;
	var people = [];
	for(var i = 0; i < args.length; i += 3) {
		var person = {};
		person.name = args[i] + ' ' + args[i + 1];
		person.age = +args[i + 2];
		people.push(person);
	}

	people.sort(function(p1, p2) {
		return p1.age - p2.age;
	})

	console.log(people[0].name);
}

solve([
  'Penka', 'Hristova', '61',
  'System', 'Failiure', '88',
  'Bat', 'Man', '16',
  'Malko', 'Kote', '72'
])