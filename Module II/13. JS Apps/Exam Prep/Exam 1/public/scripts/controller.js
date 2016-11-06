var controller = (function(){
    var home = function(content, context){
        var $content = content;
        var allPosts;

        if(dataService.users.isLogged()){
            $('#nav-btn-login').addClass('hidden');
            $('#nav-btn-register').addClass('hidden');
            $('#nav-btn-logout').removeClass('hidden');
        } 
        $('#content').html('');
        dataService.data.getAllPosts()
            .then(function(postsResults){
                allPosts = postsResults;
                return templateLoader.get('home');
            })
            .then(function(resultTemplate){
                var resultHtml = resultTemplate(allPosts);
                $content.html(resultHtml);

                $('#btn-create').on('click', function(){
                    if(dataService.users.isLogged()){
                        console.log('logged in');
                        var title = $('#create-title').val();
                        var body = $('#create-text').val();

                        var post = {
                            title: title,
                            body: body
                        };
                        var options = {
                            headers: {
                                "x-sessionkey": localStorage.getItem('SESSION_KEY')
                            }
                        };

                        dataService.data.createPost(post, options)
                            .then(function(){
                                context.redirect('#/');
                                $('#create-title').val('');
                                $('#create-text').val('');
                            });
                        
                    } else {
                        alert('You must be logged in to post comments!');
                    }
                });

                $('#btn-display').on('click', function(){
                    var pattern = $('#base-select option:selected').text();
                    var order = $('#order-select option:selected').text();
                    var numberOnPage = $('#page-select').val();
                    var start = 0;
                    var end = +numberOnPage;

                    var orderedResults;

                    dataService.data.getAllPosts()
                        .then(function(postsResults){
                            if(pattern == 'Title') {
                                if(order == 'Ascending'){
                                    sortByKeyAsc(postsResults, "title");
                                } else {
                                    sortByKeyDes(postsResults, "title");
                                }
                            } else { // pattern == Date
                                if(order == 'Ascending'){
                                    sortByKeyAsc(postsResults, "postDate");
                                } else {
                                    sortByKeyDes(postsResults, "postDate");
                                }
                            }

                            orderedResults = postsResults;
                            return templateLoader.get('display');
                        })
                        .then(function(responseTemplate){
                            $('#post-holder').html('');
                            var partArray = orderedResults.slice(start, end);

                            var html = responseTemplate(partArray);
                            $('#post-holder').html(html);

                            $('#next').on('click', function(){
                                start += +numberOnPage;
                                end += +numberOnPage;
                                if(end >= orderedResults.length) {
                                    start -= +numberOnPage;
                                    end -= +numberOnPage;
                                    return;
                                }
                                $('#display-post-holder').html('');
                                var partArray1 = orderedResults.slice(start, end);
                                
                                html = responseTemplate(partArray1);
                                $('#display-post-holder').html(html);
                            });

                            $('#prev').on('click', function(){
                                start -= +numberOnPage;
                                end -= +numberOnPage;
                                if(start < 0) {
                                    start += +numberOnPage;
                                    end += +numberOnPage;
                                    return;
                                }
                                $('#display-post-holder').html('');
                                var partArray2 = orderedResults.slice(start, end);
                            
                                html = responseTemplate(partArray2);
                                $('#display-post-holder').html(html);
                            });
                        });
                });
            });
    };

    var login = function(content, context){
        var $content = content;

        templateLoader.get('login')
            .then(function(resultTemplate){
                var resultHtml = resultTemplate;
                $content.html(resultHtml);
                
                $('#btn-login').on('click', function(ev){
                    var usernameString = $("#tb-username").val();
                    var passwordString = $("#tb-password").val();
                    var authString = '' + usernameString + passwordString;
                    var user = {
                        username: usernameString,
                        authCode: CryptoJS.SHA1(authString).toString()
                    };

                    dataService.users.login(user)
                        .then(function(respUser) {
                            $('#nav-btn-login').addClass('hidden');
                            $('#nav-btn-register').addClass('hidden');
                            $('#nav-btn-logout').removeClass('hidden');

                            localStorage.setItem('USERNAME', respUser.username);
                            localStorage.setItem('SESSION_KEY', respUser.sessionKey);

                            context.redirect('#/');
                            alert('You are now successfully logged in');
                        });

                    ev.preventDefault();
                    return false;
                });
            });
    };

    var register = function(content, context){
        var $content = content;

        templateLoader.get('register')
            .then(function(resultTemplate){
                var resultHtml = resultTemplate;
                $content.html(resultHtml);

                $('#btn-register').on('click', function(ev){
                    var usernameString = $("#tb-newUsername").val();
                    var passwordString = $("#tb-newPassword").val();
                    var authString = '' + usernameString + passwordString;
                    var user = {
                        username: usernameString,
                        authCode: CryptoJS.SHA1(authString).toString()
                    };

                    dataService.users.register(user)
                        .then(function(respUser) {
                            context.redirect('#/');
                            alert('You may now LOGIN with this username: ' + user.username);
                        });

                    ev.preventDefault();
                    return false;
                });
            });
    };

    function sortByKeyAsc(array, key) {
        return array.sort(function(a, b) {
            var x = a[key]; var y = b[key];
            return ((x < y) ? -1 : ((x > y) ? 1 : 0));
        });
    }

    function sortByKeyDes(array, key) {
        return array.sort(function(a, b) {
            var x = a[key]; var y = b[key];
            return ((x < y) ? 1 : ((x > y) ? -1 : 0));
        });
    }

    return {
        home: home,
        login: login, 
        register: register
    };
}());