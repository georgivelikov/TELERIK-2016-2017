"use strict";

const models = require('../models');

const data = {
    cities: require("./city-data")({ city: models.city }),
    countries: require("./country-data")({ country: models.country }),
    fractions: require("./fraction-data")({ fraction: models.fraction }),
    planets: require("./planet-data")({ planet: models.planet }),
    powers: require("./power-data")({ powers: models.powers }),
    superheroes: require("./superhero-data")({ superhero: models.superhero }),
    users: require("./user-data")({ user: models.user })
};

module.exports = data;