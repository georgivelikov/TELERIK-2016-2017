function solve(args) {
	var n = +args[0];

    var nHelp = n;
    var a = nHelp / 100 | 0; // hundreds digit
    nHelp = nHelp / 10 | 0;
    var b = nHelp % 10; // decimal digit
    var c = n % 10; // digit

    var hundreds = "";
    var decimals = "";
    var units = "";

    var output = "";

    if (n > 0 && n < 1000)
    {
        switch (a)
        {
            case 1: hundreds = "One hundred"; break;
            case 2: hundreds = "Two hundred"; break;
            case 3: hundreds = "Three hundred"; break;
            case 4: hundreds = "Four hundred"; break;
            case 5: hundreds = "Five hundred"; break;
            case 6: hundreds = "Six hundred"; break;
            case 7: hundreds = "Seven hundred"; break;
            case 8: hundreds = "Eight hundred"; break;
            case 9: hundreds = "Nine hundred"; break;
            case 0: hundreds = ""; break;

        }
        if (b === 1)
        {
            switch (c)
            {
                case 1: decimals = "eleven"; break;
                case 2: decimals = "twelve"; break;
                case 3: decimals = "thirteen"; break;
                case 4: decimals = "fourteen"; break;
                case 5: decimals = "fifteen"; break;
                case 6: decimals = "sixteen"; break;
                case 7: decimals = "seventeen"; break;
                case 8: decimals = "eighteen"; break;
                case 9: decimals = "nineteen"; break;
                case 0: decimals = "ten"; break;
            }
            if (a === 0)
            {
                output = decimals;
            }
            else
            {
                output = hundreds + ' and ' + decimals;
            }
        }
        else
        {
            switch (b)
            {
                case 2: decimals = "twenty"; break;
                case 3: decimals = "thirty"; break;
                case 4: decimals = "fourty"; break;
                case 5: decimals = "fifty"; break;
                case 6: decimals = "sixty"; break;
                case 7: decimals = "seventy"; break;
                case 8: decimals = "eighty"; break;
                case 9: decimals = "ninety"; break;
                case 0: decimals = ""; break;
            }
            switch (c)
            {
                case 1: units = "one"; break;
                case 2: units = "two"; break;
                case 3: units = "three"; break;
                case 4: units = "four"; break;
                case 5: units = "five"; break;
                case 6: units = "six"; break;
                case 7: units = "seven"; break;
                case 8: units = "eight"; break;
                case 9: units = "nine"; break;
                case 0: units = ""; break;
            }
            if (a !== 0 && b !== 0)
            {
                output = hundreds + ' and ' + decimals + ' ' + units;
            }
            else if (a !== 0 && b === 0)
            {
                output = hundreds + ' and ' + units;
            }
            else if (b !== 0)
            {
                output = decimals + ' ' + units;
            }
            else
            {
                output = units;
            }

            if (b == "" && c == "") {
                output = hundreds;
            }
        }
        outputFormated = output.charAt(0).toUpperCase() + output.slice(1);
        console.log(outputFormated);
    }
    else if (n === 0)
    {
        console.log("Zero");
    }
}