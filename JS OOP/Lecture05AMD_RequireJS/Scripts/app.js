var people = [
    { id: 1, name: "Doncho Minkov", age: 18, avatarUrl: "images/minkov.jpg" },
    { id: 2, name: "Georgi Georgiev", age: 19, avatarUrl: "images/joreto.jpg" }];

requirejs.config({
    paths:{
        jquery : 'Libs/jquery-2.1.1.min',
        controls : 'Controls/controls',
        mustache : 'Libs/mustache'
    }
})

require(['jquery','controls'], function($,controls){
    container = document.getElementById('container');
    var comboBox = controls.ComboBox(people);
    var template = $("#person-template").html();
    comboBox.addEventListener('onExpanding',function(){alert('expanding')});
    comboBox.addEventListener('onCollapsing',function(){alert('collapsing')});
    var comboBoxHtml = comboBox.render(template);
    container.innerHTML = comboBoxHtml;

});