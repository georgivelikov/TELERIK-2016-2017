var template = (function(){
    var handlebars = window.handlebars || window.Handlebars;
    var Handlebars = window.handlebars || window.Handlebars;

    var get = function(name){
        return new Promise(function(resolve, reject){
            var url = `../templates/${name}.handlebars`;
            $.get(url, function(resultHtml){
                var template = handlebars.compile(resultHtml);
                resolve(template);
            });
        });
    };

    return {
        get: get
    };
})();