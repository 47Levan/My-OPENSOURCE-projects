$(document).ready(function () {
    $.ajax({
        url: '/AboutShop/History',
        type:'GET',
        success: function (PartialView) {
            $('#showShopInfo').empty();
            $('#showShopInfo').html(PartialView);
            $('#showShopInfo').show(PartialView);
        },
        error: function () {
            alert("About shop didn't work");
        }
    })
    $('.listInfoItem').click(function () {
      
        var text = $(this).closest('.listInfoItem').find('.listInfoItemHref').text();
        $('ul').find('.SelectedlistInfoItem').each(function () {
          
            $(this).removeClass('SelectedlistInfoItem');
            $(this).addClass('listInfoItem');
            $(this).find('.SelectedlistInfoItemHref').each(function () {
                $(this).removeClass('SelectedlistInfoItemHref');
                $(this).addClass('listInfoItemHref');
            })
        });

        $(this).closest('li').removeClass('listInfoItem');
        $(this).closest('li').addClass('SelectedlistInfoItem');
        $(this).closest('li').find('a').removeClass('listInfoItemHref');
        $(this).closest('li').find('a').addClass('SelectedlistInfoItemHref');
        $.ajax({
            url: "/AboutShop/ShowSelector",
            type: "GET",
            data: {showCriteria:text},
            success: function (PartialView) {

                $('#showShopInfo').empty();
                $('#showShopInfo').html(PartialView);
                $('#showShopInfo').show(PartialView);
            },
            error: function () {
                alert("About shop didn't work");
            }
        })
    })
})
