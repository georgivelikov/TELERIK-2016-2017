'use strict';

/* globals module */
function solve() {
    var item, book, media, catalog, bookCatalog, mediaCatalog, validator, idGeneratorFactory;

    idGeneratorFactory = {
        get: function get() {
            return function () {
                var lastId = 0;
                return {
                    getNext: function getNext() {
                        return lastId += 1;
                    }
                };
            }();
        }
    };

    validator = function () {
        var CONSTS = {
            ID: {
                MIN: 0.00000,
                MAX: Infinity
            },
            NAME: {
                MIN: 2,
                MAX: 40
            },
            DESCRIPTION: {
                MIN: 1,
                MAX: Infinity
            },
            GENRE: {
                MIN: 2,
                MAX: 20
            },
            RATING: {
                MIN: 1,
                MAX: 5
            },
            DURATION: {
                MIN: 0.00001,
                MAX: Infinity
            },
            PATTERN: {
                MIN: 1,
                MAX: Infinity
            },
            COUNT: {
                MIN: 1,
                MAX: Infinity
            }
        };

        function validateString(str, min, max) {
            if (typeof str !== 'string' || str.length < min || str.length > max) {
                throw new Error('The string must have between ' + min + ' and ' + max + ' characters');
            }
        }

        function validateNumber(n, min, max) {
            if (typeof n !== 'number' || n < min || n > max) {
                throw new Error('The number must be between ' + min + ' and ' + max);
            }
        }

        function isNotChar(ch) {
            return isNaN(+ch);
        }

        return {
            validateId: function validateId(id) {
                validateNumber(id, CONSTS.ID.MIN, CONSTS.ID.MAX);
            },
            validateName: function validateName(name) {
                validateString(name, CONSTS.NAME.MIN, CONSTS.NAME.MAX);
            },
            validateISBN: function validateISBN(isbn) {
                var isString = typeof isbn === 'string';
                var hasCorrectLength = isbn.length === 10 || isbn.length === 13;
                var hasNotOnlyDigits = isbn.split('').some(isNotChar);
                if (!isString || !hasCorrectLength || hasNotOnlyDigits) {
                    throw new Error('The ISBN must contain exactly 10 or 13 digits');
                }
            },
            validateDescription: function validateDescription(description) {
                validateString(description, CONSTS.DESCRIPTION.MIN, CONSTS.DESCRIPTION.MAX);
            },
            validateRating: function validateRating(rating) {
                validateNumber(rating, CONSTS.RATING.MIN, CONSTS.RATING.MAX);
            },
            validateDuration: function validateDuration(duration) {
                validateNumber(duration, CONSTS.DURATION.MIN, CONSTS.DURATION.MAX);
            },
            validateGenre: function validateGenre(genre) {
                validateString(genre, CONSTS.GENRE.MIN, CONSTS.GENRE.MAX);
            },
            validatePattern: function validatePattern(pattern) {
                validateString(pattern, CONSTS.PATTERN.MIN, CONSTS.PATTERN.MAX);
            },
            validateCount: function validateCount(count) {
                validateNumber(count, CONSTS.COUNT.MIN, CONSTS.COUNT.MAX);
            }
        };
    }();

    item = function (parent) {
        var item, idGenerator;
        idGenerator = idGeneratorFactory.get();
        item = Object.create(parent, {
            name: {
                get: function get() {
                    return this._name;
                },
                set: function set(name) {
                    validator.validateName(name);
                    this._name = name;
                }
            },
            description: {
                get: function get() {
                    return this._description;
                },
                set: function set(description) {
                    validator.validateDescription(description);
                    this._description = description;
                }
            }
        });

        item.init = function (name, description) {
            this.id = idGenerator.getNext();
            this.name = name;
            this.description = description;
            return this;
        };
        return item;
    }({});

    book = function (parent) {
        var book = Object.create(parent, {
            isbn: {
                get: function get() {
                    return this._isbn;
                },
                set: function set(isbn) {
                    validator.validateISBN(isbn);
                    this._isbn = isbn;
                }
            },
            genre: {
                get: function get() {
                    return this._genre;
                },
                set: function set(genre) {
                    validator.validateGenre(genre);
                    this._genre = genre;
                }
            }
        });

        book.init = function (name, isbn, genre, description) {
            parent.init.call(this, name, description);
            this.isbn = isbn;
            this.genre = genre;
            return this;
        };

        return book;
    }(item);

    media = function (parent) {
        var media = Object.create(parent, {
            rating: {
                get: function get() {
                    return this._rating;
                },
                set: function set(rating) {
                    validator.validateRating(rating);
                    this._rating = rating;
                }
            },
            duration: {
                get: function get() {
                    return this._duration;
                },
                set: function set(duration) {
                    validator.validateDuration(duration);
                    this._duration = duration;
                }
            }
        });

        media.init = function (name, rating, duration, description) {
            parent.init.call(this, name, description);
            this.rating = rating;
            this.duration = duration;
            return this;
        };

        return media;
    }(item);

    catalog = function (parent) {
        var catalog,
            idGenerator = idGeneratorFactory.get();

        catalog = Object.create(parent, {
            name: {
                get: function get() {
                    return this._name;
                },
                set: function set(name) {
                    validator.validateName(name);
                    this._name = name;
                }
            }
        });

        catalog.init = function (name) {
            this.id = idGenerator.getNext();
            this.name = name;
            this.items = [];
            return this;
        };

        catalog._validateItem = function (item) {
            validator.validateId(item.id);
            validator.validateName(item.name);
            validator.validateDescription(item.description);
        };

        catalog.add = function (item) {
            if (typeof item === 'undefined') {
                throw new Error('undefined cannot be added to a catalog');
            }

            if (typeof item.length !== 'undefined') {
                return this.add.apply(this, item);
            }
            var itemsToAdd = [],
                items = [].slice.call(arguments, 0),
                that = this;
            items.forEach(function (item) {
                that._validateItem(item);
                itemsToAdd.push(item);
            });
            [].push.apply(this.items, itemsToAdd);
            return this;
        };

        catalog.find = function (options) {
            if (typeof options === 'undefined') {
                throw new Error('Id must be ea number');
            }
            var isOnlyId = false,
                result;
            if (typeof options === 'number') {
                options = {
                    id: options
                };
                isOnlyId = true;
            }
            result = this.items.filter(function (item) {
                return Object.keys(options).every(function (key) {
                    return options[key] === item[key];
                });
            });
            if (isOnlyId) {
                if (result.length) {
                    return result[0];
                }
                return null;
            }
            return result;
        };

        catalog.search = function (pattern) {
            validator.validatePattern(pattern);
            pattern = pattern.toLowerCase();
            return this.items.filter(function (item) {
                return item.name.toLowerCase().indexOf(pattern) >= 0 || item.description.toLowerCase().indexOf(pattern) >= 0;
            });
        };

        return catalog;
    }({});

    bookCatalog = function (parent) {
        var bookCatalog = Object.create(parent);

        bookCatalog.init = function (name) {
            parent.init.call(this, name);
            return this;
        };

        bookCatalog._validateItem = function (book) {
            parent._validateItem.call(this, book);
            validator.validateGenre(book.genre);
            validator.validateISBN(book.isbn);
        };

        bookCatalog.getGenres = function () {
            var genres = {};
            this.items.forEach(function (item) {
                genres[item.genre.toLowerCase()] = 1;
            });
            return Object.keys(genres);
        };

        return bookCatalog;
    }(catalog);

    mediaCatalog = function (parent) {
        var mediaCatalog = Object.create(parent);
        mediaCatalog._isValidItem = function (media) {
            return parent._isValidItem.call(this, media) && validator.validateDuration(media.rating) && validator.validateRating(media.duration);
        };

        mediaCatalog.getTop = function (count) {
            validator.validateCount(count);
            var items = this.items.slice();
            items.sort(function (i1, i2) {
                return i2.rating - i1.rating;
            });

            return items.slice(0, count).map(function (item) {
                return {
                    id: item.id,
                    name: item.name
                };
            });
        };
        /*
            *   descending by duration
            *   ascending by id
        */

        mediaCatalog.getSortedByDuration = function () {
            var itemsToReturn = this.items.slice();
            itemsToReturn.sort(function (i1, i2) {
                if (i1.duration === i2.duration) {
                    return i1.id - i2.id;
                }
                return i2.duration - i1.duration;
            });
        };

        return mediaCatalog;
    }(catalog);

    return {
        getBook: function getBook(name, isbn, genre, description) {
            return Object.create(book).init(name, isbn, genre, description);
        },
        getMedia: function getMedia(name, rating, duration, description) {
            return Object.create(media).init(name, rating, duration, description);
        },
        getBookCatalog: function getBookCatalog(name) {
            return Object.create(bookCatalog).init(name);
        },
        getMediaCatalog: function getMediaCatalog(name) {
            return Object.create(mediaCatalog).init(name);
        }
    };
}

module.exports = solve;