var lastChild = '#AboutShopContainer > div:last-child';
$('#newsContainer > div:first-child > a').closest('a').click(function (e) {
    e.preventDefault();
    $.ajax({
        url: "/AboutShop/ShowNews",
        type: "POST",
        data: { pagelink: $(this).attr('href') },
        success: function (PartialView) {
            $(lastChild).empty();
            $(lastChild).html(PartialView);
            $(lastChild).show(PartialView);
        }
    })
})