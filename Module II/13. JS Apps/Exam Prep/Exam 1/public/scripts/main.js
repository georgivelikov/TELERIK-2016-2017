$(function(){
    var sammyApp = new Sammy('#content', function(){
        var $content = $('#content');

        // if (usersData.current()) {
        //     $('#nav-btn-login, #nav-btn-register').addClass('hidden');
        //     $('#nav-btn-logout').removeClass('hidden');
        // } else {
        //     $('#nav-btn-login, #nav-btn-register').removeClass('hidden');
        //     $('#nav-btn-logout').addClass('hidden');
        // }
    
        this.get('#/', function(context){
            controller.home($content, context);
        });

        this.get('#/login', function(context){
            controller.login($content, context);
        });

        this.get('#/register', function(context){
            controller.register($content, context);
        });
    });

    $('#nav-btn-logout').on('click', function() {
        dataService.users.logout()
            .then(function(){
                $('#nav-btn-login').removeClass('hidden');
                $('#nav-btn-register').removeClass('hidden');
                $('#nav-btn-logout').addClass('hidden');

                localStorage.removeItem('USERNAME');
                localStorage.removeItem('SESSION_KEY');
            });
    });

    sammyApp.run('#/');
}());