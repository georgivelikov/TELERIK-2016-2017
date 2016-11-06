var usersController = (function(){
    var loadLoginForm = function(content, context){
        var $content = content;
        var _this = this;
        templateLoader.get('login')
            .then(function(resultTemplate) {
                $content.html(resultTemplate);

                $('#btn-login').on('click', function(){
                    var user = {
                        username: $('#tb-username').val(),
                        passHash: CryptoJS.SHA1($('#tb-password').val()).toString()
                    };
                    
                    _this.login(user, context);
                });
            });
    };

    var loadRegisterForm = function(content, context){
        var $content = content;
        var _this = this;
        templateLoader.get('register')
            .then(function(resultTemplate) {
                $content.html(resultTemplate);

                $('#btn-register').on('click', function(){
                    var user = {
                        username: $('#tb-newUsername').val(),
                        passHash: CryptoJS.SHA1($('#tb-newPassword').val()).toString()
                    };

                    _this.register(user, context);
                });
            });
    };

    var login = function(user, context) {
        usersData.login(user)
            .then(function(response){
                $('#nav-btn-login').addClass('hidden');
                $('#nav-btn-register').addClass('hidden');
                $('#nav-btn-logout').removeClass('hidden');
                localStorage.setItem('USERNAME', response.result.username);// TO DO
                localStorage.setItem('AUTH_KEY', response.result.authKey); // TO DO
                context.redirect('#/home');
            });
    };

    var register = function(user, context) {
        usersData.register(user)
            .then(function(response){
                alert('You may login now!');
                context.redirect('#/login');
            });
    };

    var isLogged = function(){
        return usersData.isLogged();
    };

    var logout = function(){
        usersData.logout()
            .then(function(){
                $('#nav-btn-login').removeClass('hidden');
                $('#nav-btn-register').removeClass('hidden');
                $('#nav-btn-logout').addClass('hidden');

                localStorage.removeItem('USERNAME');
                localStorage.removeItem('AUTH_KEY');
            });
    }
    return {
        loadLoginForm: loadLoginForm,
        loadRegisterForm: loadRegisterForm,
        login: login, 
        register: register,
        isLogged: isLogged,
        logout: logout
    };
}());