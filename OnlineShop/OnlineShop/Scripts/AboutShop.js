$(document).ready(function () {
    var FirstChild = '#AboutShopContainer > div:first-child > ul > li';
    var LastChild = '#AboutShopContainer > div:last-child';
    $.ajax({
        url: '/AboutShop/ShowSelector',
        type: 'POST',
        data: { showCriteria: 'History' },
        success: function (PartialView) {
            $(LastChild).empty();
            $(LastChild).html(PartialView);
            $(LastChild).show(PartialView);
        },
        error: function () {
            alert("About shop didn't work");
        }
    })
    $(FirstChild).click(function () {
        var text = $(this).closest('li').find('a').text();

        $.ajax({
            url: "/AboutShop/ShowSelector",
            type: "POST",
            data: { showCriteria: text },
            success: function (PartialView) {

                $(LastChild).empty();
                $(LastChild).html(PartialView);
                $(LastChild).show(PartialView);
            },
            error: function () {
                alert("About shop didn't work");
            }
        })
       
      
    })
})
