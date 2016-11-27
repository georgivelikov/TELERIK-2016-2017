/* globals require module Promise*/
"use strict";

module.exports = function(models) {
    let Power = models.power

    return {
        getPowerById(id) {
            return new Promise((resolve, reject) => {
                Power.findOne({ "_id": id }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        getPowerByName(name) {
            return new Promise((resolve, reject) => {
                Power.findOne({ "name": name }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        createPower(name) {
            return new Promise((resolve, reject) => {
                let power = new Power ({
                    name: name,
                    superheroes: []
                });

                power.save((err, createdPower) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(createdPower);
                });
            });
        },
        getAllPowers() {
            return new Promise((resolve, reject) => {
                Power
                    .find((err, powers) => {
                        if (err) {
                            return reject(err);
                        }
                        return resolve(powers);
                    });
            });
        }
    };
};