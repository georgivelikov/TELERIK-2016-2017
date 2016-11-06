/* globals $ */

/* 

Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:   
  * The UL must have a class `items-list`
  * Each of the LIs must:
    * have a class `list-item`
    * content "List item #INDEX"
      * The indices are zero-based
  * If the provided selector does not selects anything, do nothing
  * Throws if
    * COUNT is a `Number`, but is less than 1
    * COUNT is **missing**, or **not convertible** to `Number`
      * _Example:_
        * Valid COUNT values:
          * 1, 2, 3, '1', '4', '1123'
        * Invalid COUNT values:
          * '123px' 'John', {}, [] 
*/

function solve(){
  return function (selector, count) {
      if(typeof selector !== 'string'){
        throw 42; 
      }
      if (typeof count !== 'number' || count <= 0) {
        throw 42;  
      }
      var $root = $(selector);
      var $ul = $('<ul>').addClass('items-list');
      
      for(var i = 0; i < count; i += 1){
        var content = 'List item #' + i;
        var $li = $('<li>').addClass('list-item').html(content);
        $ul.append($li);
        
      }
      $root.append($ul);
  };
};

module.exports = solve;