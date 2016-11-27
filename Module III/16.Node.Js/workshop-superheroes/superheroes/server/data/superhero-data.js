/* globals require module Promise*/
"use strict";

module.exports = function(models) {
    let Superhero = models.superhero

    return {
        getSuperheroById(id) {
            return new Promise((resolve, reject) => {
                Superhero.findOne({ "_id": id }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        getSuperheroByName(name) {
            return new Promise((resolve, reject) => {
                Superhero.findOne({ "name": name }, (err, result) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(result);
                });
            });
        },
        createSuperhero(body) {
            return new Promise((resolve, reject) => {
                let superhero = new Superhero ({
                    name: body.name,
                    secretIdentity: body.secretIdentity,
                    alignement: body.alignement,
                    story: body.story,
                    imageUrl: body.imageUrl,
                    powers: [],
                    fractions: []
                });
                superhero.save((err, createdSuperhero) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(createdSuperhero);
                });
            });
        },
        getAllSuperheroes() {
            return new Promise((resolve, reject) => {
                Superhero
                    .find((err, superheroes) => {
                        if (err) {
                            return reject(err);
                        }
                        return resolve(superheroes);
                    });
            });
        }
    };
};