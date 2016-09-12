
$(document).ready(function () {
    $('#userContainer > div:last-child > ul > li > ul >li:first-child > a').click(function () {
    $.ajax({
        url: '/AddProductsDialog/AddProducts',
        type: 'GET',
        success: function (partialView) {
            $('#showProduct').empty();
            $('#showProduct').html(partialView);
            $('#showProduct').show(partialView);
        },
        error: function (msg, url, linenumber) {
            alert('Error message: ' + msg + '\nURL: ' + url + '\nLine Number: ' + linenumber);
        }
    })
    })
   
})