///* globals $ */
//
function solve() {
 return function (selector) {
   var template = '<div><table class="items-table"><thead><tr><th>#</th>{{#headers}}<th>{{this}}</th>{{/headers}}</tr></thead><tbody>{{#each items}}<tr><td>{{@index}}</td><td>{{this.col1}}</td><td>{{this.col2}}</td><td>{{this.col3}}</td></tr>{{/each}}</tbody></table></div>'; 
   $(selector).html(template);
 };
};
module.exports = solve;

