/* globals module */
function solve() {
    return function (selector, items) {
      var root = document.querySelector(selector);
      var leftDiv = document.createElement('section');
      var rightDiv = document.createElement('aside');
      leftDiv.style.cssFloat = 'left';
      rightDiv.style.cssFloat = 'left';
      leftDiv.style.paddingRight = '50px';
      leftDiv.className = 'image-preview';
      root.appendChild(leftDiv);
      root.appendChild(rightDiv);

      var sideWidth = 200;
      var sideHeight = 150;
      rightDiv.style.height = '500px';
      rightDiv.style.overflowY = 'scroll';
      var selectedTitle = document.createElement('h1');
      selectedTitle.innerHTML = items[0].title;
      selectedTitle.style.textAlign = 'center';

      var selectedImage = document.createElement('img');
      selectedImage.src = items[0].url;
      selectedImage.style.borderRadius = '20px';
      selectedImage.style.width = 2 * sideWidth + 'px';
      selectedImage.style.height = 2 * sideHeight + 'px';

      leftDiv.appendChild(selectedTitle);
      leftDiv.appendChild(selectedImage);

      var sideMenuForm = document.createElement('input');
      var sideMenuLabel = document.createElement('label');
      sideMenuForm.style.display = 'block';
      sideMenuForm.style.width = sideWidth + 'px';
      sideMenuLabel.style.display = 'block';
      sideMenuLabel.style.textAlign = 'center';
      sideMenuLabel.innerHTML = 'Filter';

      rightDiv.appendChild(sideMenuLabel);
      rightDiv.appendChild(sideMenuForm);
      
      for(var i = 0; i < items.length; i += 1){
        var sideImageDiv = document.createElement('div');
        sideImageDiv.className = 'image-container';
        var sideImage = document.createElement('img');
        sideImage.src = items[i].url;
        sideImageDiv.style.width = sideWidth + 'px';
        sideImageDiv.style.height = sideHeight + 'px';
        sideImageDiv.style.display = 'block';
        sideImageDiv.style.padding = '5px';
        sideImageDiv.style.textAlign = 'center';
        sideImage.style.width = sideWidth * 0.9 + 'px';
        sideImage.style.height = sideHeight * 0.9 + 'px';
        
        var sideTitle = document.createElement('h4');
        sideTitle.innerHTML = items[i].title;
        sideTitle.style.margin = '0';
        sideTitle.style.textAlign = 'center';
        
        sideImageDiv.appendChild(sideTitle);
        sideImageDiv.appendChild(sideImage);
        rightDiv.appendChild(sideImageDiv);
      }

      var attatchHoverEventIn = function(){
        this.style.backgroundColor = 'grey';
      };
      var attatchHoverEventOut = function(){
        this.style.backgroundColor = 'white';
      };
      
      rightDiv.addEventListener('mouseover', function(ev){
        var target = ev.target;
        if(target.tagName === 'IMG'){
          target.parentElement.style.backgroundColor = 'grey';
        }
      }, false);
      rightDiv.addEventListener('mouseout', function(ev){
        var target = ev.target;
        if(target.tagName === 'IMG'){
          target.parentElement.style.backgroundColor = '';
        }
      }, false);
      rightDiv.addEventListener('click', function(ev){
        var target = ev.target;
        if(target.tagName === 'IMG'){
          var title = target.parentElement.getElementsByTagName('h4')[0].innerHTML;
          selectedTitle.innerHTML = title;
          selectedImage.src = target.src;
        }
      }, false);
      var containers = rightDiv.getElementsByClassName('image-container');
      sideMenuForm.addEventListener('input', function(){
        console.log('event');
        var text = sideMenuForm.value.toLowerCase();
        for(i = 0; i < containers.length; i++){
          var container = containers[i];
          var hText = container.getElementsByTagName('h4')[0].innerHTML.toLowerCase();
          var index = hText.indexOf(text);
          if(index > -1){
            container.style.display = 'block';
          }
          else {
            container.style.display = 'none';
          }
        }

      }, false);
      
    };
}

//module.exports = solve;