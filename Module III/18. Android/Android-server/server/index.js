const passport = require("passport");

const config = require("./config/index");
const database = require("./config/database")(config);
const app = require("./config/express")();

const controllers = require("./controllers")({ app, config, passport });

require("./config/database")(config);
require("./routers")({ app, config, controllers });

app.listen(config.port, err => {
    if (err) {
        console.log(err);
    }

    console.log(`Server is listening on ${config.port}...`);
});
