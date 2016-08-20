$('.NewsRef').closest('a').click(function (e) {
    e.preventDefault();
    $.ajax({
        url: "/AboutShop/ShowNews",
        type: "POST",
        data: { pagelink: $(this).attr('href') },
        success: function (PartialView) {
            $('#showShopInfo').empty();
            $('#showShopInfo').html(PartialView);
            $('#showShopInfo').show(PartialView);
        }
    })
})