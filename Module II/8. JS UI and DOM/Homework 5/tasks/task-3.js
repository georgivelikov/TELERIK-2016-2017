function solve() {
    return function () {
        $.fn.listview = function (data) {
            var templateId = this.attr('data-template'),
                template = $('#' + templateId).html(),
                compiledHTML = handlebars.compile(template),
                i,
                len;

            for (i = 0, len = data.length; i < len; i += 1) {
                this.append(compiledHTML(data[i]));
            }

            return this;
        };
    };
};

module.exports = solve;