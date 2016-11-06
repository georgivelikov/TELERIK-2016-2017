var requester = {
    get(url) {
        var promise = new Promise((resolve, reject) => {
            $.ajax({
                url,
                method: "GET",
                success(response) {
                    resolve(response);
                }
            });
        });
        return promise;
    },
    putJSON(url, body, options = {}) {
        var promise = new Promise((resolve, reject) => {
            var headers = options.headers || {};
            $.ajax({
                url,
                headers,
                method: "PUT",
                contentType: "application/json",
                data: JSON.stringify(body),
                success(response) {
                    resolve(response);
                }
            });
        });
        return promise;
    },
    postJSON(url, body, options = {}) {
        var promise = new Promise((resolve, reject) => {
            var headers = options.headers || {};
            console.log(url);
            console.log(body);
            $.ajax({
                url,
                headers,
                method: "POST",
                contentType: "application/json",
                data: JSON.stringify(body),
                success(response) {
                    resolve(response);
                }
            });
        });
        return promise;
    },
    getJSON(url) {
        var promise = new Promise((resolve, reject) => {
            $.ajax({
                url,
                method: "GET",
                contentType: "application/json",
                success(response) {
                    resolve(response);
                }
            });
        });
        return promise;
    }
};