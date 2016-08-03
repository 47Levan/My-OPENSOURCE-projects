$(document).ready(function () {
    $(".subMenuItem").click(function () {
        $.ajax({
            url: '/Home/showProductsByFilter',
            data: { category: $(this).html()},
            type: 'GET',
            success: function (partialView) {
                $('#showProduct').html(partialView);
                $('#showProduct').show(partialView);
            },
            error:function (){
                alert("Error has occured");
            }
        })
        
})
})