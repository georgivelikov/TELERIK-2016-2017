$(() => { // on document ready
    const GLYPH_UP = 'glyphicon-chevron-up',
            GLYPH_DOWN = 'glyphicon-chevron-down',
            root = $('#root'),
            navbar = root.find('nav.navbar'),
            mainNav = navbar.find('#main-nav'),
            contentContainer = $('#root #content'),
            loginForm = $('#login'),
            logoutForm = $('#logout'),
            usernameSpan = $('#span-username'),
            usernameInput = $('#login input'),
            alertTemplate = $($('#alert-template').text());
    
    var router = new Navigo(null, false);

    router
    .on('/gallery', function(){
        var galleryPictures;
        
        data.gallery.get()
            .then(function(response){
                galleryPictures = response.data.children;
                return template.get('gallery');
            })
            .then(function(resultTemplate){
                contentContainer.html(resultTemplate(galleryPictures));
            });
    })
    .on('/#', function(){
        template.get('home')
            .then(function(resultTemplate){
                contentContainer.html(resultTemplate);
            });
    })
    .on('/threads', function(){
        var allThreads;
        
        data.threads.get()
            .then(function(response){
                allThreads = response.result;
                return template.get('threads');
            })
            .then(function(resultTemplate){
                contentContainer.html(resultTemplate(allThreads));
            });
    });

    (function checkForLoggedUser() {
        data.users.current()
        .then((user) => {
            if (user) {
            usernameSpan.text(user);
            loginForm.addClass('hidden');
            logoutForm.removeClass('hidden');
            }
        });
    })();
            
    function showMsg(msg, type, cssClass, delay) {
        let container = alertTemplate.clone(true)
            .addClass(cssClass).text(`${type}: ${msg}`)
            .appendTo(root);

        setTimeout(() => {
        container.remove();
        }, delay || 2000)
    }

    contentContainer.on('click', '#btn-add-thread', (ev) => {
        var title = $(ev.target).parents('form').find('input#input-add-thread').val() || null;
        var newThread;
        data.threads.add(title)
            .then(function(response){
                newThread = response.result;
                return template.get('new-thread');
            })
            .then(function(resultTemplate){
                $('#threads-rapper').append(resultTemplate(newThread));
                $('#input-add-thread').val('');
                showMsg('Successfuly added the new thread', 'Success', 'alert-success');
            })
            .catch((err) => showMsg(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));
    });

    contentContainer.on('click', 'a.thread-title', (ev) => {
        var $target = $(ev.target);
        var threadId = $target.parents('.thread').attr('data-id');
        var searchedThread;
        data.threads.getById(threadId)
        .then(function(response){
            searchedThread = response.result;
            return template.get('messages');
        })
        .then(function(resultTemplate){
            $('.container-messages').html(''); // delete this row if you prefer multiple threads to be shown
            $('#content').append(resultTemplate(searchedThread));
        })
        .catch((err) => showMsg(err, 'Error', 'alert-danger'));
    });

    contentContainer.on('click', '.btn-add-message', (ev) => {
        var $target = $(ev.target);
        var $container = $target.parents('.container-messages');
        var threadId = $container.attr('data-thread-id');
        var msg = $container.find('.input-add-message').val();
        $container.find('.input-add-message').val('');
        var newMessage;

        data.threads.addMessage(threadId, msg)
            .then(function(response){
                newMessage = response.messages[response.messages.length - 1];
                return template.get('new-message');                              
            })
            .then(function(newResultTemplate){
                $(`#messages-rapper-${threadId}`).append(newResultTemplate(newMessage));
                showMsg('Successfuly added the new mssagee', 'Success', 'alert-success');
            })
            .catch((err) => showMsg(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));                       
    });

    contentContainer.on('click', '.btn-close-msg', (ev) => {
        let msgContainer = $(ev.target).parents('.container-messages').remove();
    });

    contentContainer.on('click', '.btn-collapse-msg', (ev) => {
        let $target = $(ev.target);
        if ($target.hasClass(GLYPH_UP)) {
        $target.removeClass(GLYPH_UP).addClass(GLYPH_DOWN);
        } else {
        $target.removeClass(GLYPH_DOWN).addClass(GLYPH_UP);
        }

        $target.parents('.container-messages').find('.messages').toggle();
    });

    navbar.on('click', 'li', (ev) => {
        let $target = $(ev.target);
        $target.parents('nav').find('li').removeClass('active');
        $target.parents('li').addClass('active');
    });

    navbar.on('click', '#btn-login', (ev) => {
        let username = usernameInput.val() || 'anonymous';
        data.users.login(username)
        .then((user) => {
            usernameInput.val('');
            usernameSpan.text(user);
            loginForm.addClass('hidden');
            logoutForm.removeClass('hidden');
        });
    });

    navbar.on('click', '#btn-logout', (ev) => {
        data.users.logout()
        .then(() => {
        usernameSpan.text('');
        loginForm.removeClass('hidden');
        logoutForm.addClass('hidden');
        })
    });
});