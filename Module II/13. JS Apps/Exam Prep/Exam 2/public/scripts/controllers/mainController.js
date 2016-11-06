var mainController = (function(){
    var home = function(content, context){
        var $content = content;
        var _this = this;
        var cookiesArray = [];
        var categoriesArray = new Set();

        mainData.getAllCookies()
            .then(function(response){
                cookiesArray = response.result;
                for(var i = 0; i < cookiesArray.length; i += 1){
                    categoriesArray.add(cookiesArray[i].category);
                }
                return templateLoader.get('home');
            })
            .then(function(resultTemplate) {
                $content.html(resultTemplate(cookiesArray));

                $('#cookie-category').autocomplete({
                    source: Array.from(categoriesArray)
                });

                $('#add-cookie-btn').on('click', function(){
                    var newCookie = {
                        category: $('#cookie-category').val(),
                        text: $('#cookie-text').val(),
                        img: $('#cookie-img-url').val | undefined
                    };

                    mainData.shareCookie(newCookie)
                        .then(function(){
                            window.reaload();
                        });
                });
            });
    };

    return {
        home: home
    };
}());