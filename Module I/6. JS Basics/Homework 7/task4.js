function solve(args){
   var text = ""+args[0];
   text = text.split('\n').join('');
   var regex = /<orgcase>(.*)<\/orgcase>|<upcase>(.*)<\/upcase>|<lowcase>(.*)<\/lowcase>/gmi;
   
   while (true){
       var currentMatch;
       var matches = [];
       while (currentMatch = regex.exec(text)) {
            matches.push(currentMatch);
        }

        if (matches.length === 0) {
            break;
        }
        for (var j = 0; j < matches.length; j++) {
            var m = matches[j];
            if (m[1] !== undefined) {
                text = text.replace(m[0], m[1]);
            }
            else if (m[2] !== undefined) {
                text = text.replace(m[0], m[2].toUpperCase());
            }
            else if (m[3] !== undefined) {
                text = text.replace(m[0], m[3].toLowerCase());
            }
        }

        //console.log(text);
   }
   text = text.replace(/<orgcase>|<\/orgase>|<upcase>|<\/upcase>|<\/lowcase>|<lowcase>/gim, '');
   console.log(text);
}

var test1 = [
    [ 'We are <orgcase>liViNgin a <upcase>ye<lowcase>Ta<upcase>thisisUpcase</upcase>down</lowcase>llow submarine</upcase>. We doN\'t</orgcase> have <lowcase>any<upcase>thisisup</upcase>thing</lowcase> else.' ]
];

solve(test1);