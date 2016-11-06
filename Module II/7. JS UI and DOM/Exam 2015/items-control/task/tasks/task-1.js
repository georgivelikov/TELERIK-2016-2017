/* globals module, document, HTMLElement, console */

function solve() {
    return function(selector, isCaseSensitive) {
        // to do fix if class or tagname
        var root;
        if(typeof selector === 'string'){
            root = document.querySelector(selector);
        }
        else {
            root = selector;
        }

        if(isCaseSensitive == null){
            isCaseSensitive = false;
        }

        var df = document.createDocumentFragment();
        
        var itemsControl = document.createElement('div');
        itemsControl.className = 'items-control';
        df.appendChild(itemsControl);

        var addControl = document.createElement('div');
        addControl.className = 'add-controls';
        
        var searchControl = document.createElement('div');
        searchControl.className = 'search-controls';
        var resultControl = document.createElement('div');
        resultControl.className = 'result-controls';

        itemsControl.appendChild(addControl);
        itemsControl.appendChild(searchControl);
        itemsControl.appendChild(resultControl);

        var addControlLabel = document.createElement('label');
        addControlLabel.innerHTML = 'Enter text';
        addControl.appendChild(addControlLabel);
        

        var addControlInput = document.createElement('input');
        addControl.appendChild(addControlInput);

        var addControlButton = document.createElement('button');
        addControlButton.className = 'button';
        addControlButton.innerHTML = 'Add';
        addControl.appendChild(addControlButton);

        var searchControlLabel = document.createElement('label');
        searchControlLabel.innerHTML = 'Search';
        searchControl.appendChild(searchControlLabel);

        var searchControlInput = document.createElement('input');
        searchControl.appendChild(searchControlInput); 
        
        var list = document.createElement('ul');
        list.className = 'items-list';
        resultControl.appendChild(list);

        var btnDeleteTemplate = document.createElement('button');
        btnDeleteTemplate.innerHTML = 'X';
        btnDeleteTemplate.className = 'button';

        function deleteLi(ev) {
            var btn = ev.target;
            if(btn.className !== 'button'){
                return;
            }
            
            var itemToDelete = btn.parentNode;
            itemToDelete.outerHTML = "";
        }

         list.addEventListener('click', deleteLi, false);

        var textTemplate = document.createElement('strong');

        var itemTemplate = document.createElement("li");
        itemTemplate.className = "list-item";
        itemTemplate.appendChild(btnDeleteTemplate);
        itemTemplate.appendChild(textTemplate);

        function createLi(){
            var textFromAddTextbox = addControlInput.value;
            textTemplate.innerHTML = textFromAddTextbox;
            newItem = itemTemplate.cloneNode(true);

            list.appendChild(newItem);
        }

        var items = list.childNodes;

        function searchText(){
            var searchedText = searchControlInput.value;

            [].forEach.call(list.childNodes, function(element){
                var str = element.querySelector('strong');

                var searchedInput = str.innerHTML;
                if(!isCaseSensitive){
                    searchedInput = searchedInput.toLowerCase();
                    searchedText = searchedText.toLowerCase();
                }
                
                if(searchedInput.indexOf(searchedText) != -1){
                    element.style.display = '';
                }
                else {
                    element.style.display = 'none';
                }
            });
        }
        
        addControlButton.addEventListener('click', createLi, false);
        searchControlInput.addEventListener('input', searchText, false);


        root.appendChild(df);
    };
}

//module.exports = solve;