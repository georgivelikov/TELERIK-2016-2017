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