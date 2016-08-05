$(document).ready(function () {
    $('#DataOperationsAdd').click(function(){   
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
    $('#submitValidation').click(function () {
        if ($("#valForm").valid()) {
             
            //alert($("#valForm").valid());
            $.ajax({
                url: '/AddProductsDialog/ShowAddedProduct',
                data: $("#valForm").serialize(),
                type: 'POST',
                success: function (partialView) {
                    $("#valForm").removeData("validator");
                    $("#valForm").removeData("unobtrusiveValidation");               
                    $.validator.unobtrusive.parse("#valForm");
                    
                },
                error: function () {
                    alert('Error has occured');
                }
            })
        }
        else {
            //alert($("#valForm").valid());
        }
    });
})