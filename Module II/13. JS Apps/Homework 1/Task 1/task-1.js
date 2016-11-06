(function () {
    var positionPromise = new Promise(function(resolve) {
        navigator.geolocation.getCurrentPosition(
            function(position) {
                console.log(position);
                resolve(position);
            }, function(error){
                console.log(error);
            });
    });

    function getPositionCoordinates(position){
        return { lat: position.coords.latitude, long: position.coords.longitude };
    }   

    function createGeolocationImage(coords) {
        var imgElement = document.createElement('img');
        var imgSrc = "http://maps.googleapis.com/maps/api/staticmap?center=" + coords.lat + "," + coords.long + "&zoom=16&size=500x500&sensor=false";

        imgElement.setAttribute("src", imgSrc);

        document.body.appendChild(imgElement);
    }

    positionPromise
        .then(getPositionCoordinates)
        .then(createGeolocationImage);
})();