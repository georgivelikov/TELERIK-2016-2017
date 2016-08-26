function solve(args){
    var output = [];
	var selectors = {};
	var parrents = [''];

	for (var i = 0; i < args.length; i++) {
		var line = args[i];
		if (line.indexOf('{') > -1) {
			line = line.trim();
			var indexOfOpening = line.indexOf('{');
			var arr = line.split('');
			var help = arr.splice(indexOfOpening, 0, ' ');
			line = arr.join('');
			line = line.replace(/\s+/g, ' ');
			indexOfOpening = line.indexOf('{');

			var currentSelector = line.substring(0, indexOfOpening);
			if (line[0] === '.') {
				currentSelector = parrents[parrents.length - 1] + ' ' + currentSelector;
				currentSelector = currentSelector.replace(/\s+/g, ' ');
				currentSelector = currentSelector.trim();
			}
			else if (line[0] === '$') {
				currentSelector = parrents[parrents.length - 1] + currentSelector;
				currentSelector = currentSelector.replace(/\$/g, '');
				currentSelector = currentSelector.trim();
			}
			else if (line[0] === '#') {
				currentSelector = parrents[parrents.length - 1] + ' ' + currentSelector;
				currentSelector = currentSelector.replace(/\s+/g, ' ');
				currentSelector = currentSelector.trim();
			}
			else { // selector is element name
				currentSelector = parrents[parrents.length - 1] + ' ' + currentSelector;
				currentSelector = currentSelector.replace(/\s+/g, ' ');
				currentSelector = currentSelector.trim();
			}
			
			selectors[currentSelector] = [];
			parrents.push(currentSelector);
		}
		else if(line.indexOf('}') > -1) {
			line = line.trim();
			parrents.pop();
		}
		else {
			line = line.replace(/\s*/g, '');
			line = '  ' + line;
			var indexOfDots = line.indexOf(':');
			var arr = line.split('');
			var help = arr.splice(indexOfDots + 1, 0, ' ');
			line = arr.join('');

			selectors[parrents[parrents.length - 1]].push(line);
		}
	}

	for (var key in selectors) {
		console.log(key + " {");
		for (var j = 0; j < selectors[key].length; j++) {
			var element = selectors[key][j];
			console.log(element);
		}
		console.log("}");
	}
}

var test1 = [
'#the-big-b{',
'  color: big-yellow;',
'  .little-bs {',
'           color: little-yellow;',
'      $.male            {',
'             color: middle-yellow;',
'}',
'}',
'}',
'           .muppet           {',
'             skin        :        fluffy;',
'  $.water-spirit    {',
'    powers    :     water;',
'                     }',
'  $>thread{',
'     color: depends;',
'   }',
'  powers    :      all-muppet-powers;',
'tag {',
		'some: prop;',
'}',
'}',
];

solve(test1);