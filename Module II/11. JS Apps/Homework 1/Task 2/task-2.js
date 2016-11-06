function attatchRedirectEvent(addressToRedirect){
    var button = document.getElementById('button');

    button.addEventListener('click', function(){
        
        document.getElementById('simple-div').style.display = 'block';

        redirect(addressToRedirect)
         .then(function(redirectAddressAfterTimer){
             window.location.href = redirectAddressAfterTimer;
         });
    });
}

function redirect(redirectAddress) {
    return new Promise(function(resolve, reject){
        setTimeout(function(){
            resolve(redirectAddress);
        }, 2000);       
    });
}