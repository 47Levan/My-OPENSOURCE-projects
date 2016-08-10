$(document).ready(function () {
    $('.subMenuItem').click(function () {
        $.ajax({
            url: "/ShowProducts/showProductsByFilter",
            type: "GET",
            data: { category: $(this).closest('li').find('.subMenuItem').html() },
            success: function (partialView) {
                $('#showProduct').empty();
                $('#showProduct').html(partialView);
                $('#showProduct').show(partialView);
            },
            error: function () {
                alert("Show product by filter doesn't work");
            }
        })
    })

})
