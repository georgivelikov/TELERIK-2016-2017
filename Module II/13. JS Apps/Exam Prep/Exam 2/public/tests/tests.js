mocha.setup('bdd');

var expect = chai.expect;

const LOGIN_URL = 'api/auth';
const REGISTER_URL = 'api/users';
const user = {
    username: 'test2',
    authKey: 'test2'
};

describe('User Tests', function(){
    describe('usersData.login() tests', function(){
        beforeEach(function () {
            sinon.stub(requester, 'putJSON', function (user) {
                return new Promise(function (resolve, reject) {
                    resolve(user);
                });
            });
            localStorage.clear();
        });

        afterEach(function () {
            requester.putJSON.restore();
            localStorage.clear();
        });

        it('(1) Expect: usersData.login() to make correct putJSON call', function (done) {
            usersData.login(user)
                .then(() => {
                    expect(requester.putJSON.firstCall.args[0]).to.equal(LOGIN_URL);
                })
                .then(done, done);
        });

        it('(2) Expect: usersData.login() to make exactly one putJSON call', function (done) {
            usersData.login(user)
                .then(() => {
                    expect(requester.putJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('(3) Expect: usersData.login() to put correct user data', function (done) {
            usersData.login(user)
                .then(() => {
                    const actual = requester.putJSON.firstCall.args[1];
                    const props = Object.keys(actual).sort();

                    expect(props.length).to.equal(2);
                    expect(props[0]).to.equal('authKey');
                    expect(props[1]).to.equal('username');
                })
                .then(done, done);
        });

    });

    describe('usersData.register() tests', function(){
        beforeEach(function () {
            sinon.stub(requester, 'postJSON', function (user) {
                return new Promise(function (resolve, reject) {
                    resolve();
                });
            });
        });

        afterEach(function () {
            requester.postJSON.restore();
        });

        it('(1) Expect: usersData.register() to make correct postJSON call', function (done) {
            usersData.register(user)
                .then(() => {
                    expect(requester.postJSON.firstCall.args[0]).to.equal(REGISTER_URL);
                })
                .then(done, done);
        });

        it('(2) Expect: usersData.register() to make exactly one postJSON call', function (done) {
            usersData.register(user)
                .then((res) => {
                    expect(requester.postJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });
    });
});

mocha.run();
