/* globals require module Promise*/
"use strict";

module.exports = function(models) {
    let Country = models.country

    return {
        getCountryById(id) {
            return new Promise((resolve, reject) => {
                Country.findOne({ "_id": id }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        getCountryByName(name) {
            return new Promise((resolve, reject) => {
                Country.findOne({ "name": name }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        createCountry(name, planet) {
            return new Promise((resolve, reject) => {
                let country = new Country ({
                    name: name,
                    planet: planet
                });

                country.save((err, createdCountry) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(createdCountry);
                });
            });
        },
        getAllCountries() {
            return new Promise((resolve, reject) => {
                Country
                    .find((err, countries) => {
                        if (err) {
                            return reject(err);
                        }
                        return resolve(countries);
                    });
            });
        }
    };
};