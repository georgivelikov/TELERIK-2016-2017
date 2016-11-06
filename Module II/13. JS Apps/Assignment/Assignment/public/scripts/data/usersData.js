var usersData = (function(){
    var allUsers = 'api/users';
    var registerUrl = 'api/users';
    var loginUrl = 'api/users/auth';

    var login = function(user){
        return requester.putJSON(loginUrl, user);
    };

    var register = function(user){
        return requester.postJSON(registerUrl, user);
    };

    var logout = function(){
        return new Promise(function (resolve) {
            resolve();
        });
    };

    var isLoggedIn = function(){
        return Promise.resolve()
            .then(function() {
                return !!localStorage.getItem("USERNAME"); // !!!!! do not work well !!!!!!! DO NOT USE!!!!!!!!!!!!!
            });
    };

    var isLogged = function(){
        var username = localStorage.getItem('USERNAME');
        // console.log(username);
        if(username){
            return true;
        } else {
            return false;
        }
    };

    var getUserPage = function(username){
        var url = 'api/profiles/' + username;
        return requester.getJSON(url);
    };

    return {
        login: login,
        register: register,
        logout: logout,
        isLoggedIn: isLoggedIn,
        isLogged: isLogged,
        getUserPage: getUserPage,
    };
}());