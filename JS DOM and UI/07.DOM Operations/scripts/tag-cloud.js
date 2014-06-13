/* Task 04. Create a tag cloud:
Visualize a string of tags (strings) in a given container
By given minFontSize and maxFontSize, generate the tags with different font-size, depending on the number of occurrences
*/
window.onload = function () {
    var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "js", "http", "web",
        "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "js", "cms", "html", "javascript", "http", "http", "CMS"],
        tagCloud;

    function generateTagCloud(tagsList, minFont, maxFont) {
        var tagCloudElement,
            uniqueTags = [],
            min,
            max,
            current,
            currentElement,
            fontChangeStep;

        for (var i in tagsList) {
            current = tagsList[i];
            if (isNaN(uniqueTags[current])) {
                uniqueTags[current] = 1;
            } else {
                uniqueTags[current] += 1;
            }
        }

        max = 0;
        min = Number.MAX_SAFE_INTEGER;
        for (var i in uniqueTags) {
            current = uniqueTags[i];
            if (current < min) {
                min = current;
            }
            if(current > max){
                max = current;
            }
        }
        
        fontChangeStep = ((maxFont - minFont) / (max - min)) | 0;

        tagCloudElement = document.createDocumentFragment();

        for (var tag in uniqueTags) {
            current = uniqueTags[tag];
            currentElement = document.createElement("span");
            currentElement.style.fontSize = (minFont + ((current - 1) * fontChangeStep)) + "px";
            currentElement.style.margin ="0px 10px";

            currentElement.innerHTML = tag;
            tagCloudElement.appendChild(currentElement);
        }

        return tagCloudElement;
    };


    tagCloud = generateTagCloud(tags, 17, 42);
    document.querySelector("#tag-cloud").appendChild(tagCloud);
}

