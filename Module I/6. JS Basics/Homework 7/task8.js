function solve(args) {
    var StartsWith = /^<a href="/,
        regexBegin = /<a href="/g,
        matchExtractLable = /(.*?)">(.*?)<\/a>(.*)/,
        part,
        splited,
        result = '';

    splited = args[0].split(regexBegin);

    if (!args[0].match(StartsWith)) {
        result += splited.shift();
    }

    part = splited.map(m => {
        var match = m.match(matchExtractLable);
        if (match) {
            return '[' + match[2] + '](' + match[1] + ')' + match[3];
        } else {
            return m;
        }
    });

    result += part.join('');

    console.log(result);
}

text = ['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>'];

solve(text);