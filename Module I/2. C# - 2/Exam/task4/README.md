<img src="https://raw.githubusercontent.com/TelerikAcademy/Common/master/logos/telerik-header-logo.png" />

#### _Telerik Academy Season 2016-2017 / C# Advanced Exam - 31 May 2016_

# SoupScript

## Description

Do you know who **Suzandokan** is? No? Well, **Suzandokan** is a famous pirate (_“**Suzandokan**, male s dvata noja”_). But few people know that **Suzandokan** has a **tsherpak** and that
 he loves to cook soup with it. **Suzandokan**'s soup is very special - it's a letter soup.
 
![alphabet-soup-help](http://asperkids.com/wp-content/uploads/2013/10/alphabet-soup.jpg)

Now, what exactly is so special about this soup? When **Suzandokan** cooked this soup for the very first time, he spilled the first **tsherpak** of the soup on the floor. The letters splattered all over the floor and 
miraculously, they arranged themselves in something like that:

```js
var handlebars = window.handlebars || window.Handlebars;
```

This was the first javascript code that the world has ever seen. At the time though, this language was known as **SoupScript**

Your task is simple. You will receive a **SoupScript** from **Suzandokan**'s **tsherpak** and you have to format it according to the specifications below.

## SoupScript Specifications

#### The code in each scope (a every code wrapped in {} is in a separate scope) should be indented by **4** whitespaces to the right.
- _Code that is not formatted_:

```js
function soup() {
console.log('pesho');
var ivan = 'penka';
while(true) {
console.log('never gonna stop me');    
}
return false;
}
```

- _Formatted code_:

```js
function soup() {
....console.log('pesho');
....var ivan = 'penka';
....while(true) {
........console.log('never gonna stop me');    
....}
....return false;
}
```

#### There should not be any unnecessary whitespaces in loops, variable declarations, expressions, function calls and function declarations. Empty lines must also be removed.
- _Code that is not formatted_:

```js
var   n =    3;
console    .log(15);

function printNumber       (number   ,   sign) {
    console.   log  (number    *    sign);
    var horrorfulExpression = 3+4   *  5 - !  true;
    console.log(horrorfulExpression);
}
```

- _Formatted code_:

```js
var n = 3;
console.log(15);
function printNumber(number, sign) {
    console.log(number * sign);
    var horrorfulExpression = 3 + 4 * 5 - !true;
    console.log(horrorfulExpression);
}
```

#### Comments should always go on a separate line - more specifically, if one line contains code and a comment, move the comment on the line before the current one. Also, you should not format the comments content in any way.
- _Code that is not formatted_:

```js
// random comment
// when noobs lose
console.log('Game over'); //that's what they see
```

- _Formatted code_:

```js
// random comment
// when noobs lose
//that's what they see
console.log('Game over');
```

#### There should be a single whitespace between all closing round and opening curly braces.
- _Code that is not formatted_:

```js
if(true){
    console.log('ujasna zadacha');
}
```

- _Formatted code_:

```js
if(true) {
    console.log('ujasna zadacha');
}
```

## Input
- On the first line you will receive an integer **N** - the number of lines in **Suzandokan**'s **SoupScript**.
- On the next **N** lines each, you will receive a single line, each a part of the **SoupScript** code you must format.

## Output
- Output the formatted **SoupScript** code.

## Constraints
- **Language constraints**:
  - **SoupScript** features the following parts of javascript:
    - `for` and `while` loops, `if` statements
    - `variable` and `function` declarations
    - `operators` (+, -, =, <, >, !) and `expressions` - they look just like C# `expressions`. All operators are binary, save for the `!` operator, which is unary.
    - single-line `comments`
  - The **SoupScript** code will always be valid - there will be no missing brackets, use of operators on wrong places and so on.
  - There **will not** be any code in strings or comments.
    - _Example_: `console.log('console.log(    )')`.
    - _Example_: `// console.log(1)`
  - You **should not** format the content of the comments in any way
  - There won't be any empty comments.
  - All round braces will be on one line.
  - Two or more curly braces will never be on the same line. Every opening curly brace will be on the same row with it's statement. Every closing curly brace will be on it's own separate line.

- **Task constraints**:
  - The input will always be valid and in the described format. There is no need to validate it explicitly.
  - No line from the received **SoupScript** will be longer than 100 symbols.
  - **Some of the cases test only a part of the features**, so a partial implementation might still yield points. Don't give up :) .
  - 1 < **N** < 60
  - **Time limit: 0.05 s**
  - **Memory limit: 16 MB**

## Sample tests

### Input
```js
42
    var   n =    3; // ahoy
var r = 'r'; //such smart variable
console    .log(     15);
var g=3;

function printNumber       ()    {
// kinda good comment
    //good comment
    console.log(    3     ); //     another bad comment
function gosho( cat, horse    ,  hen  ){ // bad comment
    'use strict';
}
}
for(   var i =   0, j =     5   ;   i    <    3    ;    i    = i+   1   )       {
    console  .   log(  'pe-zo'   )   ;
                    while(true  ) {
                        var p = 'some string';
                             }
while( ! !!true  ) {
    var p = ! 'never gonna stahp me';
         }
}

while(true  ) {
    var p = 'gosho';
         }

var   s =    3;
console    .log(15);

function printNumber       () {
    console.log(3);
}

function soup() {
console.log('pesho');
var ivan = 'penka';
while(true) {
console.log('topkek');
}
return false;
}
```

### Output
```js
// ahoy
var n = 3;
//such smart variable
var r = 'r';
console.log(15);
var g = 3;
function printNumber() {
    // kinda good comment
    //good comment
    //     another bad comment
    console.log(3);
    // bad comment
    function gosho(cat, horse, hen) {
        'use strict';
    }
}
for(var i = 0, j = 5;i < 3;i = i + 1) {
    console.log('pe-zo');
    while(true) {
        var p = 'some string';
    }
    while(!!!true) {
        var p = !'never gonna stahp me';
    }
}
while(true) {
    var p = 'gosho';
}
var s = 3;
console.log(15);
function printNumber() {
    console.log(3);
}
function soup() {
    console.log('pesho');
    var ivan = 'penka';
    while(true) {
        console.log('topkek');
    }
    return false;
}
```
