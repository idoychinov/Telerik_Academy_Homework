/*Task 3. Create a text area and two inputs with type="color"
Make the font color of the text area as the value of the first color input
Make the background color of the text area as the value of the second input
*/

window.onload = function () {
    document.getElementById("font-color").addEventListener("change", ChangeFontColor);
    document.getElementById("background-color").addEventListener("change", ChangebackgroundColor);

    function ChangeFontColor() {
        var value = document.getElementById("font-color").value;
        document.getElementById("area").style.color = value;
    }

    function ChangebackgroundColor() {
        var value = document.getElementById("background-color").value;
        document.getElementById("area").style.backgroundColor = value;
    }
}