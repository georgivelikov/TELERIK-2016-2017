/* globals require module Promise*/
"use strict";

module.exports = function(models) {
    let City = models.city

    return {
        getCityById(id) {
            return new Promise((resolve, reject) => {
                City.findOne({ "_id": id }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        getCityByName(name) {
            return new Promise((resolve, reject) => {
                City.findOne({ "name": name }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        createCity(name, country) {
            return new Promise((resolve, reject) => {
                let city = new City ({
                    name: name,
                    country: country
                });

                city.save((err, createdCity) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(createdCity);
                });
            });
        },
        getAllCities() {
            return new Promise((resolve, reject) => {
                City
                    .find((err, cities) => {
                        if (err) {
                            return reject(err);
                        }
                        return resolve(cities);
                    });
            });
        }
    };
};