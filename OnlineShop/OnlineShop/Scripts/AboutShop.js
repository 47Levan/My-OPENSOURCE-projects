$(document).ready(function () {
  
    $.ajax({
        url: '/AboutShop/ShowSelector',
        type: 'POST',
        data: { showCriteria: 'History' },
        success: function (PartialView) {
            $('#AboutShopContainer > div:last-child').empty();
            $('#AboutShopContainer > div:last-child').html(PartialView);
            $('#AboutShopContainer > div:last-child').show(PartialView);
        },
        error: function () {
            alert("About shop didn't work");
        }
    })
    $('#AboutShopContainer > div:first-child > ul > li').click(function () {
        var text = $(this).closest('li').find('a').text();

        $.ajax({
            url: "/AboutShop/ShowSelector",
            type: "POST",
            data: { showCriteria: text },
            success: function (PartialView) {

                $('#AboutShopContainer > div:last-child').empty();
                $('#AboutShopContainer > div:last-child').html(PartialView);
                $('#AboutShopContainer > div:last-child').show(PartialView);
            },
            error: function () {
                alert("About shop didn't work");
            }
        })
       
      
    })
})
