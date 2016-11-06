var dataService = (function(){

    var login = function(user){
        return requester.postJSON('/auth', user);
    };

    var register = function(user){
        return requester.postJSON('/user', user);
    };

    var logout = function(){
        var headers = {
            "x-sessionkey": localStorage.getItem('SESSION_KEY')
        };
        var options = {
            headers: headers
        };

        return requester.putJSON('/user', {}, options);
    };

    var isLoggedIn = function(){
        return Promise.resolve()
            .then(function() {
                return !!localStorage.getItem("USERNAME"); // !!!!! does not work?
            });
    };

    var isLogged = function(){
        var username = localStorage.getItem('USERNAME');
        console.log(username);
        if(username){
            return true;
        } else {
            return false;
        }
    };

    var getAllPosts = function(){
        return requester.get('/post');
    };

    var createPost = function(post, options){
        return requester.postJSON('/post', post, options);
    };

    return {
        users: {
            login: login,
            register: register,
            logout: logout,
            isLoggedIn: isLoggedIn,
            isLogged: isLogged
        },
        data: {
            getAllPosts: getAllPosts,
            createPost: createPost,
        }
    };
}());