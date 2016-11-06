/* globals require, describe, it */
var expect = require('chai').expect,
    result = require('../tasks/solution')();

/* beforeach: start */
var utils = (function () {
    var CONSTS = {
        NAME: {
            MIN: 2,
            MAX: 40
        },
        DESCRIPTION: {
            MIN: 1,
            MAX: 1000
        },
        ISBN10: {
            LENGTH: 10
        },
        ISBN13: {
            LENGTH: 13
        },
        GENRE: {
            MIN: 2,
            MAX: 20
        },
        DURATION: {
            MIN: 0,
            MAX: 10000
        },
        RATING: {
            MIN: 1,
            MAX: 5
        },
        CHARS: 'QWERTYUIOPASDFGHJKLZXCVBNM _.-?!,\'\":;',
        DIGIS: '0123456789'
    };

    function getRandom(min, max) {
        if (typeof (max) === 'undefined') {
            max = min;
            min = 0;
        }
        /* jshint ignore: start */
        return (Math.random() * (max - min) + min) | 0;
        /* jshint ignore: end */
    }

    function getRandomString(chars, length) {
        return Array.apply(null, {
            length: length
        }).map(function () {
            return chars[getRandom(chars.length)];
        }).join('');
    }

    var utils = {
        valid: {
            getName: function () {
                var length = getRandom(CONSTS.NAME.MIN, CONSTS.NAME.MAX);
                return getRandomString(CONSTS.CHARS, length);
            },
            getISBN10: function () {
                var length = 10;
                return getRandomString(CONSTS.DIGIS, length);
            },
            getISBN13: function () {
                var length = 13;
                return getRandomString(CONSTS.DIGIS, length);
            },
            getGenre: function () {
                var length = getRandom(CONSTS.GENRE.MIN, CONSTS.GENRE.MAX);
                return getRandomString(CONSTS.CHARS, length);
            },
            getDescription: function () {
                var length = getRandom(CONSTS.DESCRIPTION.MIN, CONSTS.DESCRIPTION.MAX);
                return getRandomString(CONSTS.CHARS, length);
            },
            getDuration: function () {
                return getRandom(0, 1000);
            },
            getRating: function () {
                return getRandom(1, 5);
            }
        },
        invalid: {
            getShorterName: function () {
                var length = getRandom(0, CONSTS.NAME.MIN - 1);
                return getRandomString(CONSTS.CHARS, length);
            },
            getLongerName: function () {
                var length = getRandom(CONSTS.NAME.MAX + 1, CONSTS.NAME.MAX * 2);
                return getRandomString(CONSTS.CHARS, length);
            },
            getInvalidISBN10WithLetters: function () {
                var isbn = utils.valid.getISBN10().split(''),
                    index = getRandom(isbn.length);
                isbn.splice(index, 1, 'a');
                return isbn;
            },
            getInvalidISBN13WithLetters: function () {
                return utils.valid.getISBN13().substring(1);
            },
            getInvalidISBNNot10or13: function () {
                var isbn = utils.valid.getISBN13().split(''),
                    index = getRandom(isbn.length);
                isbn.splice(index, 1, 'a');
                return isbn;
            },
            getShorterDescription: function () {
                var length = getRandom(0, CONSTS.DESCRIPTION.MIN - 1);
                return getRandomString(CONSTS.CHARS, length);
            },
            getLongerDescription: function () {
                var length = getRandom(CONSTS.DESCRIPTION.MAX + 1, CONSTS.DESCRIPTION.MAX * 2);
                return getRandomString(CONSTS.CHARS, length);
            },
            getShorterGenre: function () {
                var length = getRandom(0, CONSTS.GENRE.MIN - 1);
                return getRandomString(CONSTS.CHARS, length);
            },
            getLongerGenre: function () {
                var length = getRandom(CONSTS.GENRE.MAX + 1, CONSTS.GENRE.MAX * 2);
                return getRandomString(CONSTS.CHARS, length);
            },
            getSmallRating: function () {
                return 0;
            },
            getLargeRating: function () {
                return getRandom(6, 1000);
            }
        }
    };

    return utils;
}());
/* beforeach: end */

describe('Academy Catalogs', function () {

    describe('MediaCatalog tests', function () {
        describe('Valid tests', function () {
            // test 21
            beforeEach(function(done) {
                result = require('../tasks/solution')();
                done();
            });
            it('expect getMediaCatalog to exist, to be a function and to return object with properties name and unique id and methods: add(), find() with 1 param and search() with 1 param', function () {
                var name = utils.valid.getName(),
                    catalog = result.getMediaCatalog(name);

                expect(result.getMediaCatalog).to.exist;
                expect(result.getMediaCatalog).to.be.a('function');
                expect(catalog).to.be.a('object');
                expect(catalog.name).to.be.a('string');
                expect(catalog.name).to.equal(name);

                expect(catalog.items).to.exist;
                expect(Array.isArray(catalog.items)).to.be.true;

                expect(catalog.add).to.exist;
                expect(catalog.add).to.be.a('function');

                expect(catalog.find).to.exist;
                expect(catalog.find).to.be.a('function');
                expect(catalog.find.length).to.equal(1);

                expect(catalog.search).to.exist;
                expect(catalog.search).to.be.a('function');
                expect(catalog.search.length).to.equal(1);

                expect(catalog.getTop).to.exist;
                expect(catalog.getTop).to.be.a('function');
                expect(catalog.getTop.length).to.equal(1);

                expect(catalog.getSortedByDuration).to.exist;
                expect(catalog.getSortedByDuration).to.be.a('function');
                expect(catalog.getSortedByDuration.length).to.equal(0);
            });
            // test 22
            it('expect mediaCatalog.add() to add media only and to work with array or media separated with comma', function () {
                var catalog,
                    name,
                    description,
                    rating,
                    duration,
                    medias,
                    resultOfAdd,
                    i;

                catalog = result.getMediaCatalog(utils.valid.getName());
                medias = [];
                for (i = 0; i < 3; i += 1) {
                    name = utils.valid.getName();
                    rating = utils.valid.getRating();
                    duration = utils.valid.getDuration();
                    description = utils.valid.getDescription();
                    medias.push(result.getMedia(name, rating, duration, description));
                }

                // test single item add
                resultOfAdd = catalog.add(medias[0]);
                expect(catalog.items[0]).to.equal(medias[0]);
                expect(resultOfAdd).to.equal(catalog);

                //test multiple items add
                catalog.add(medias[1], medias[2]);
                expect(catalog.items[1]).to.equal(medias[1]);
                expect(catalog.items[2]).to.equal(medias[2]);

                // test array addmedias
                catalog.add(medias);
                expect(catalog.items[3]).to.equal(medias[0]);
                expect(catalog.items[4]).to.equal(medias[1]);
                expect(catalog.items[5]).to.equal(medias[2]);
            });
            // test 23
            it('expect mediaCatalog.getTop() to get unique genres', function () {
                var catalog,
                    name,
                    rating,
                    media,
                    findResult,
                    top,
                    i,
                    id = 100,
                    len = 20,
                    medias = [];

                catalog = result.getMediaCatalog(utils.valid.getName());

                // test with one medias
                rating = 1;
                name = 'generic';
                media = {
                    id: id,
                    name: name,
                    rating: rating,
                    duration: utils.valid.getDuration(),
                    description: utils.valid.getDescription()
                };
                catalog.items.push(media);
                findResult = catalog.getTop(len);
                expect(findResult).to.exits;
                expect(findResult.length).to.equal(1);
                expect(findResult[0].name).to.equal(name);
                expect(findResult[0].rating).to.not.exist;
                expect(findResult[0].duration).to.not.exist;
                expect(findResult[0].description).to.not.exist;

                // test with multiple books
                for (i = 0; i < len; i += 1) {
                    media = {
                        id: (i + len),
                        name: utils.valid.getName(),
                        rating: rating,
                        duration: utils.valid.getDuration(),
                        description: utils.valid.getDescription()
                    };

                    medias.push(media);
                    catalog.items.push(media);
                }

                top = 5;
                findResult = catalog.getTop(top);
                expect(findResult).to.exits;
                expect(findResult.length).to.equal(top);

                top = 30;
                findResult = catalog.getTop(top);
                expect(findResult).to.exits;
                expect(findResult.length).to.equal(len + 1);

                function testGetTop_NaN() {
                    catalog.getTop('text');
                }

                function testGetTop_ltOne() {
                    catalog.getTop(0);
                }

                expect(testGetTop_NaN).to.throw();
                expect(testGetTop_ltOne).to.throw();
            });
            // test 24
            it('expect mediaCatalog.find() by id to find the leftmost media in the items array or return null', function () {
                var catalog,
                    media,
                    book,
                    i,
                    id = 100,
                    len = 10,
                    books = [];

                catalog = result.getMediaCatalog(utils.valid.getName());

                function testFindById_Undefined() {
                    catalog.find();
                }

                expect(testFindById_Undefined).to.throw();
                expect(catalog.find(id * id)).to.be.null;

                media = {
                    id: id,
                    name: utils.valid.getName(),
                    rating: utils.valid.getRating(),
                    duration: utils.valid.getDuration(),
                    description: utils.valid.getDescription()
                };
                catalog.items.push(media);
                expect(catalog.find(id)).to.equal(media);

                // test with multiple books
                for (i = 0; i < len; i += 1) {
                    book = {
                        id: (i + len),
                        name: utils.valid.getName(),
                        isbn: utils.valid.getISBN13(),
                        genre: utils.valid.getGenre(),
                        description: utils.valid.getDescription()
                    };

                    books.push(book);
                    catalog.items.push(book);
                }

                for (i = 0; i < len; i += 1) {
                    expect(catalog.find(i + len)).to.equal(books[i]);
                }

                function testFindID_undefined() {
                    catalog.find();
                }

                function testFindID_null() {
                    catalog.find(null);
                }

                function testFindID_string() {
                    catalog.find('text');
                }

                expect(testFindID_undefined).to.throw();
                expect(testFindID_null).to.throw();
                expect(testFindID_string).to.throw();//*/
            });
            // test 25
            it('expect mediaCatalog.find() by options to find an array of media in the items array or return null', function () {
                var catalog,
                    media,
                    findResult,
                    i,
                    id = 100,
                    len = 10,
                    medias = [];

                catalog = result.getMediaCatalog(utils.valid.getName());

                function testFindById_Undefined() {
                    catalog.find();
                }

                expect(testFindById_Undefined).to.throw();
                expect(catalog.find({name: 'nonexistent'})).to.exits;
                expect(Array.isArray(catalog.find({name: 'nonexistent'}))).to.be.true;
                expect(catalog.find({name: 'nonexistent'}).length).to.exits; // it is an array-like object
                expect(catalog.find({name: 'nonexistent'}).length).to.equal(0);

                // test with one book
                media = {
                    id: id,
                    name: utils.valid.getName(),
                    rating: 4,
                    duration: utils.valid.getDuration(),
                    description: utils.valid.getDescription()
                };
                catalog.items.push(media);
                findResult = catalog.find({id: id});
                expect(findResult).to.exits;
                expect(findResult.length).to.equal(1);
                expect(findResult[0]).to.equal(media);

                // test with multiple books
                for (i = 0; i < len; i += 1) {
                    media = {
                        id: (i + len),
                        name: 'myName',
                        rating: 3,
                        duration: utils.valid.getDuration(),
                        description: utils.valid.getDescription()
                    };

                    medias.push(media);
                    catalog.items.push(media);
                }

                findResult = catalog.find({name: 'myName'});
                expect(findResult).to.exits;
                expect(findResult.length).to.equal(len);

                findResult = catalog.find({id: 2 + len, name: 'myName'});
                expect(findResult).to.exits;
                expect(findResult.length).to.equal(1);
                expect(findResult[0]).to.equal(medias[2]);

                // test search by genre
                findResult = catalog.find({rating: 4});
                expect(findResult).to.exits;
                expect(findResult.length).to.equal(1);
            });
            // test 26
            it('expect mediaCatalog.search() to return an array of found items or empty array', function () {
                var i,
                    catalog,
                    media,
                    pattern,
                    len = 100;
                catalog = result.getMediaCatalog(utils.valid.getName());

                media = {
                    id: 123456,
                    name: utils.valid.getName(),
                    rating: utils.valid.getRating(),
                    duration: utils.valid.getDuration(),
                    description: utils.valid.getDescription()
                };
                catalog.items.push(media);

                pattern = media.name.substr(1, media.name.length / 2);
                expect(catalog.search(pattern)).to.eql([media]);

                pattern = media.description.substr(3, 6);
                expect(catalog.search(pattern)).to.eql([media]);
                // test with multiple books
                catalog.items = [];
                for (i = 0; i < len; i += 1) {
                    media = {
                        id: (i + len),
                        name: utils.valid.getName(),
                        rating: utils.valid.getRating(),
                        duration: utils.valid.getDuration(),
                        description: utils.valid.getDescription()
                    };
                    catalog.items.push(media);
                }
                pattern = catalog.items[0].name.substr(1, 3);
                var matchingMedia = catalog.items.filter(function (media) {
                    return media.name.indexOf(pattern) >= 0 ||
                        media.description.indexOf(pattern) >= 0;
                });
                expect(catalog.search(pattern)).to.eql(matchingMedia);
            });
            // test 27
            it('Expect mediaCatalog.search() to return empty array, when no media in catalog and when no media that contain the pattern ', function () {
                var catalog,
                    i,
                    pattern,
                    len = 100,
                    namePrefix = utils.valid.getGenre(),
                    duration = utils.valid.getDuration(),
                    rating = utils.valid.getRating(),
                    description = utils.valid.getDescription();
                catalog = result.getMediaCatalog(utils.valid.getName());

                expect(catalog.search('asdsad')).to.eql([]);

                catalog.items = [];
                for (i = 0; i < len; i += 1) {
                    catalog.items.push(result.getMedia(namePrefix + i, rating, duration, description));
                }
                pattern = namePrefix.substr(0, namePrefix.length - 1);
                pattern += 'Something that surely cannot be found in the valid genre';
                expect(catalog.search(pattern)).to.eql([]);
            });
        });
        describe('Invalid tests', function () {
            // test 28
            beforeEach(function(done) {
                result = require('../tasks/solution')();
                done();
            });
            it('Expect mediaCatalog.search() to throw if pattern is undefined, null or empty string ', function () {
                var catalog = result.getMediaCatalog(utils.valid.getName());

                function testSearch_Undefined() {
                    catalog.search();
                }

                function testSearch_null() {
                    catalog.search(null);
                }

                function testSearch_EmptyString() {
                    catalog.search('');
                }

                expect(testSearch_Undefined).to.throw();
                expect(testSearch_null).to.throw();
                expect(testSearch_EmptyString).to.throw();
            });
            // test 29
            it('expect invalid name to throw', function () {
                var catalog,
                    name,
                    count,
                    i,
                    ids;

                name = utils.valid.getName();
                catalog = result.getMediaCatalog(name);

                // test if id is unique
                expect(catalog.id).to.be.a('number');
                count = 10000;
                ids = {};
                for (i = 0; i < count; i += 1) {
                    catalog = result.getMediaCatalog(utils.valid.getName());
                    expect(ids[catalog.id]).to.be.undefined;
                    ids[catalog.id] = 1;
                }

                // test name exceptions
                function testName_undefined() {
                    result.getMediaCatalog();
                }

                function testNameSetter_undefined() {
                    catalog = result.getMediaCatalog(utils.getName());
                    catalog.name = undefined;
                }

                function testName_null() {
                    result.getMediaCatalog(null);
                }

                function testNameSetter_null() {
                    catalog = result.getMediaCatalog(utils.getName());
                    catalog.name = null;
                }

                function testName_Empty() {
                    result.getMediaCatalog('');
                }

                function testNameSetter_Empty() {
                    catalog = result.getMediaCatalog(utils.getName());
                    catalog.name = '';
                }

                function testName_Short() {
                    result.getMediaCatalog(utils.invalid.getShorterName());
                }

                function testNameSetter_Short() {
                    catalog = result.getMediaCatalog(utils.getName());
                    catalog.name = utils.invalid.getShorterName();
                }

                function testName_Long() {
                    result.getMediaCatalog(utils.invalid.getLongerName());
                }

                function testNameSetter_Long() {
                    catalog = result.getBookCatalog(utils.getName());
                    catalog.name = utils.invalid.getLongerName();
                }

                expect(testName_undefined).to.throw();
                expect(testNameSetter_undefined).to.throw();
                expect(testName_null).to.throw();
                expect(testNameSetter_null).to.throw();
                expect(testName_Empty).to.throw();
                expect(testNameSetter_Empty).to.throw();
                expect(testName_Short).to.throw();
                expect(testNameSetter_Short).to.throw();
                expect(testName_Long).to.throw();
                expect(testNameSetter_Long).to.throw();
            });
            // test 30
            it('expect mediaCatalog.add() to throw', function () {
                var duration,
                    rating,
                    description,
                    media,
                    name = utils.valid.getName(),
                    catalog = result.getMediaCatalog(name);

                // add invalid book
                function testAdd_undefined() {
                    catalog.add();
                }

                function testAdd_null() {
                    catalog.add(null);
                }

                function testAdd_Empty() {
                    catalog.add({});
                }

                function testAdd_Media() {
                    name = utils.getName();
                    duration = utils.valid.getDuration();
                    rating = utils.valid.getRating();
                    description = utils.getDescription();

                    media = result.getMedia(name, duration, rating, description);
                    catalog.add(media);
                }

                function testAdd_InvalidMedia() {
                    media = {
                        rating: utils.valid.Rating(),
                        duration: utils.valid.getDuration()
                    };
                    catalog.add(media);
                }

                expect(testAdd_undefined).to.throw();
                expect(testAdd_null).to.throw();
                expect(testAdd_Empty).to.throw();
                expect(testAdd_Media).to.throw();
                expect(testAdd_InvalidMedia).to.throw();
            });
        });
    });
});