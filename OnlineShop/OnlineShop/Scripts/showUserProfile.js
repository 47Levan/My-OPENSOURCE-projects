$(document).ready(function () {
 
    $('.showAccaunts').click(function () {
        alert(".showAccaunt works");
        $.get("/Auth/ShowAccaunts", function (PartialView) {
            $('#showProduct').empty();
            $('#showProduct').html(PartialView);
            $('#showProduct').show(PartialView);
        })
    });
    $('#submitEditProfile').click(function () {
    
        $("#EditProfile").ajaxForm({
            success: function (partialView) {
                $('#EditProfile').removeData(".validator")
                $('#EditProfile').removeData("unobtrusiveValidation");
                $.validator.unobtrusive.parse("#EditProfile");
                $('#showProduct').empty();
                $('#showProduct').html(partialView);
                $('#showProduct').show(partialView);
            }
        })
    })
  
})