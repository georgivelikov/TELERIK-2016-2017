$(function(){
    var sammyApp = new Sammy('#content', function(){
        var $content = $('#content');

        if (usersController.isLogged()) {
            $('#nav-btn-login, #nav-btn-register').addClass('hidden');
            $('#nav-btn-logout').removeClass('hidden');
        } else {
            $('#nav-btn-login, #nav-btn-register').removeClass('hidden');
            $('#nav-btn-logout').addClass('hidden');
        }
    
        this.get('#/', function(context){
            context.redirect('#/home');
        });

        this.get('#/home', function(context){
            mainController.home($content, context);
        });

        this.get('#/login', function(context){
            usersController.loadLoginForm($content, context);
        });

        this.get('#/register', function(context){
            usersController.loadRegisterForm($content, context);
        });
    });

    $('#nav-btn-logout').on('click', function() {
        usersController.logout();
    });

    sammyApp.run('#/');
}());