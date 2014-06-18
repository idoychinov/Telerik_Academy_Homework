function createImagesPreviewer(selector, items) {
    var container = document.querySelector(selector),
        filterWrap = document.createElement("div");
    filter = document.createElement("input"),
    filterName = document.createElement("p"),
    leftSide = document.createElement("div"),
    imagePreview = document.createElement("img"),
    imagePreviewTitle = document.createElement("h2")
    rightSide = document.createElement("div"),
    list = document.createElement("ul"),
    listItem = document.createElement("li"),
    imageListTitle = document.createElement("h4"),
    itemImage = document.createElement("img"),
    IMAGE_WIDTH = 150,
    IMAGE_HEIGHT = 100,
    CONTAINER_WIDTH = 800,
    CONTAINER_HEIGHT = 600,
    IMAGE_PREVIEW_WIDTH = 400,
    IMAGE_PREVIEW_HEIGHT = 400;

    //Styles
    container.style.width = CONTAINER_WIDTH + "px";
    container.style.height = CONTAINER_HEIGHT + "px";

    filterWrap.style.position = "absolute";
    filterWrap.style.top = "20px";
    filterWrap.style.left = "20px";
    filterName.style.textAlign = "center";
    filterName.innerHTML = "Filter";
    filter.style.display = "block";
    filter.style.margin = "0 auto";
    imagePreview.width = IMAGE_PREVIEW_WIDTH;
    imagePreview.height = IMAGE_PREVIEW_HEIGHT;
    imagePreview.style.borderRadius = "15px";
    leftSide.style.display = "inline-block";
    leftSide.style.minHeight = IMAGE_PREVIEW_HEIGHT + "px";
    leftSide.style.height = IMAGE_PREVIEW_HEIGHT + 50 + "px";


    list.style.maxHeight = IMAGE_PREVIEW_HEIGHT + "px";
    list.style.maxWidth = IMAGE_WIDTH + 50 + "px";
    list.style.minWidth = IMAGE_WIDTH + 150 + "px";
    list.style.marginTop = "100px";
    list.style.padding = "0";
    list.style.marginLeft = "20px";
    list.style.listStyleType = "none";

    rightSide.style.overflowY = "auto";
    rightSide.style.overflowX = "hidden";
    rightSide.style.height = IMAGE_PREVIEW_HEIGHT + 50 + "px";

    listItem.style.width = IMAGE_WIDTH + "px";
    itemImage.width = IMAGE_WIDTH;
    itemImage.height = IMAGE_HEIGHT;
    itemImage.style.borderRadius = "5px";
    imageListTitle.style.textAlign = "center";
    imageListTitle.style.margin = "2px"
    imagePreviewTitle.style.textAlign = "center";


    // append to elements and append to DOM
    listItem.appendChild(imageListTitle);
    listItem.appendChild(itemImage);

    rightSide.appendChild(filterWrap);
    rightSide.appendChild(prepareImageList());
    rightSide.style.display = "inline-block";
    rightSide.style.position = "relative";
    rightSide.style.minHeight = IMAGE_PREVIEW_HEIGHT + "px";

    leftSide.appendChild(imagePreviewTitle);
    leftSide.appendChild(imagePreview);

    filterWrap.appendChild(filterName);
    filterWrap.appendChild(filter);

    container.appendChild(leftSide);
    container.appendChild(rightSide);

    function prepareImageList() {
        for (i in items) {
            imageListTitle.innerHTML = items[i].title;
            itemImage.src = items[i].url;
            itemImage.alt = items[i].title;
            list.appendChild(listItem.cloneNode(true));

        }
        imagePreview.src = items[0].url;
        imagePreviewTitle.innerHTML = items[0].title;
        return list;
    }

    // Events

    list.addEventListener('click', onImageClick);
    list.addEventListener('mouseover', onImageHover);
    list.addEventListener('mouseout', onImageUnHover);
    filter.addEventListener('input', onFilterContentChange);


    //Event Handlers

    function onImageClick(ev) {
        var tag = ev.target.tagName.toLowerCase(),
            parent = ev.target.parentNode;
        if (tag === "img") {
            imagePreview.src = ev.target.src;
            imagePreviewTitle.innerHTML = parent.querySelector("h4").innerHTML;

        }
    }

    function onImageHover(ev) {
        var tag = ev.target.tagName.toLowerCase(),
            parent = ev.target.parentNode;

        if (tag === "img") {
            parent.style.backgroundColor = "grey";
        }
    }

    function onImageUnHover(ev) {
        var tag = ev.target.tagName.toLowerCase(),
            parent = ev.target.parentNode;

        if (tag === "img") {
            parent.style.backgroundColor = "white";
        }
    }

    function onFilterContentChange() {
        var pattern = this.value.toLowerCase(),
            items = list.childNodes,
            length = items.length;

        if (pattern === '') {
            for (i = 0; i < length; i++) {
                items[i].style.display = "list-item";
            }


        } else {
            for (i = 0; i < length; i++) {
                console.log(items[i].querySelector("h4"));
                if (items[i].querySelector("h4").innerHTML.toLowerCase().indexOf(pattern) < 0) {
                    items[i].style.display = "none";
                }
            }

        }

    }
}