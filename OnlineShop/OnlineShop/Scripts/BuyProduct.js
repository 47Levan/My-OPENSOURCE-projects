var button = "#ProductContainer button";
$(document).ready(function () {
    $(button).click(function () {
        $.get("/ShowProducts/BuyProduct", { ModelId:$(this).val() }, function (partialView) {
                $('body').empty();
                $('body').html(partialView);
                $('body').show(partialView); });    
    });

})