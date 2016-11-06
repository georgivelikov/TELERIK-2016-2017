/* globals module */

"use strict";

function solve(){

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

    class Product{
        constructor(productType, name, price){
            this.productType = productType;
            this.name = name;
            this.price = price;
        }

        get productType(){
            return this._productType;
        }
        set productType(value){
            if(!validator.isStringType(value)){
                throw new Error();
            }
            // check for empty str
            this._productType = value;
        }

        get name(){
            return this._name;
        }
        set name(value){
            if(!validator.isStringType(value)){
                throw new Error();
            }
            this._name = value;
        }

        get price(){
            return this._price;
        }
        set price(value){
            if(!validator.isNumber(value)){
                throw new Error();
            }
            this._price = value;
        }
    }

    class ShoppingCart {
        constructor(){
            this.products = [];
        }

        add(product){
            if(validator.isNullOrUndefined(product)){
                throw new Error();
            }
            if(!(product instanceof Product)){
                throw new Error();
            }

            this.products.push(product);

            return this;
        }

        remove(product){
            if(validator.isNullOrUndefined(product)){
                throw new Error();
            }
            if(!(product instanceof Product)){
                throw new Error();
            }
            if(this.products.length === 0){
                throw new Error();
            }

            for(var i = 0; i < this.products.length; i += 1){
                var currentProduct = this.products[i];

                if(currentProduct.productType === product.productType 
                    && currentProduct.name === product.name 
                    && currentProduct.price === product.price){
                        var x = this.products.splice(i, 1);
                        return;
                }
            }

            throw new Error();
        }

        showCost(){
            if(this.products.length === 0){
                return 0;
            }

            var sum = 0;
            for(var i = 0; i < this.products.length; i += 1){
                var currentProduct = this.products[i];

                sum += +currentProduct.price;
            }

            return sum;
        }

        showProductTypes(){
            var results = new Set();

            for(var i = 0; i < this.products.length; i += 1){
                var currentProduct = this.products[i];

                results.add(currentProduct.productType);
            }

            var final = Array.from(results);

            return final.sort();
        }

        getInfo(){
            var result = [];
            var helper = new Set();

            for(var i = 0; i < this.products.length; i += 1){
                var currentProduct = this.products[i];

                if(helper.has(currentProduct.name)){
                    for(var j = 0; j < result.length; j += 1){
                        if(currentProduct.name === result[j].name){
                            result[j].price += +currentProduct.price;
                            result[j].quantity += 1;
                        }
                    }
                }
                else {
                    var newProduct = {
                        name: currentProduct.name,
                        totalPrice: currentProduct.price,
                        quantity: 1
                    }

                    helper.add(currentProduct.name);
                    result.push(newProduct);
                }
            }

            return {
                totalPrice: this.showCost(),
                products: result
            }
        }

    }
    return {
        Product, ShoppingCart
    };
}

module.exports = solve;
// let { ShoppingCart, Product } = solve();
// let sc = new ShoppingCart();

// let p = new Product("food", "Bread", "1");

// sc.add(new Product("beverages", "Whiskey", "25"));

// sc.add(p);
// sc.add(p);
// sc.add(p);
// sc.add(p);
// console.log(sc.products);
// console.log(sc.showCost());
// console.log(sc.showProductTypes());

// console.log(sc.getInfo());

// sc.remove(p);

// console.log(sc.getInfo());