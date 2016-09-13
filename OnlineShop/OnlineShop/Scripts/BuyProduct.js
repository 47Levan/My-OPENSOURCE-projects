$(document).ready(function () {
    $("#ProductContainer button").click(function () {
        $.ajax({
            url: "/ShowProducts/BuyProduct",
            type: "GET",
            success: function (partialView) {
                $('body').empty();
                $('body').html(partialView);
                $('body').show(partialView);
            },
          
        });
     
    });

})