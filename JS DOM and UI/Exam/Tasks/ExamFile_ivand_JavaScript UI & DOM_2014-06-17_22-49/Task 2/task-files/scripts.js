$.fn.gallery = function () {
    var $gallery = $(this),
        columns = arguments[0] ? arguments[0] : 4, // assigns 4 in the case of no argument passed, or if falslike first argument is passed including 0.
        $galleryList,
        $firstImageWidht,
        $selected,
        $prevImage,
        $currentImage,
        $nextImage,
        galleryListWidht;
        

    // select all the important items and save them as jQuery object variables
    $gallery.addClass("gallery");
    $galleryList = $gallery.find(".gallery-list");
    $firstImageWidht = $galleryList.find(".image-container").outerWidth(true);
    galleryListWidht = columns * $firstImageWidht;
    $galleryList.width(galleryListWidht);
    $selected = $gallery.find(".selected").hide();
    $prevImage = $selected.find(".previous-image").find("img");
    $currentImage = $selected.find(".current-image").find("img");
    $nextImage = $selected.find(".next-image").find("img");


    // apply event listeners

    $gallery.on('click', '.image-container', onImageContainerClick);
    $selected.on('click', '.current-image', onCurrentImageClick);
    $selected.on('click', '.next-image', onNextImageClick);
    $selected.on('click', '.previous-image', onPrevImageClick);

    function onImageContainerClick() {
        if($gallery.hasClass("disabled-background")){
            return;
        }
        loadImagesInSelected($(this).find("img").attr("data-info"));
        $galleryList.addClass("blurred");
        $selected.show();
        $gallery.addClass("disabled-background");
    }

    function onCurrentImageClick() {
        $galleryList.removeClass("blurred");
        $selected.hide()
        $gallery.removeClass("disabled-background");
    }

    function onNextImageClick() {
        loadImagesInSelected($(this).find("img").attr("data-info"));
    }

    function onPrevImageClick() {
        loadImagesInSelected($(this).find("img").attr("data-info"));
    }

    function loadImagesInSelected(dataInfo) {
        var $next,
            $prev,
            $clickedImage = $galleryList.find(".image-container img[data-info=" + dataInfo + "]"),
            $clickedImageParent = $clickedImage.parent();

        $currentImage.attr("src", $clickedImage.attr("src"));
        $currentImage.attr("data-info", $clickedImage.attr("data-info"));

        $next = $clickedImageParent.next().length === 0 ? $galleryList.find(":first-child") : $clickedImageParent.next();
        $prev = $clickedImageParent.prev().length === 0 ? $galleryList.find(":last-child") : $clickedImageParent.prev();

        $nextImage.attr("src", $next.find("img").attr("src"));
        $nextImage.attr("data-info", $next.find("img").attr("data-info"));
        $prevImage.attr("src", $prev.find("img").attr("src"));
        $prevImage.attr("data-info", $prev.find("img").attr("data-info"));
    }

    return $gallery;
};