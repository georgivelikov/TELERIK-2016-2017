function solve(args){
    
    var obj = JSON.parse(args[0]);
    var text = ''+args[1];
    text = text.replace(/'/, '"');    
    var regex = /data-bind-(.*?)="(.*?)"/gmi;
    var currentMatch;
    while(currentMatch = regex.exec(text)){
        var index = text.indexOf('>');
        if (text[index - 1] === '/') { // if tag is self closing
            index--;
        }
        var field = currentMatch[1];
        if (field === 'content') {
            var arr = text.split('');
            var x = arr.splice(index + 1, 0, obj[currentMatch[2]]);
            text = arr.join('');
        }
        else {
            var arr2 = text.split('');
            var x2 = arr2.splice(index, 0, " " + field + '="'+ obj[currentMatch[2]] + '"');
            text = arr2.join('');
        }
    }

    console.log(text);
}
var test1 = [
    '{ "songName": "Elena" }',
    '<a data-bind-content="songName" href="https://www.youtube.com/watch?v=84m4hjF39A4"></a>'
];

solve(test1);