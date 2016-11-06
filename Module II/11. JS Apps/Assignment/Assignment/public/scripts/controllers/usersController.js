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
                        password: $('#tb-password').val()
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
                        password: $('#tb-newPassword').val(),
                    };

                    if(!validator.validateLength(user.username, 6, 30) || 
                        !validator.validateType(user.username) || 
                        !validator.validateSymbols(user.username)){
                            alert('invalid username');
                            return;
                        }
                    if(!validator.validateLength(user.password, 6, 30) || 
                        !validator.validateType(user.password) || 
                        !validator.validateSymbolsOnlyLettersAndDigits(user.password)){
                            alert('invalid password');
                            return;
                        }

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
                
                localStorage.setItem('USERNAME', response.result.username);
                localStorage.setItem('AUTH_KEY', response.result.authKey);
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
    };

    var getUserPage = function(content, context, username){
        var $content = content;
        var username;
        var array1 = [];
        var array2 = [];
        var array3 = [];

        usersData.getUserPage(username)
            .then(function(response){
                username = response.result.username;
                var arr = response.result.userMaterials;

                for(var i = 0; i < arr.length; i += 1){
                    var currentMaterial = arr[i];
                    if(currentMaterial.category == 'want-to-watch'){
                        array3.push(currentMaterial);
                    } else if(currentMaterial.category == 'watched'){
                        array1.push(currentMaterial);
                    } else if(currentMaterial.category == 'watching'){
                        array2.push(currentMaterial);
                    }
                }
                return templateLoader.get('current-user');
            })
            .then(function(resultTemplate){
                var user = {
                    username: username,
                    watched: array1,
                    watching: array2,
                    wanted: array3
                };

                $content.html(resultTemplate(user));
            });
    };

    
    return {
        loadLoginForm: loadLoginForm,
        loadRegisterForm: loadRegisterForm,
        login: login, 
        register: register,
        isLogged: isLogged,
        logout: logout,
        getUserPage: getUserPage
    };
}());