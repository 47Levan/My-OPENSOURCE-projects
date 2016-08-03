$(document).ready(function () {
    $('#DataOperationsAdd').click(function(){   
    $.ajax({
        url: '/Home/AddProducts',
        type: 'GET',
        success:function(partialView){
            $('#showProduct').html(partialView);
            $('#showProduct').show(partialView);
        },
        error:function(){
            alert('Error has occured');
        }
    })
    })
    $('#submitValidation').click(function () {
        if ($("#valForm").valid()) {
            alert($("#valForm").valid());
            $.ajax({
                url: '/Home/AddProducts',
                data: $("#valForm").serialize(),
                type: 'POST',
                success: function (partialView) {
                    $("#valForm").removeData("validator");
                    $("#valForm").removeData("unobtrusiveValidation");
                    $('#showProduct').html(partialView);
                    $('#showProduct').show(partialView);
                    $.validator.unobtrusive.parse("#valForm");
                },
                error: function () {
                    alert('Error has occured');
                }
            })
        }
        else {
            alert($("#valForm").valid());
        }
    });
})