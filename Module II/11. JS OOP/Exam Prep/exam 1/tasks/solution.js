function solve(){   
	var itemIdStart = 0;
	var catalogIdStart = 0;

	function generateItemId(){
		return itemIdStart += 1;
	}

	function generateCatalogId(){
		return catalogIdStart += 1;
	}

	var validator = (function () {
        function isNullOrUndefined(value) {
            if (value === null || value === undefined) {
                return true;
            } else {
				return false;
			}
        }
 
        function isInstanceOf(child, parent) {
            if (child instanceof parent) {
                return true;
            } else {
				return false;
			}
        }

        function isNumber(value) {
            if (isNaN(value)){
                return false;
            } else {
				return true;
			}
        }
 
        function isPositiveNumber(value) {
            if (value > 0) {
                return true;
            } else {
				return false;
			}
        }

		function isNumberInRange(value, min, max) {
            if(min <= value && value <= max){
				return true;
			} else {
				return false;
			}
        }

 		function isNumberType(value) {
            if (typeof (value) === 'number') {
                return true;
            } else {
				return false;
			}
        }

 		function isStringType(value) {
            if (typeof (value) === 'string') {
                return true;
            } else {
				return false;
			}
        }
        
        function isEmptyString(value) {
            if(/^\s*$/.test(value)){
				return true;
			} else {
				return false;
			}
        }
 
        function isStringLengthValid(str, min, max) {
            if(min <= str.length && str.length <= max) {
				return true;
			} else {
				return false;
			}
        }
 
        function containsOnlyDigits(value) {
            if (/^\d+$/.test(value)) {
                return true;
            } else {
				return false;
			}
        }
 
        function containsOnlyLetters(value) {
            if (/^[a-zA-Z]+$/.test(value)) {
                return true;
            } else {
				return false;
			}
        }
 
        function containsOnlyLettersAndDigits(value) {
            if (!(/^\w+$/g.test(value))) {
                return true;
            } else {
				return false;
			}
        }
 
        return {
			isNullOrUndefined : isNullOrUndefined,
			isInstanceOf : isInstanceOf,
			isNumber : isNumber,
			isNumberType : isNumberType,
			isPositiveNumber : isPositiveNumber,
			isNumberInRange : isNumberInRange,
			isStringType : isStringType,
			isStringLengthValid : isStringLengthValid,
			isEmptyString : isEmptyString,
			containsOnlyDigits : containsOnlyDigits,
			containsOnlyLetters : containsOnlyLetters,
			containsOnlyLettersAndDigits : containsOnlyLettersAndDigits
        };
    } ());

	class Item {
		constructor(name, description){
			this.name = name;
			this.description = description;
			this._id = generateItemId();
		}

		get name(){
			return this._name;
		}
		set name(value){
			if(!validator.isStringType(value)){
				throw new Error('Name is not string');
			}
			if(!validator.isStringLengthValid(value, 2, 40)){
				throw new Error('Name length is not valid');
			}

			this._name = value;
		}

		get description(){
			return this._description;
		}
		set description(value){
			if(!validator.isStringType(value)){
				throw new Error('Description is not string');
			}
			if(validator.isEmptyString(value)){
				throw new Error('Description is empty string');
			}

			this._description = value;
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
		set isbn(value){
			if(!validator.isStringType(value)){
				throw new Error('Isbn is not string');
			}
			if(!validator.containsOnlyDigits(value)){
				throw new Error('Isbn does not contain only digits');
			}
			if(value.length !== 10 && value.length !== 13){
				throw new Error('Isbn length is not valid');
			}

			this._isbn = value;
		}

		get genre(){
			return this._genre;
		}
		set genre(value){
			if(!validator.isStringType(value)){
				throw new Error('Genre is not string');
			}
			if(!validator.isStringLengthValid(value, 2, 20)){
				throw new Error('Genre length is not valid');
			}

			this._genre = value;
		}
	}

	class Media extends Item {
		constructor(name, rating, duration, description){
			super(name, description);
			this.rating = rating;
			this.duration = duration;
		}

		get duration(){
			return this._duration;
		}
		set duration(value){
			if(!validator.isPositiveNumber(value)){
				throw new Error("Duration is not a number");
			}
			if(!validator.isNumberType(value)){
				throw new Error('Duration is not a number');
			}

			this._duration = value;	
		}
		get rating(){
			return this._rating;
		}
		set rating(value){
			if(!validator.isNumberType(value)){
				throw new Error('Rating is not a number');
			}
			if(!validator.isNumberInRange(value, 1, 5)){
				throw new Error('Rating is not in range');
			}
			this._rating = value;
		}
	}

	class Catalog {
		constructor(name){
			this.name = name;
			this.id = generateCatalogId();
			this.items = [];
		}

		get name(){
			return this._name;
		}
		set name(value){
			if(!validator.isStringType(value)){
				throw new Error();
			}
			if(!validator.isStringLengthValid(value, 2, 40)){
				throw new Error();
			}
			this._name = value;
		}

		get acceptedType(){
			return Item;
		}

		add(...inputItems){
			if(inputItems.length == 0){
				throw new Error();
			}
			if(Array.isArray(inputItems[0])){
				inputItems = inputItems[0];
			}

			for(let i = 0; i < inputItems.length; i += 1){
				if(!(inputItems[i] instanceof this.acceptedType)){
					throw new Error('Invalid type');
				}
			}

			this.items.push(...inputItems);

			return this;
		}

		find(arg){
			if(validator.isNumberType(arg)){
				var id = arg;
				var searchedItem = null;
				for(var i = 0; i < this.items.length; i += 1){
					if(this.items[i].id == id){
						searchedItem = this.items[i];
						break;
					}
				}

				return searchedItem;
			} 
			else if(typeof arg === 'object' && arg !== null){
				var results = [];

				for(let i = 0; i < this.items.length; i += 1){
					var currentItem = this.items[i];
					var isValid = true;
					for(let key in arg){
						if(arg[key] !== currentItem[key]){
							isValid = false;
							break;
						}
					}

					if(isValid){
						results.push(currentItem);
					}
				}

				return results;
			} 
			else {
				throw new Error();
			}
		}

		search(pattern){
			if(!validator.isStringType(pattern) || validator.isEmptyString(pattern)){
				throw new Error();
			}

			var results = [];

			for(var i = 0; i < this.items.length; i += 1){
				var currentItem = this.items[i];

				if(currentItem.name.indexOf(pattern) > -1 || currentItem.description.indexOf(pattern) > - 1){
					results.push(currentItem);
				}
			}

			return results;
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
			var results = new Set();
			for(var i = 0; i < this.items.length; i += 1){
				var name = this.items[i].genre.toLowerCase();
				results.add(name);
			}

			return Array.from(results);
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
			if(!validator.isNumberType(count)){
				throw new Error();
			}
			if(count < 1){
				throw new Error();
			}

			function compare(a, b) {
				if (a.rating > b.rating){
					return 1;
				}
				if (a.rating < b.rating){
					return -1;
				}

				return 0;
			}

			var sortedItems = this.items.sort(compare);

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
			function compare(a, b) {
				if (a.duration > b.duration){
					return -1;
				}
				else if (a.duration < b.duration){
					return 1;
				}
				else {
					return a.id - b.id;
				}
				
			}

			var sortedItems = this.items.sort(compare);

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

//var module = solve();
//
//var catalog = module.getMediaCatalog('John\'s catalog');
//
//var media1 = module.getMedia('The secrets of the JavaScript Ninja', 1, 2, 'A book about JavaScript');
//var media2 = module.getMedia('JavaScript: The Good Parts', 4, 4, 'A good book about JS');
//var media3 = module.getMedia('JavaScript: The Good Partsggg', 4, 3, 'A good book about JS');
//catalog.add();

