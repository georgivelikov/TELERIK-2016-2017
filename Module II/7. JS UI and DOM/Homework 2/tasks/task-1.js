function solve(){
  return function (selector) {
    var element;
    var buttons;
    if (typeof selector === 'string') {
        element = document.getElementById(selector);
        
    }
    else if(selector instanceof HTMLElement) {
        element = selector;
    }
    else if (selector === null || selector === undefined){
        throw new Error();
    }

    buttons = element.getElementsByClassName('button');

    for (var i = 0; i < buttons.length; i++) {
        var button = buttons[i];
        button.innerHTML = 'hide';
        button.addEventListener('click', toggle, false);
    }

    function toggle(){
        var needToToggle = false;
        var clickedButton = this;
        var nextSibling = clickedButton.nextElementSibling;
        var currentContent;

        while(true){
            if(nextSibling.className == 'content'){
                currentContent = nextSibling;
                var currentContentSibling = currentContent.nextElementSibling;
                while(true){
                    if(currentContentSibling.className == 'button'){
                        needToToggle = true;
                        break;
                    }
                    else {
                        currentContentSibling = currentContentSibling.nextElementSibling;
                        if(currentContentSibling === null){
                            break;
                        }
                    }
                }
            }
            else {
                nextSibling = nextSibling.nextElementSibling;
            }

            if(needToToggle) {
                break;
            }

            if(nextSibling === null){
                break;
            }
        }

        if(needToToggle){
            if(clickedButton.innerHTML == 'hide'){
                clickedButton.innerHTML = 'show';
                currentContent.style.display = 'none';
            }
            else {
                clickedButton.innerHTML = 'hide';
                currentContent.style.display = '';
            }
        }
    }
  };
}

module.exports = solve;