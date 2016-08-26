function solve() {
    var name = 'Lsjtujzbo'.split("");
    var result = '';
    for (var i = 0; i < name.length; i++) {
        var c = name[i].charCodeAt() - 1;
        result += String.fromCharCode(c);
    }

    console.log(result);

}

solve();