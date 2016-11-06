function solve() {
    var playableId = 0;
    var playlistId = 0;
    var playerId = 0;

    function generatePlayableId() {
        playableId++;
        return playableId;
    }

    function generatePlaylistId() {
        playlistId++;
        return playlistId;
    }

    function generatePlayerId() {
        playerId++;
        return playerId;
    }

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

    class Playable{
        constructor(title, author){
            this.title = title;
            this.author = author;
            this._id = generatePlayableId();
        }

        get title(){
            return this._title;
        }
        set title(value){
            if(checkForNullOrUndefined(value)){
                throw new Error('Invalid playable title - null or undefined');
            }

            if(!validateLength(3, 25, value.length)){
                throw new Error('Invalid title length');
            }

            this._title = value;
        }

        get author(){
            return this._author;
        }
        set author(value){
            if(checkForNullOrUndefined(value)){
                throw new Error('Invalid playable author - null or undefined');
            }

            if(!validateLength(3, 25, value.length)){
                throw new Error('Invalid author length');
            }
            this._author = value;
        }

        get id(){
            return this._id;
        }

        play(){
            return `${this.id}. ${this.title} - ${this.author}`;
        }
    }

    class Audio extends Playable{
        constructor(title, author, length){
            super(title, author);
            this.length = length;
        }

        get length(){
            return this._length;
        }
        set length(value){
            if(checkForNullOrUndefined(value)){
                throw new Error('Audio length is null or undefined');
            }
            if(isNaN(value)){
                throw new Error('Audio length is not a number');
            }
            if(value <= 0){
                throw new Error('Audio length must be possitive');
            }
            this._length = value;
        }

        play(){
            return super.play() + ` - ${this.length}`;
        }
    }

    class Video extends Playable{
        constructor(title, author, imdbRating){
            super(title, author);
            this.imdbRating = imdbRating;
        }

        get imdbRating(){
            return this._imdbRating;
        }
        set imdbRating(value){
            if(checkForNullOrUndefined(value)){
                throw new Error('Video imdbRating is null or undefined');
            }
            if(isNaN(value)){
                throw new Error('Video imdbRating is not a number');
            }
            if(value < 1 || value > 5){
                throw new Error('Video imdbRating must be between 1 and 5');
            }
            this._imdbRating = value;
        }

        play(){
            return super.play() + ` - ${this.imdbRating}`;
        }
    }

    class Playlist{
        constructor(name){
            this.name = name;
            this.id = generatePlaylistId();
            this.playables = [];
        }

        get name(){
            return this._name;
        }
        set name(value){
            if(checkForNullOrUndefined(value)){
                throw new Error('Playlist name is null or undefined');
            }

            if(!validateLength(3, 25, value.length)){
                throw new Error('Playlist name length must be between 1 and 5');
            }
            this._name = value;
        }

        addPlayable(playable){
            if(checkForNullOrUndefined(playable)){
                throw new Error();
            }

            this.playables.push(playable);

            return this;
        }

        getPlayableById(id){
            if(checkForNullOrUndefined(id)){
                throw new Error();
            }
            if(isNaN(id)){
                throw new Error();
            }

            var result = null;

            for(var i = 0; i < this.playables.length; i += 1){
                if(id === this.playables[i].id){
                    return this.playables[i];
                }
            }

            return result;
        }

        removePlayable(playable){
            if(checkForNullOrUndefined(playable)){
                throw new Error();
            }
            var searchedId;
            if((playable instanceof Object)){
                searchedId = playable.id;
            }
            else {
                searchedId = playable;
            }
            if(isNaN(searchedId)){
                throw new Error();
            }

            var index = -1;

            for(var i = 0; i < this.playables.length; i += 1){
                if(searchedId === this.playables[i].id){
                    index = i;
                    break;
                }
            }

            if(index < 0){
                throw new Error();
            }

            var helper = this.playables.splice(index, 1);

            return this;
        }

        listPlayables(page, size){
            if(checkForNullOrUndefined(page) || checkForNullOrUndefined(size)){
                throw new Error();
            }
            if(page < 0 || size <= 0 || page * size > this.playables.length){
                throw new Error();
            }

            function compare(a,b) {
                if (a.title > b.title){
                    return 1;
                } else if (a.title < b.title){
                    return -1;
                } else {
                    if(a.id > b.id){
                        return 1;
                    } else if(a.id < b.id){
                        return -1;
                    } else {
                        return 0;
                    }
                }
            }

            var sorted = this.playables.slice(0);
            sorted.sort(compare);

            if(page * size + size > this.playables.length){
                size = page * size + size - this.playables.length;
            }

            var result = sorted.splice(page, size);

            return result;
        }
    }

    class Player{
        constructor(name){
            this.name = name;
            this.id = generatePlayerId();
            this.playlists = [];
        }
        get name(){
            return this._name;
        }
        set name(value){
            if(checkForNullOrUndefined(value)){
                throw new Error('Player name is null or undefined');
            }

            if(!validateLength(3, 25, value.length)){
                throw new Error('Player name length must be between 1 and 5');
            }
            this._name = value;
        }

        addPlaylist(playlist){
            if(checkForNullOrUndefined(playlist)){
                throw new Error();
            }
            if(!(playlist instanceof Playlist)){
                throw new Error();
            }

            this.playlists.push(playlist);

            return this;
        }

        getPlaylistById(id){
            if(checkForNullOrUndefined(id)){
                throw new Error();
            }

            var result = null;
            for(var i = 0; i < this.playlists.length; i += 1){
                if(id === this.playlists[i].id){
                    result = this.playlists[i];
                    break;
                }
            }

            return result;
        }

        removePlaylist(playlist){
            if(checkForNullOrUndefined(playlist)){
                throw new Error();
            }

            var index = -1;

            for(var i = 0; i < this.playlists.length; i++){
                if(playlist.id === this.playlists[i].id){
                    index = i;
                    break;
                }
            }

            if(i < 0){
                throw new Error();
            }

            var helper = this.playlists.splice(index, 1);
        }
    }

    return {
		getPlayer: function (name){
			return new Player(name);
		},
		getPlaylist: function(name){
			return new Playlist(name);
		},
		getAudio: function(title, author, length){
			return new Audio(title, author, length);
		},
		getVideo: function(title, author, imdbRating){
			return new Video(title, author, imdbRating);
		}
	};
}

var result = solve();
var audio = result.getAudio('Bon Jovi', 'Dead or Alive', 4);
console.log(audio.play());

/*var pl = result.getPlaylist('asd');

var playable = {id: 1, name: 'Rock', author: 'Stephen'};
pl.addPlayable(playable);
console.log(pl.getPlayableById(1));

console.log(pl.listPlayables(0, 10));
pl.removePlayable(1);
console.log(pl.getPlayableById(1));

var list = result.getPlaylist('Rock');
for (var i = 0; i < 35; i += 1) {
    list.addPlayable({id: (i + 1), name: 'Rock' + (9 - (i % 10))});
}

//console.log(list.listPlayables(0, 10));

/*returnedPlayables = list.listPlaylables(2,10);
 returnedPlayables = list.listPlaylables(3,10);
 console.log(returnedPlayables);*/

module.exports = solve;