var data = (function () {
  const USERNAME_STORAGE_KEY = 'username-key';

  // start users
  function userLogin(user) {
    localStorage.setItem(USERNAME_STORAGE_KEY, user);
    return Promise.resolve(user);
  }

  function userLogout() {
    localStorage.removeItem(USERNAME_STORAGE_KEY);
    return Promise.resolve();
  }

  function userGetCurrent() {
    return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
  }
  // end users

  // start threads
  function threadsGet() {
    return new Promise((resolve, reject) => {
      $.getJSON('api/threads')
        .done(resolve)
        .fail(reject);
    });
  }

  function threadsAdd(title) {
        return new Promise((resolve, reject) => {
            userGetCurrent()
            .then((username) =>{
                var body = {
                    title: title,
                    username: username
                };
                $.ajax({
                    url: 'api/threads',
                    method: 'POST',
                    data: JSON.stringify(body),
                    contentType: 'application/json',
                    success: function(newBody){
                        resolve(newBody);
                    }
                }); 
            });
        });
  }

  function threadById(id) {
      return new Promise((resolve, reject) => {
        var body = {
            id: id,
        };
        $.ajax({
            url: 'api/threads/'+id,
            method: 'GET',
            data: JSON.stringify(body),
            contentType: 'application/json',
            success: function(newBody){
                resolve(newBody);
            }
        });  
    });
  }

  function threadsAddMessage(threadId, content) {
      return new Promise(function(resolve, reject){
          userGetCurrent()
          .then(function(username){
              var body = {
                  content,
                  username,
              };

              $.ajax({
                  url: 'api/threads/'+threadId+'/messages',
                  method: 'POST',
                  data:JSON.stringify(body),
                  contentType: 'application/json',
                  success: function(newBody){
                      resolve(newBody);
                  }
              });
          });
      });
  }
  // end threads

  // start gallery
  function galleryGet() {
    const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;

    return new Promise((resolve, reject) => {
            $.ajax({
                    url: REDDIT_URL,
                    dataType: 'jsonp',
                    success: function(result) {
                        resolve(result);
                    }
                });
        });
  }
  // end gallery

  return {
    users: {
      login: userLogin,
      logout: userLogout,
      current: userGetCurrent
    },
    threads: {
      get: threadsGet,
      add: threadsAdd,
      getById: threadById,
      addMessage: threadsAddMessage
    },
    gallery: {
      get: galleryGet,
    }
  }
})();