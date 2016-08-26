function solve(args){
    var input = args[0];
    var offset = +args[1];

    function compress(text) {
        var encrypted = '';
        var currentEncrypt = text[0];
        for (var i = 1; i < text.length; i++) {
            var char = text[i];
            if (char === text[i - 1]) {
                currentEncrypt += char;
            }
            else {
                var transformed = '' + currentEncrypt.length + currentEncrypt[0];
                if (transformed.length < currentEncrypt.length) {
                    encrypted += transformed;
                }
                else {
                    encrypted += currentEncrypt;
                }
                
                currentEncrypt = char;
            }

            if (i == text.length - 1) {
                var last = '' + currentEncrypt.length + currentEncrypt[0];
                if (last.length < currentEncrypt.length) {
                    encrypted += last;
                }
                else {
                    encrypted += currentEncrypt;
                }
            }
        }

        return encrypted;
    }

    function encrypt(text) {
        var result = '';
        for (var i = 0; i < text.length; i++) {
            var char = text[i];
            if(isNaN(char)){
                var n1 = char.charCodeAt(0);
                var n2;
                if(n1 - offset >= 97){
                    n2 = n1 - offset;
                }
                else {
                    n2 = n1 + 26 - offset;
                }

                var n3 = n1 ^ n2;
                result += '' + n3;
            }
            else {
                result += '' + char;
            }
        }

        return result;
    }


    var compressed = compress(input);
    var crypted = encrypt(compressed);
    
    var sum = 0;
    var product = 1;

    for (var i = 0; i < crypted.length; i++) {
        if(crypted[i]*1 % 2 === 0){
            sum += crypted[i] * 1;
        }
        else {
            product *= crypted[i] * 1;
        }
    }
    //console.log(crypted);
    console.log(sum);
    console.log(product);
}

var test1 = [
    'aaaabbbccccaa',
    '3',
];

solve(test1);