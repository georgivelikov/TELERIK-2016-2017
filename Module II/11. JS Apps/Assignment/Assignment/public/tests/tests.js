mocha.setup('bdd');

var expect = chai.expect;

const LOGIN_URL = 'api/users/auth';
const REGISTER_URL = 'api/users';
const GET_ALL_MATERIALS_URL = 'api/materials';
const FAKE_ID = 1;
const GET_SINGLE_MATERIAL_URL = 'api/materials/' + FAKE_ID;
const FAKE_PATTERN = 'X';
const GET_SEARCH_URL = 'api/materials?filter=' + FAKE_PATTERN;
const FAKE_TEXT = 'fake';
const LEAVE_COMMENT_URL =  `api/materials/${FAKE_ID}/comments`;
const NEW_MATERIAL_URL = 'api/materials';
const user = {
    username: 'test2',
    authKey: 'test2'
};
var material = {
    "id": "ffafd855-f6e8-480f-87f8-1ed61fb202fa",
    "title": "JavaScript Loops",
    "description": "loops, for, while, do-while",
    "createdOn": "2016-09-28T12:50:15.808Z",
    "img": "http://html5beginners.com/wp-content/uploads/2014/09/js.png",
    "commentsCount": 0,
    "user": {
    "id": "73a58989-5107-46e8-b781-4380f6c1c0b1",
    "username": "DonchoMinkov"
    }
}
var allMaterials = [];
allMaterials.push(material);

describe('User Data Tests', function(){
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

describe('Main Data Tests', function(){
    describe('mainData.getAllMaterials() tests', function(){
        beforeEach(function () {
            sinon.stub(requester, 'getJSON', function (user) {
                return new Promise(function (resolve, reject) {
                    resolve(allMaterials);
                });
            });
            localStorage.clear();
        });

        afterEach(function () {
            requester.getJSON.restore();
            localStorage.clear();
        });

        it('(1) Expect: mainData.getAllMaterials() to make correct getJSON call', function (done) {
            mainData.getAllMaterials()
                .then(() => {
                    expect(requester.getJSON.firstCall.args[0]).to.equal(GET_ALL_MATERIALS_URL);
                })
                .then(done, done);
        });

        it('(2) Expect: mainData.getAllMaterials() to make exactly one getJSON call', function (done) {
            mainData.getAllMaterials()
                .then(() => {
                    expect(requester.getJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });
    });
    describe('mainData.getSingleMaterial(id) tests', function(){
        beforeEach(function () {
            sinon.stub(requester, 'getJSON', function (user) {
                return new Promise(function (resolve, reject) {
                    resolve({});
                });
            });
            localStorage.clear();
        });

        afterEach(function () {
            requester.getJSON.restore();
            localStorage.clear();
        });

        it('(1) Expect: mainData.getSingleMaterial() to make correct getJSON call', function (done) {
            mainData.getSingleMaterial(FAKE_ID)
                .then(() => {
                    expect(requester.getJSON.firstCall.args[0]).to.equal(GET_SINGLE_MATERIAL_URL);
                })
                .then(done, done);
        });

        it('(2) Expect: mainData.getSingleMaterial() to make exactly one getJSON call', function (done) {
            mainData.getSingleMaterial(FAKE_ID)
                .then(() => {
                    expect(requester.getJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });
    });
    describe('mainData.searchMaterial(pattern) tests', function(){
        beforeEach(function () {
            sinon.stub(requester, 'getJSON', function (user) {
                return new Promise(function (resolve, reject) {
                    resolve({});
                });
            });
            localStorage.clear();
        });

        afterEach(function () {
            requester.getJSON.restore();
            localStorage.clear();
        });

        it('(1) Expect: mainData.searchMaterial(pattern) to make correct getJSON call', function (done) {
            mainData.searchMaterial(FAKE_PATTERN)
                .then(() => {
                    expect(requester.getJSON.firstCall.args[0]).to.equal(GET_SEARCH_URL);
                })
                .then(done, done);
        });

        it('(2) Expect: mainData.searchMaterial(pattern) to make exactly one getJSON call', function (done) {
            mainData.searchMaterial(FAKE_PATTERN)
                .then(() => {
                    expect(requester.getJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });
    });
    describe('mainData.leaveComment(pattern) tests', function(){
        beforeEach(function () {
            sinon.stub(requester, 'putJSON', function (user) {
                return new Promise(function (resolve, reject) {
                    resolve({commentText: FAKE_TEXT});
                });
            });
            localStorage.clear();
        });

        afterEach(function () {
            requester.putJSON.restore();
            localStorage.clear();
        });

        it('(1) Expect: mainData.leaveComment() to make correct putJSON call', function (done) {
            mainData.leaveComment(FAKE_ID, FAKE_TEXT)
                .then(() => {
                    expect(requester.putJSON.firstCall.args[0]).to.equal(LEAVE_COMMENT_URL);
                })
                .then(done, done);
        });

        it('(2) Expect: mainData.leaveComment(pattern) to make exactly one putJSON call', function (done) {
            mainData.leaveComment(FAKE_ID, FAKE_TEXT)
                .then(() => {
                    expect(requester.putJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });
    });
    describe('mainData.addNewMaterial() tests', function(){
        beforeEach(function () {
            sinon.stub(requester, 'postJSON', function (user) {
                return new Promise(function (resolve, reject) {
                    resolve();
                });
            });
            localStorage.clear();
        });

        afterEach(function () {
            requester.postJSON.restore();
            localStorage.clear();
        });

        it('(1) Expect: mainData.leaveComment() to make correct postJSON call', function (done) {
            mainData.addNewMaterial()
                .then(() => {
                    expect(requester.postJSON.firstCall.args[0]).to.equal(NEW_MATERIAL_URL);
                })
                .then(done, done);
        });

        it('(2) Expect: mainData.leaveComment(pattern) to make exactly one postJSON call', function (done) {
            mainData.addNewMaterial()
                .then(() => {
                    expect(requester.postJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });
    });
    describe('mainData.addNewMaterial() tests', function(){
        beforeEach(function () {
            sinon.stub(requester, 'postJSON', function (user) {
                return new Promise(function (resolve, reject) {
                    resolve();
                });
            });
            localStorage.clear();
        });

        afterEach(function () {
            requester.postJSON.restore();
            localStorage.clear();
        });

        it('(1) Expect: mainData.addNewMaterial() to make correct postJSON call', function (done) {
            mainData.addNewMaterial()
                .then(() => {
                    expect(requester.postJSON.firstCall.args[0]).to.equal(NEW_MATERIAL_URL);
                })
                .then(done, done);
        });

        it('(2) Expect: mainData.addNewMaterial() to make exactly one postJSON call', function (done) {
            mainData.addNewMaterial()
                .then(() => {
                    expect(requester.postJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });
    });
});

mocha.run();
