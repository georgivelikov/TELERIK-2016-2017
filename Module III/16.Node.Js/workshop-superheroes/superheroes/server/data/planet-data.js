/* globals require module Promise*/
"use strict";

module.exports = function(models) {
    let Planet = models.planet

    return {
        getPlanetById(id) {
            return new Promise((resolve, reject) => {
                Planet.findOne({ "_id": id }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        getPlanetByName(name) {
            return new Promise((resolve, reject) => {
                Planet.findOne({ "name": name }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        createPlanet(name) {
            return new Promise((resolve, reject) => {
                let planet = new Planet ({
                    name: name,
                    superheroes: [],
                    fractions: []
                })

                planet.save((err, createdPlanet) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(createdPlanet);
                });
            });
        },
        getAllPlanets() {
            return new Promise((resolve, reject) => {
                Planet
                    .find((err, planets) => {
                        if (err) {
                            return reject(err);
                        }
                        return resolve(planets);
                    });
            });
        }
    };
};