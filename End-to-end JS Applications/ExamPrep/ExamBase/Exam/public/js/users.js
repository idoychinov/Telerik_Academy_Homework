//$(document).ready(function () {
//$('#delete-user').on('click', function (id) {
function deleteUser(id) {
    $.ajax({
        url: '/users/' + id,
        type: 'DELETE',
        success: function (response) {
            console.log(response);
            window.location = '/users';
        }
    });
}
$(document).ready(function () {
    var url = window.location.search.substring(1);
    var id = url.split('/');
    console.log(id);
    $('#update-user').on('click', function () {
        console.log(id);
        //function updateUser(id) {
        //    $.ajax({
        //        url: '/users/' + id,
        //        type: 'PUT',
        //        success: function (response) {
        //            console.log(response);
        //            window.location = '/users/' + id;
        //        }
        //    });
        //}
    });
});