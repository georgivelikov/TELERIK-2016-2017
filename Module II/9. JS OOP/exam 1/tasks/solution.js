function solve(){   
	var itemIdStart = 0;
	var catalogIdStart = 0;

	function generateItemId(){
		return itemIdStart += 1;
	}

	function generateCatalogId(){
		return catalogIdStart += 1;
	}

	function checkForNullOrUndefined(property){
		if(typeof(property) === 'undefined' || property === null){
			return true;
		} else {
			return false;
		}
	}

	function lengthValidator(min, max, length){
		if(length < min || length > max){
			return false;
		} else {
			return true;
		}
	}

	class Item {
		constructor(name, description){
			this.description = description;
			this.name = name;
			this._id = generateItemId();
		}

		get description(){
			return this._description;
		}

		set description(description){
			if(!description || 0 === description.length){
				throw new Error('Item description is invalid');
			}
			if(checkForNullOrUndefined(description)){
				throw new Error('Undefined or null item description');
			}
			this._description = description;
		}

		get name(){
			return this._name;
		}

		set name(name){
			if(!lengthValidator(2, 40, name.length)){
				throw new Error('Invalid item name length');
			}
			if(checkForNullOrUndefined(name)){
				throw new Error('Undefined or null item name');
			}
			this._name = name;
		}

		get id(){
			return this._id;
		}

	}

	class Book extends Item {
		constructor(name, isbn, genre, description){
			super(name, description);
			this.isbn = isbn;
			this.genre = genre;
		}

		get isbn(){
			return this._isbn;
		}
		set isbn(isbn){
			if(isbn.length !== 10 && isbn.length !== 13){
				throw new Error('Invalid isbn length');
			}
			if(/\D/.test(isbn)){
				throw new Error('Isbn contains non-digit');
			}
			if(checkForNullOrUndefined(isbn)){
				throw new Error('Undefined or null book isbn');
			}
			this._isbn = isbn;
		}
		get genre(){
			return this._genre;
		}
		set genre(genre){
			if(!lengthValidator(2, 20, genre.length)){
				throw new Error('Ivalid genre length');
			}
			if(checkForNullOrUndefined(genre)){
				throw new Error('Undefined or null book genre');
			}
			this._genre = genre;
		}
	}

	class Media extends Item {
		constructor(name, rating, duration, description){
			super(name, description);
			this.rating = rating;
			this.duration = duration;
		}

		get rating(){
			return this._rating;
		}
		set rating(rating){
			if(!lengthValidator(1, 5, rating)){
				throw new Error('Invalid media rating');
			}
			if(checkForNullOrUndefined(rating)){
				throw new Error('Undefined or null media rating');
			}

			this._rating = rating;
		}

		get duration(){
			return this._duration;
		}
		set duration(duration){
			if(duration <= 0){
				throw new Error('Media duration must be possitive');
			}

			if(checkForNullOrUndefined(duration)){
				throw new Error('Undefined or null media duration');
			}
			this._duration = duration;
		}
	}

	class Catalog {
		constructor(name){
			this.name = name;
			this._id = generateCatalogId();
			this.items = [];
		}

		get name(){
			return this._name;
		}
		set name(name){
			if(!lengthValidator(2, 40, name.length)){
				throw new Error('Invalid catalog name length');
			}
			if(checkForNullOrUndefined(name)){
				throw new Error('Undefined or null catalog name');
			}

			this._name = name;
		}

		get acceptedType(){
			return Item;
		}

		get id(){
			return this._id;
		}

		add(){
			var inputItems = [];

			if(arguments[0] instanceof Array){
				inputItems = arguments[0];
			} else {
				for(var i = 0; i < arguments.length; i +=1){
					inputItems.push(arguments[i]);
				}
			}

			if(inputItems.length === 0){
				throw new Error('No items in input');
			}

			for(var j = 0; j < inputItems.length; j += 1){
				var currentItem = inputItems[j];
				if(checkForNullOrUndefined(currentItem)){
					throw new Error('Input item is null or undefined');
				}
				if(!(currentItem instanceof this.acceptedType)){
					throw new Error('Item must be of the accepted type');
				}
			}

			for(var k = 0; k < inputItems.length; k += 1){
				this.items.push(inputItems[k]);
			}

			return this; // for chaining
		}

		find(options){
			if(checkForNullOrUndefined(options)){
				throw new Error();
			}

			var result;
			if(!(options instanceof Object)){
				var providedId = options;
				if(isNaN(providedId)){
					throw new Error();
				}
				result = null;

				for(var i = 0; i < this.items.length; i +=1){
					var currentItem = this.items[i];
					if(currentItem.id == providedId){
						return currentItem;
					}
				}

				return null;
			} else {
				result = [];
				for(var i = 0; i < this.items.length; i += 1){
					var currentItem = this.items[i];
					var isValid = true;
					for (var key in options) {
						if(currentItem[key] !== options[key]){
							isValid = false;
							break;
						}
					}

					if(isValid){
						result.push(currentItem);
					}
				}
				
				return result;
			}			
		}

		search(inputPattern){
			if(checkForNullOrUndefined(inputPattern) || /^\s*$/.test(inputPattern)){
				throw new Error();
			}
			var pattern = inputPattern.toLowerCase();
			var result = [];

			for(var i = 0; i < this.items.length; i += 1){
				var currentItem = this.items[i];
				var currentName = currentItem.name.toLowerCase();
				var currentDescription = currentItem.description.toLowerCase();
				 
				if(currentName.indexOf(pattern) > -1 || currentDescription.indexOf(pattern) > -1){
					result.push(currentItem);
				}
			}

			return result;
		}
	}

	class BookCatalog extends Catalog{
		constructor(name){
			super(name);
		}

		get acceptedType(){
			return Book;
		}

		getGenres(){
			var result = [];
			for(var i = 0; i < this.items.length; i += 1){
				var currentItem = this.items[i];
				if(result.indexOf(currentItem.genre) < 0){
					result.push(currentItem.genre);
				}
			}

			return result;
		}
	}

	class MediaCatalog extends Catalog{
		constructor(name){
			super(name);
		}

		get acceptedType(){
			return Media;
		}

		getTop(count){
			if(checkForNullOrUndefined(count)){
				throw new Error();
			}
			if(isNaN(count) || count < 1){
				throw new Error();
			}

			function compare(a,b) {
				if (a.rating > b.rating){
					return -1;
				}
				if (a.rating < b.rating){
					return 1;
				}
				return 0;
			}
			var sortedItems = this.items.slice(0);

			sortedItems.sort(compare);

			var result = [];
			if(sortedItems.length < count){
				count = sortedItems.length;
			}

			for(var i = 0; i < count; i++){
				var obj = {
					id: sortedItems[i].id,
					name: sortedItems[i].name
				};

				result.push(obj);
			}

			return result;
		}

		getSortedByDuration(){
			function compare(a,b) {
				if (a.duration < b.duration){
					return -1;
				}
				else if (a.duration > b.duration){
					return 1;
				}
				else {
					if(a.id > b.id) {
						return 1;
					}
					else if(a.id < b.id){
						return -1;
					}
					else {
						return 0;
					}
				}
				
			}

			var sortedItems = this.items.slice(0);

			sortedItems.sort(compare);

			return sortedItems;
		}
	}

	return {
		getBook: function (name, isbn, genre, description) {
			return new Book(name, isbn, genre, description);
		},
		getMedia: function (name, rating, duration, description) {
			return new Media(name, rating, duration, description);
		},
		getBookCatalog: function (name) {
			return new BookCatalog(name);
		},
		getMediaCatalog: function (name) {
			return new MediaCatalog(name);
		}
	};
}
module.exports = solve;

var module = solve();

var catalog = module.getMediaCatalog('John\'s catalog');

var media1 = module.getMedia('The secrets of the JavaScript Ninja', '1', '2', 'A book about JavaScript');
var media2 = module.getMedia('JavaScript: The Good Parts', '4', '3', 'A good book about JS');
var media3 = module.getMedia('JavaScript: The Good Partsggg', '4', '3', 'A good book about JS');
catalog.add(media1);

console.log(catalog.getTop(2));