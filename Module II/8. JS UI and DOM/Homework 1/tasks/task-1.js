 module.exports = function () {
   return function (element, contents) {
       var currentElement;
       var df = document.createDocumentFragment();
       if (typeof element === 'string') {
           currentElement = document.getElementById(element);
       }
       else if(element instanceof HTMLElement) {
           currentElement = element;
       }
       else {
           throw new Error();
       }
       for (var i = 0; i < contents.length; i += 1) {
         var div = document.createElement('div');
         if(typeof contents[i] !== 'string' && typeof contents[i] !== 'number'){
             throw new Error();
         }
         div.innerHTML = contents[i];
         df.appendChild(div);
       }
       currentElement.innerHTML = '';
       currentElement.appendChild(df);
   };
 };

//  function solve (element, contents) {
//       var currentElement;
//       var df = document.createDocumentFragment();
//       debugger
//       if (typeof element === 'string') {
//           currentElement = document.getElementById(element);
//           currentElement.innerHTML = '';
//       }
//       else if(element instanceof HTMLElement) {
//           currentElement = element;
//           currentElement.innerHTML = '';
//       }
//       else if (element === null || contents === null || element === undefined || contents === undefined){
//           throw new Error();
//       }
//       for (var i = 0; i < contents.length; i += 1) {
//         var div = document.createElement('div');
//         if(typeof contents[i] !== 'string' && typeof contents[i] != 'number'){
//             throw new Error();
//         }
//         div.innerHTML = contents[i];
//         df.appendChild(div);
//       }
//        currentElement.appendChild(df);
//    }
// solve('root', [ 'dasd', 1, 'sdasda']);
