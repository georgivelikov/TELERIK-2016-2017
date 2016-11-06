function solve() {
    return function (selector) {
        var $selector = $(selector);
        var $container = $('<div>');
        $container.appendTo('body');

        $container.addClass('dropdown-list');
        $selector.appendTo($container)
                 .css('display', 'none');

        var $options = $selector.find('option');
        var defaultText = $($options[0]).html();
        var $current = $('<div>').css('display', '').html(defaultText);
        $current.addClass('current')
                .attr('data-value', '')
                .appendTo($container);
        
        var $optionsContainer = $('<div>')
            .addClass('options-container')
            .appendTo($container)
            .css({
                'position': 'absolute',
                'display': 'none'
            });
        $current.on('click', function () {
            var $content = $('.options-container');
            $content.css('display', 'inline-block');
        });

        $optionsContainer.on('click', function (ev) {
            var $clicked = $(ev.target);
            var $divToDisplay = $('.current');
            $divToDisplay.text($clicked.html());
            $selector.val($clicked.attr('data-value'));

            var $container = $(this)
                .css('display', 'none');
        });

        for (var i = 0; i < $options.length; i += 1) {
            var $div = $('<div>').addClass('dropdown-item')
                                 .appendTo($optionsContainer)
                                 .attr('data-value', $($options[i]).val())
                                 .attr('data-index', i - 1)
                                 .text($($options[i]).text());
        }
    };
}

module.exports = solve;