'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function solve() {
	var itemIdStart = 0;
	var catalogIdStart = 0;

	function itemIdGenerator() {
		return itemIdStart += 1;
	}

	function catalogIdGenerator() {
		return catalogIdStart += 1;
	}

	function lengthValidator(min, max, str) {
		if (str.length < min || str.length > max) {
			return false;
		} else {
			return true;
		}
	}

	var Item = function () {
		function Item(name, description) {
			_classCallCheck(this, Item);

			this.description = description;
			this.name = name;
			this._id = itemIdGenerator();
		}

		_createClass(Item, [{
			key: 'description',
			get: function get() {
				return this._description;
			},
			set: function set(description) {
				if (!description || 0 === description.length) {
					throw new Error('Item description is invalid');
				}
				this._description = description;
			}
		}, {
			key: 'name',
			get: function get() {
				return this._name;
			},
			set: function set(name) {
				if (!lengthValidator(2, 40, name)) {
					throw new Error('Invalid item name length');
				}
				this._name = name;
			}
		}, {
			key: 'id',
			get: function get() {
				return this._id;
			}
		}]);

		return Item;
	}();

	var Book = function (_Item) {
		_inherits(Book, _Item);

		function Book(name, isbn, genre, description) {
			_classCallCheck(this, Book);

			var _this = _possibleConstructorReturn(this, (Book.__proto__ || Object.getPrototypeOf(Book)).call(this, name, description));

			_this.isbn = isbn;
			_this.genre = genre;
			return _this;
		}

		_createClass(Book, [{
			key: 'isbn',
			get: function get() {
				return this._isbn;
			},
			set: function set(isbn) {
				if (isbn.length !== 10 && isbn.length !== 13) {
					throw new Error('Invalid isbn length');
				}
				if (/\D/.test(isbn)) {
					throw new Error('Isbn contains non-digit');
				}
				this._isbn = isbn;
			}
		}, {
			key: 'genre',
			get: function get() {
				return this._genre;
			},
			set: function set(genre) {
				if (!lengthValidator(2, 20, genre)) {
					throw new Error('Ivalid genre length');
				}
				this._genre = genre;
			}
		}]);

		return Book;
	}(Item);

	return {
		getBook: function getBook(name, isbn, genre, description) {
			return new Book(name, isbn, genre, description);
		},
		getMedia: function getMedia(name, rating, duration, description) {
			//return a media instance
		},
		getBookCatalog: function getBookCatalog(name) {
			//return a book catalog instance
		},
		getMediaCatalog: function getMediaCatalog(name) {
			//return a media catalog instance
		}
	};
}
module.exports = solve;
var _module = solve();
var book = _module.getBook('BookName', '1112211133332', 'Genre', 'Description');
console.log(book.id);

//var catalog = module.getBookCatalog('John\'s catalog');
//
//var book1 = module.getBook('The secrets of the JavaScript Ninja', '1234567890', 'IT', 'A book about JavaScript');
//var book2 = module.getBook('JavaScript: The Good Parts', '0123456789', 'IT', 'A good book about JS');
//catalog.add(book1);
//catalog.add(book2);
//
//console.log(catalog.find(book1.id));
////returns book1
//
//console.log(catalog.find({id: book2.id, genre: 'IT'}));
////returns book2
//
//console.log(catalog.search('js')); 
//// returns book2
//
//console.log(catalog.search('javascript'));
////returns book1 and book2
//
//console.log(catalog.search('Te sa zeleni'))
//returns []