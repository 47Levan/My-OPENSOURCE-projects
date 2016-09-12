$('#newsContainer > div:first-child > a').closest('a').click(function (e) {
    e.preventDefault();
    $.ajax({
        url: "/AboutShop/ShowNews",
        type: "POST",
        data: { pagelink: $(this).attr('href') },
        success: function (PartialView) {
            $('#AboutShopContainer > div:last-child').empty();
            $('#AboutShopContainer > div:last-child').html(PartialView);
            $('#AboutShopContainer > div:last-child').show(PartialView);
        }
    })
})