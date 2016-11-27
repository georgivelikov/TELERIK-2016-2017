/* globals require module Promise*/
"use strict";

module.exports = function(models) {
    let Fraction = models.fraction

    return {
        getFractionById(id) {
            return new Promise((resolve, reject) => {
                Fraction.findOne({ "_id": id }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        getFractionByName(name) {
            return new Promise((resolve, reject) => {
                Fraction.findOne({ "name": name }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        createFraction(name) {
            return new Promise((resolve, reject) => {
                let fraction = new Fraction ({
                    name: name,
                    superheroes: []
                });

                fraction.save((err, createdFraction) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(createdFraction);
                });
            });
        },
        getAllFractions() {
            return new Promise((resolve, reject) => {
                Fraction
                    .find((err, fractions) => {
                        if (err) {
                            return reject(err);
                        }
                        return resolve(fractions);
                    });
            });
        }
    };
};