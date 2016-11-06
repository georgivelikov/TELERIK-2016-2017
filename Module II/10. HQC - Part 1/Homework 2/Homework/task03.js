
var event = (function () {
    function onButtonClick() {
        var browserName = window.navigator.appCodeName;
        var isMozilla = (browserName === 'Mozilla');

        if (isMozilla) {
            alert('This script is running in Mozilla!');
        } else {
            alert('This script is not running in Mozilla!');
        }
    }

    return {
        onButtonClick: onButtonClick
    };
} ());
