var templateLoader = (function(){
    var handlebars = window.handlebars || window.Handlebars;
    var Handlebars = window.handlebars || window.Handlebars;

    var cache = {};

    function get(name){
        var promise = new Promise(function(resolve, reject){
            if(cache[name]){
                resolve(cache[name]);
                return;
            }
            
            var url = `../templates/${name}.handlebars`;
            $.get(url, function(templateHtml){
                var template = handlebars.compile(templateHtml);
                cache[name] = template;
                resolve(template);
            });
        });

        return promise;
    }

    return {
        get: get
    };
}());
