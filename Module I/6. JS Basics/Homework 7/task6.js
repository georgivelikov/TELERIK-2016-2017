function solve(args) {
    var output = '';
    var matchTags = /<.*?>/ig;

    for (var line of args) {
        output += line.replace(matchTags, '').trim();
    }

    console.log(output);
}

var test1 = [
    '<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
]

solve(test1);