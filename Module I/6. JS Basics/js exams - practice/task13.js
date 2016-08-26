function solve(args){
    var n = +args[0];
    var obj = {};
    var sections = {};
    var k = +args[n + 1];

    for (var i = 1; i <= n; i++) {
        var pair = args[i].split(':');
        var key = pair[0];
        var value = pair[1];
        obj[key] = value;
    }

    var output = [];

    var regexForSection = /^\s*@section\s(.*)/;
    var regexForRender = /^\s*@renderSection\("(.+)"\)/;
    var regexForConditional = /^\s*@if \((.+)\)/;
    var regexForLoop = /^\s*@foreach \(var (.+) in (.+)\)/;

    for (var i = n + 2; i < args.length; i++) {
        var line = args[i];
        if (line === undefined) {
            line = '';
        }
        if (regexForSection.test(line)) {
            var sectionName = line.match(regexForSection)[1];
            var sectionBody = [];
            while(true){
                i++;
                if (args[i] === undefined) {
                    args[i] = '';
                }
                line = args[i];
                if (line == '}') {
                    break;
                }
                if (args[i + 1] === undefined) {
                    break;
                }
                sectionBody.push(line);
            }

            sections[sectionName] = sectionBody.join('\n');
        }

        else if(regexForRender.test(line)){
            var nameOfSections = line.match(regexForRender)[1];
            output.push(sections[nameOfSections]);
        }
        else if(regexForConditional.test(line)){
            var nameOfCondition = line.match(regexForConditional)[1];
            if (obj[nameOfCondition] == 'true') {
                continue;
            }
            else {
                while(true){
                    i++;
                    if (args[i] === undefined) {
                        args[i] = '';
                    }
                    if (args[i].indexOf('}') > -1) {
                        break;
                    }
                    if (args[i + 1] === undefined) {
                        break;
                    }
                }
            }
        }
        else if(regexForLoop.test(line)){
            var nameOfItem = line.match(regexForLoop)[1];
            var items = line.match(regexForLoop)[2];
            var bodyOfLoop = [];
            while(true){
                i++;
                if (args[i] === undefined) {
                    args[i] = '';
                }
                if (args[i].indexOf('}') > -1) {
                    break;
                }
                
                if(args[i].indexOf('@') > -1){
                    var replacement = '';
                    var indexOfKliomba = args[i].indexOf('@');
                    var beggining = args[i].substr(0, indexOfKliomba);
                    replacement += beggining;
                    var middle = '';
                    for (var j = indexOfKliomba + 1; j < args[i].length; j++) {
                        var char = args[i][j];
                        middle += char;
                        if (obj.hasOwnProperty(middle)) {
                            replacement += obj[middle];
                            middle = '';
                        }
                    }
                    replacement += middle;

                    bodyOfLoop.push(replacement);
                }
                else {
                    bodyOfLoop.push(args[i]);
                }
                
            }
            var bodyOfLoopFinal = bodyOfLoop.join('\n');
            var toBeReplaced = '@' + nameOfItem;
            var reg = new RegExp(toBeReplaced);
            var currentArr = obj[items].split(',');
            for (var p = 0; p < currentArr.length; p++) {
                var current = currentArr[p];
                var currentBody = bodyOfLoopFinal;
                currentBody = currentBody.replace(reg, current);
                output.push(currentBody);
            }
        }
        else if(line.indexOf('@') > -1){
            while(true){
                var replacement = '';
                var indexOfKliomba = line.indexOf('@');
                var beggining = line.substr(0, indexOfKliomba);
                replacement += beggining;
                var middle = '';
                for (var j = indexOfKliomba + 1; j < line.length; j++) {
                    var char = line[j];
                    middle += char;
                    if (obj.hasOwnProperty(middle)) {
                        replacement += obj[middle];
                        middle = '';
                    }
                }
                replacement += middle;
                line = replacement;
                if (line.indexOf('@') < 0 || (line.indexOf('@') > 0 && line.indexOf('@') == indexOfKliomba)) {
                    break;
                }
            }
            

            output.push(line);
        }
        else if (line.indexOf('}') > -1){
            continue;
        }
        else {
            output.push(line);
        }
    }

    console.log(output.join('\n'));
}

var test1 = [
'5',
'pesho:gosho',
'gosho:pesho',
'if:gadno',
'foreach:hackvane',
'renderSection:ivaylo sucks ;D',
'8',
'<div>',
'    @@if (pesho)',
'    @if (pesho)',
'    @foreach (var nqma in nikoi)',
'    @pesho',
'    @gosho',
'    @renderSection',
'</div>',
];

solve(test1);