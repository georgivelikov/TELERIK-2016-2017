var mainController = (function(){
    var home = function(content, context){
        var $content = content;
        var allMaterials = [];

        mainData.getAllMaterials()
        .then(function(response){
            allMaterials = response.result;
            return templateLoader.get('home');
        })
        .then(function(resultTemplate) {
            $content.html(resultTemplate(allMaterials));

            $('#search-btn').on('click', function(){
                var pattern = $('#search-bar').val();
                var address = '#/home/' + pattern;
                context.redirect(address);
            });

            $('#add-btn').on('click', function(){
                if(!usersController.isLogged()){
                    alert('You must log in to add new material');
                    return;
                }

                var title = $('#title-bar').val();
                var text = $('#text-bar').val();
                var url = $('#url-bar').val();

                if(!validator.validateLength(title, 6, 100) || !validator.validateType(title)){
                    alert('Invalid title');
                    return;
                }
                if(!validator.validateType(text)){
                    alert('Invalid text');
                    return;
                }

                var newMaterial;
                mainData.addNewMaterial(title, text, url).
                    then(function(response){
                        newMaterial = response.result;
                        return templateLoader.get('new-material');
                    })
                    .then(function(resultTemplate){
                        $('#materials-holder').prepend(resultTemplate(newMaterial));
                    });
            });
        });
    };

    var singleMaterial = function(content, context, id){
        var $content = content;
        var material;

        mainData.getSingleMaterial(id)
            .then(function(response){
                material = response.result;
                return templateLoader.get('single-material');
            })
            .then(function(resultTemplate) {
                $content.html(resultTemplate(material));

                $('#leave-comment').on('click', function(){
                    if(!usersController.isLogged()){
                        alert('You must log in to comment');
                        return;
                    }
                    var text = $('#comment-area').val();
                    var newComment;
                    mainData.leaveComment(id, text)
                        .then(function(response){
                            newComment = response.result.comments[response.result.comments.length - 1];
                            return templateLoader.get('new-comment');
                        })
                        .then(function(resultTemplate){
                            $('#comments-holder').append(resultTemplate(newComment));
                        });
                });

                $('#assign-btn').on('click', function(){
                    if(!usersController.isLogged()){
                        alert('You must log in to assign status');
                        return;
                    }

                    var status = $('#category-select').find(":selected").text();
                    
                    mainData.assignStatus(id, status)
                        .then(function(response){
                            console.log(response);
                            alert('See user page for the change');
                        });
                });
            });
    };

    var searchMaterial = function(content, context, pattern){
        var $content = content;
        var materials;

        mainData.searchMaterial(pattern)
            .then(function(response){
                materials = response.result;
                console.log(materials);
                return templateLoader.get('search-material');
            })
            .then(function(resultTemplate) {
                $content.html(resultTemplate(materials));
            });
    };

    return {
        home: home,
        singleMaterial: singleMaterial,
        searchMaterial: searchMaterial
    };
}());