var validator = (function(){

    var validateType = function(text){
        if(typeof text !== 'string'){
            console.log('No string');
            return false;
        } else {
            return true;
        }
    };

    var validateLength = function(text, min, max){
        if(text.length < min || text.length > max){
            console.log('invalid len');
            return false;
        } else {
            return true;
        }
    };

    var validateSymbols = function(text){
        if(/^[\w\.]+$/.test(text)){
            return true;
        } else {
            return false;
        };
    };

    var validateSymbolsOnlyLettersAndDigits = function(text){
        if(/^[a-zA-Z\d]+$/.test(text)){
            return true;
        } else {
            return false;
        };
    };


    return {
        validateLength,
        validateSymbols,
        validateType,
        validateSymbolsOnlyLettersAndDigits
    }
}());