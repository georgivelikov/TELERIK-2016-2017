/* Task Description */
/* 
	*	Create a module for working with books
		*	The module must provide the following functionalities:
			*	Add a new book to category
				*	Each book has unique title, author and ISBN
				*	It must return the newly created book with assigned ID
				*	If the category is missing, it must be automatically created
			*	List all books
				*	Books are sorted by ID
				*	This can be done by author, by category or all
			*	List all categories
				*	Categories are sorted by ID
		*	Each book/catagory has a unique identifier (ID) that is a number greater than or equal to 1
			*	When adding a book/category, the ID is generated automatically
		*	Add validation everywhere, where possible
			*	Book title and category name must be between 2 and 100 characters, including letters, digits and special characters ('!', ',', '.', etc)
			*	Author is any non-empty string
			*	Unique params are Book title and Book ISBN
			*	Book ISBN is an unique code that contains either 10 or 13 digits
			*	If something is not valid - throw Error
*/
function solve() {
	var library = (function () {
		var books = [];
		var categories = [];

		function checkForNullOrUndefined(property){
			if(typeof(property) === 'undefined' || property === null){
				return true;
			} else {
				return false;
			}
		}

		function validateLength(min, max, length){
			if(length < min || length > max){
				return false;
			} else {
				return true;
			}
		}

		var uniqueTitleHolder = [];
		var uniqueIsbnHolder = [];

		function validateBook(book){
			if(checkForNullOrUndefined(book.title) || checkForNullOrUndefined(book.author) || 
				checkForNullOrUndefined(book.isbn) || checkForNullOrUndefined(book.category)){
				throw new Error();
			}

			if(!validateLength(2, 100, book.title.length) || !validateLength(2, 100, book.category.length)){
				throw new Error();
			}	

			if((!book.author || /^\s*$/.test(book.author))){
				throw new Error();
			}

			if(book.isbn.length !== 10 && book.isbn.length !== 13){
				throw new Error();
			}

			if(/\D/.test(book.isbn)){// or isNaN
				throw new Error();
			}

			if(uniqueTitleHolder.indexOf(book.title) > -1 || uniqueIsbnHolder.indexOf(+book.isbn) > -1){
				throw new Error();
			}
		}

		function listBooks(argument) {
			function compare(a, b) {
				if (a.ID > b.ID)
					return 1;
				if (a.ID < b.ID)
					return -1;
				return 0;
			}

			books.sort(compare);

			var resut = [];
			if(argument !== undefined){
				result = books.filter(b => (b.category === argument.category || b.author === argument.author));
				return result;
			}

			return books;
		}

		function addBook(book) {
			validateBook(book);
			uniqueIsbnHolder.push(+book.isbn);
			uniqueTitleHolder.push(book.title);
			book.ID = books.length + 1;
			books.push(book);
			if(categories.indexOf(book.category) < 0){
				categories.push(book.category);
			}
			return book;
		}

		function listCategories() {
			function compare(a, b) {
			if (a.ID > b.ID)
				return 1;
			if (a.ID < b.ID)
				return -1;
			return 0;
			}

			categories.sort(compare);

			return categories;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	} ());
	return library;
}

var library = solve();
console.log(library);
var book1 = {
	title: 'Title',
	author: 'Autor',
	isbn: '1234567890',
	category: 'Books'
};
library.books.add(book1);
module.exports = solve;
