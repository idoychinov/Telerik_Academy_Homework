window.onload = function () {
    var showHideButton,
        addButton,
        deleteButton,
        addtext,
        toDoList,
        toDoForm;

    showHideButton = document.querySelector("#show-hide-button");
    showHideButton.innerHTML = "Hide";
    showHideButton.addEventListener("click", toggleListVisability);

    addButton = document.querySelector("#add-button");
    addButton.addEventListener("click", onAddClick);

    deleteButton = document.querySelector("#delete-button");
    deleteButton.addEventListener("click", onDeleteClick);

    addtext = document.querySelector("#add-text");
    toDoList = document.querySelector("#todo-list");
    toDoForm = document.querySelector("#todo-form");
    
    function toggleListVisability() {
        if (this.innerHTML === "Show") {
            toDoForm.style.display = "block";
            this.innerHTML = "Hide";
        } else {
            toDoForm.style.display = "none";
            this.innerHTML = "Show";
        }
    }

    function onAddClick(ev) {
        var fragment = document.createDocumentFragment(),
            option = document.createElement("option");

        option.innerHTML = addtext.value;
        fragment.appendChild(option);
        toDoList.appendChild(fragment);
    }
    
    function onDeleteClick() {
        var items = toDoList.childNodes,
            itemsToRemove=[];

        for (var i in items) {
            if (items[i].selected) {
                itemsToRemove.push(items[i])
            }
        }

        for (var i in itemsToRemove) {
            toDoList.removeChild(itemsToRemove[i]);
        }
    }
}