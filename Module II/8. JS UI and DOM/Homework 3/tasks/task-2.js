function solve() {
    return function (selector) {
        if (typeof selector != 'string' || $(selector).length == 0) {
            throw new Error
        }
        var $buttons = $('.button');
        var $contents = $('.content');
        $buttons.text('hide');
        for (var i = 0; i < $buttons.length; i += 1) {
            $($buttons[i]).on('click', function () {//!!!!!!!!!
                var $target = $(this),
                    nextE = $target.next(),
                    displayProp;

                if (!nextE) {
                    return;
                }
                while (!nextE.hasClass('content')) {
                    nextE = nextE.next();
                }

                displayProp = nextE.css('display');

                if (displayProp === 'none') {
                    nextE.css('display', '');
                    $target.text('hide');
                }
                else {
                    nextE.css('display', 'none')
                    $target.text('show');

                }
            });
        }
    };
};
module.exports = solve;