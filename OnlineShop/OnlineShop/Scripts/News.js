var lastChild = '#AboutShopContainer > div:last-child';
$('#newsContainer > li  a').closest('a').click(function (e) {
    e.preventDefault();
    $.ajax({
        url: "/AboutShop/ShowNews",
        type: "POST",
        data: { pagelink: $(this).attr('href') },
        success: function(partialView) {
            $(lastChild).empty();
            $(lastChild).html(partialView);
            $(lastChild).show(partialView);
        }
    });
})