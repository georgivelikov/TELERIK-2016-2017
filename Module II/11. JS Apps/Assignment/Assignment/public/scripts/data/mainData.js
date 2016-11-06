var mainData = (function(){
    var getAllMaterialsUrl = 'api/materials';
    var _this = this;
    var getAllMaterials = function(){
        return requester.getJSON(getAllMaterialsUrl);
    };

    var getSingleMaterial = function(id){
        var url = 'api/materials/' + id;
        return requester.getJSON(url);
    };

    var searchMaterial = function(pattern){
        var url = 'api/materials?filter=' + pattern;

        return requester.getJSON(url);
    };

    var leaveComment = function(id, text){
        var url = `api/materials/${id}/comments`;

        var body = {
            'commentText': text
        };

        var headers = {
            'x-auth-key': localStorage.getItem('AUTH_KEY')
        };

        return requester.putJSON(url, body, { headers });
    };

    var addNewMaterial = function(title, text, img){

        var body = {
            title: title,
            description: text,
            img: img
        };

        var headers = {
            'x-auth-key': localStorage.getItem('AUTH_KEY')
        };

        return requester.postJSON('api/materials', body, { headers });
    };

    var checkForMaterial = function(){
        var headers = {
            'x-auth-key': localStorage.getItem('AUTH_KEY')
        };
        return requester.getJSON('api/user-materials', { headers })
            .then(function(response){
                var materialsForUser = response.result;
                for(var i = 0; i < materialsForUser.length; i += 1){
                    var currentMaterial = materialsForUser[i];
                    if(id = currentMaterial.id){
                        return true;
                    }
                }

                return false;
            });
    };

    var assignStatus = function(id, status){
        var headers = {
            'x-auth-key': localStorage.getItem('AUTH_KEY')
        };
        var body = {
            'id': id,
            'category': status
        };

        if(this.checkForMaterial()){
            return requester.putJSON('api/user-materials', body, { headers });
        } else {
            return requester.postJSON('api/user-materials', body, { headers });
        }
    };

    return {
        getAllMaterials: getAllMaterials,
        getSingleMaterial: getSingleMaterial,
        searchMaterial: searchMaterial,
        leaveComment: leaveComment,
        addNewMaterial: addNewMaterial,
        assignStatus: assignStatus,
        checkForMaterial: checkForMaterial
    };
}());