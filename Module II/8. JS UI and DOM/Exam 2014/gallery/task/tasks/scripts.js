/* globals $ */
function solve() {
  $.fn.gallery = function (cols) {
    var $gallery = $(this);
    $gallery.addClass('gallery');
    if(cols === undefined){
      cols = 4;
    }
    var rows = Math.ceil(12 / cols);
    var $galleryList = $('.gallery-list');
    var $selected = $('.selected');
    $selected.hide();
    var $images = $('.image-container');
    var totalPictures = $images.length;
    var target = cols;

    for (var i = 0; i < $images.length; i++) {
      var $element = $($images[i]);
      if(i === target){
        $element.addClass('clearfix');
        target += cols;
      }
    }

    var createSelection = function(currentInfo){
      var currentId = currentInfo;
      var prevId = currentId - 1;
      var nextId = +currentId + 1;
      if(prevId < 1){
        prevId = $images.length;
      }
      if(nextId > $images.length){
        nextId = 0;
      }
      
      $selected.html('');
      var $prevDiv = $('<div>').addClass('previous-image');
      var $currentDiv = $('<div>').addClass('current-image');
      var $nextDiv = $('<div>').addClass('next-image');

      var $currentImg = $('<img>').attr({
        'class':'current-image',
        'src':'imgs/'+ currentId + '.jpg',
        'data-info' : '' + currentId
      });
      var $prevImg = $('<img>').attr({
        'class':'previous-image',
        'src':'imgs/'+ prevId + '.jpg',
        'data-info' : '' + prevId
      });
      var $nextImg = $('<img>').attr({
        'class':'next-image',
        'src':'imgs/'+ nextId + '.jpg',
        'data-info' : '' + nextId
      });

      $prevDiv.append($prevImg);
      $currentDiv.append($currentImg);
      $nextDiv.append($nextImg);

      $selected.append($prevDiv);
      $selected.append($currentDiv);
      $selected.append($nextDiv);
    }

    $galleryList.on('click', 'img',  function(){
      $galleryList.addClass('blurred');
      $('<div>').addClass('disabled-background').appendTo($gallery);
      $selected.show();
      var $this = $(this);
      var currentId = $this.attr('data-info');
      generateImageElements(currentId);
    });

    $gallery.on('click', '.selected .current-image', function () {
        $gallery.find('.gallery-list').removeClass('blurred');
        $gallery.find('.selected').removeClass('disabled-background');
        $gallery.find('.selected').hide();
    });

 $gallery.on('click', '.selected .previous-image', function () {
        $this = $(this);
        var currentId = parseInt($gallery.find('.selected .current-image img').attr('data-info'));
        if (currentId == 1) {
            currentId = totalPictures;

        } else {
            currentId -= 1;
        }

        generateImageElements(currentId);
    });

    $gallery.on('click', '.selected .next-image', function () {
        $this = $(this);
        var currentId = parseInt($gallery.find('.selected .current-image img').attr('data-info'));
        if (currentId == totalPictures) {
            currentId = 1;

        } else {
            currentId += 1;
        }

        generateImageElements(currentId);
    });

    function getPicturesFileName(currentPictureId) {
        var currentId = parseInt(currentPictureId),
            totalPictures = $gallery.find('.gallery-list').children('.image-container').size(),
            fileNames = [];
        fileNames['previous'] = currentId > 1 ? currentId - 1 : totalPictures;
        fileNames['current'] = currentId;
        fileNames['next'] = currentId < totalPictures ? currentId + 1 : 1;

        return fileNames;
    }

    function generateImageElements(currentId) {
        var pictureNames = getPicturesFileName(currentId);
        $gallery.find('.selected .previous-image img').attr('src', 'imgs/' + pictureNames['previous'] + '.jpg').attr('data-info', pictureNames['previous']);
        $gallery.find('.selected .current-image img').attr('src', 'imgs/' + pictureNames['current'] + '.jpg').attr('data-info', pictureNames['current']);
        $gallery.find('.selected .next-image img').attr('src', 'imgs/' + pictureNames['next'] + '.jpg').attr('data-info', pictureNames['next']);
    }
  }
};
module.exports = solve;