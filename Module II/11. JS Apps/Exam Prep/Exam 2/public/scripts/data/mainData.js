var mainData = (function(){
    var getAllCookiesUrl = 'api/cookies';
    var shareCookieUrl = 'api/cookies';

    var getAllCookies = function(){
        return requester.getJSON(getAllCookiesUrl);
    };

    var shareCookie = function(newCookie){
        var headers = {
            'x-auth-key': localStorage.getItem('AUTH_KEY')
        };

        return requester.postJSON(shareCookieUrl, newCookie, { headers: headers });
    };

    return {
        getAllCookies: getAllCookies,
        shareCookie: shareCookie
    };
}());