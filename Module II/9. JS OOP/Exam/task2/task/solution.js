function solve() {
    'use strict';

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 100!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!'
    };

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
            if (/^[a-zA-Z\s]+$/.test(value)) {
                return true;
            } else {
				return false;
			}
        }
 
        function containsOnlyLettersAndDigits(value, paramName) {
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

    var unitId = 0;
    function generateUnitId(){
        return unitId += 1;
    }
    // your implementation goes here
    class Spell {
        constructor(name, manaCost, effect){
            this.name = name;
            this.manaCost = manaCost;
            this.effect = effect;
        }

        get name(){
            return this._name;
        }
        set name(value){
            if(!validator.isStringType(value)){
                throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
            }
            if(!validator.isStringLengthValid(value, 2, 20)){
                throw new Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
            }
            if(!validator.containsOnlyLetters(value)){
                throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }

            this._name = value;
        }

        get manaCost(){
            return this._manaCost;
        }
        set manaCost(value){
            if(!validator.isNumberType(value) || !validator.isPositiveNumber(value)){
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }

            this._manaCost = value;
        }

        get effect(){
            return this._effect;
        }
        set effect(value){
            if(typeof value !== 'function' || value.length !== 1){ // check for arguments
                throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
            }
            this._effect = value;
        }
    }

    class Unit {
        constructor(name, alignment){
            this.name = name;
            this.alignment = alignment;
        }

        get name(){
            return this._name;
        }
        set name(value){
            if(!validator.isStringType(value)){
                throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
            }
            if(!validator.isStringLengthValid(value, 2, 20)){
                throw new Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
            }
            if(!validator.containsOnlyLetters(value)){
                throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
            }

            this._name = value;
        }

        get alignment(){
            return this._alignment;
        }
        set alignment(value){
            if(value !== 'good' && value !== 'neutral' && value !== 'evil'){
                throw new Error('Alignment must be good, neutral or evil!');
            }

            this._alignment = value;
        }

        applyEffect(spell){

        }
    }

    class ArmyUnit extends Unit {
        constructor(name, alignment, damage, health, count, speed){
            super(name, alignment);
            this.id = generateUnitId();
            this.damage = damage;
            this.health = health;
            this.count = count;
            this.speed = speed;
        }

        get damage(){
            return this._damage;
        }
        set damage(value){
            if(!validator.isNumberType(value) || !validator.isNumberInRange(value, 0, 100)){
                throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
            }

            this._damage = value;
        }

        get health(){
            return this._health;
        }
        set health(value){
            if(!validator.isNumberType(value) || !validator.isNumberInRange(value, -10000, 200)){
                throw new Error(ERROR_MESSAGES.INVALID_HEALTH);
            }
            
            this._health = value;
        }

        get count(){
            return this._count;
        }
        set count(value){
            if(!validator.isNumberType(value) || value < 0){
                throw new Error(ERROR_MESSAGES.INVALID_COUNT);
            }

            this._count = value;
        }

        get speed(){
            return this._speed;
        }
        set speed(value){
            if(!validator.isNumberType(value) || !validator.isNumberInRange(value, 1, 100)){
                throw new Error(ERROR_MESSAGES.INVALID_SPEED);
            }

            this._speed = value;
        }
    }

    class Commander extends Unit {
        constructor(name, alignment, mana, spellbook, army){
            super(name, alignment);
            this.mana = mana;
            this.spellbook = [];
            this.army = [];
        }

        get mana(){
            return this._mana;
        }
        set mana(value){
            if(!validator.isNumberType(value) || !validator.isPositiveNumber(value)){
                throw new Error(ERROR_MESSAGES.INVALID_MANA);
            }

            this._mana = value;
        }
    }


    const battlemanager = {
        commanders: [],
        units: [],
        getCommander: function(name, alignment, mana){
            var commander =  new Commander(name, alignment, mana);
            this.commanders.push(commander);
            return commander;
        },
        getArmyUnit: function(options){
            var u = new ArmyUnit(options.name, options.alignment, options.damage, options.health, options.count, options.speed);
            this.units.push(u);
            return u;
        },
        getSpell: function(name, manaCost, effect){
            return new Spell(name, manaCost, effect);
        },
        addCommanders: function(...commanders){
            this.commanders.push(...commanders);
            return this;
        },
        addArmyUnitTo: function(commanderName, armyUnit){
            var commander;
            for(var i = 0; i < this.commanders.length; i += 1){
                if(commanderName === this.commanders[i].name){
                    commander = this.commanders[i];
                    break;
                }
            }

            commander.army.push(armyUnit);
            return this;
        },
        addSpellsTo: function(commanderName, ...spells){
            var commander;
            for(var i = 0; i < this.commanders.length; i += 1){
                if(commanderName === this.commanders[i].name){
                    commander = this.commanders[i];
                    break;
                }
            }
            for(var i = 0; i < spells.length; i += 1){
                if(!(spells[i] instanceof Spell)){
                    throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                }
            }
            commander.spellbook.push(...spells);
            return this;
        },
        findCommanders: function(query){
            var results = new Set();
            for(var i = 0; i < this.commanders.length; i += 1){
                var currentCommnader = this.commanders[i];
                var isValid = true;
                for (var key in query) {
                    if(query[key] !== currentCommnader[key]){
                        isValid = false;
                    }
                }
                if(isValid){
                    results.add(currentCommnader);
                }
            }

            function compare(first, second) {
                return Number(first > second) - 0.5;
            }
            var arr = Array.from(results);
            var sorted = arr.sort(compare);

            return sorted;

        },
        findArmyUnits: function(query){
            var results = new Set();
            for(var i = 0; i < this.units.length; i += 1){
                var currentUnit = this.units[i];
                var isValid = true;
                for (var key in query) {
                    if(query[key] !== currentUnit[key]){
                        isValid = false;
                    }
                }
                if(isValid){
                    results.add(currentUnit);
                }
            }

            function compare(a, b) {
                if(a.speed > b.speed) {
                    return -1;
                }
                else if(a.speed < b.speed){
                    return 1;
                }
                else {
                    return Number(a.name > b.name) - 0.5;
                }
            }
            var arr = Array.from(results);
            var sorted = arr.sort(compare);

            return sorted;
        },
        findArmyUnitById(id){
            for(var i = 0; i < this.units.length; i += 1){
                if(id === this.units[i].id){
                    return this.units[i];
                }
            }
        },
        spellcast: function(casterName, spellName, targetUnitId){
            var commander = null;
            for(var i = 0; i < this.commanders.length; i += 1){
                if(casterName === this.commanders[i].name){
                    commander = this.commanders[i];
                    break;
                }
            }

            if(commander === null){
                throw new Error('Cannot cast with non-existant commander ' + casterName + '!');
            }

            var spell = null;
            for(var i = 0; i < commander.spellbook.length; i += 1){
                if(spellName === commander.spellbook[i].name){
                    spell = commander.spellbook[i];
                }
            }

            if(spell === null){
                throw new Error(casterName + ' does not know ' + spellName);
            }

            var unit = null;
            unit = this.findArmyUnitById(targetUnitId);
            if(unit === null){
                throw new Error('Target not found!');
            }

            if(commander.mana < spell.manaCost){
                throw new Error('Not enough mana!');
            }
            else {
                commander.mana -= spell.manaCost;

                spell.effect(unit);
            }

            return this;
        },
        battle: function(attacker, defender){
            if(!(attacker instanceof ArmyUnit) || !(defender instanceof ArmyUnit)){
                throw new Error('Battle participants must be ArmyUnit-like!');
            }
            var totalDamage = attacker.damage * attacker.count;
            var totalHealth = defender.health * defender.count;

            totalHealth -= totalDamage;

            var newCount = totalHealth / defender.health;
            newCount = Math.ceil(newCount);
            if(newCount < 0){
                newCount = 0;
            }
            defender.count = newCount;

            return this;
        }
    };

    return battlemanager;
}


module.exports = solve;
