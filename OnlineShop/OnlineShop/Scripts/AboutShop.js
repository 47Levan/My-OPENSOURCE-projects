function returnClasses() {
    $('ul').find('.SelectedlistInfoItem').each(function () {
        $(this).removeClass('SelectedlistInfoItem');
        $(this).addClass('listInfoItem');
        $(this).find('.SelectedlistInfoItemHref').each(function () {
            $(this).removeClass('SelectedlistInfoItemHref');
            $(this).addClass('listInfoItemHref');
        })
    });
}
$(document).ready(function () {
    $("li:contains('History')").removeClass('listInfoItem');
    $("li:contains('History')").addClass('SelectedlistInfoItem');
    $("a:contains('History')").removeClass('listInfoItemHref');
    $("a:contains('History')").addClass('SelectedlistInfoItemHref');
    $.ajax({
        url: '/AboutShop/ShowSelector',
        type: 'POST',
        data: { showCriteria: 'History' },
        success: function (PartialView) {
            $('#showShopInfo').empty();
            $('#showShopInfo').html(PartialView);
            $('#showShopInfo').show(PartialView);
        },
        error: function () {
            alert("About shop didn't work");
        }
    })
    returnClasses();
    $('.listInfoItem').click(function () {     
        var text = $(this).closest('.listInfoItem').find('.listInfoItemHref').text();
      
        returnClasses();
        $(this).closest('li').removeClass('listInfoItem');
        $(this).closest('li').addClass('SelectedlistInfoItem');
        $(this).closest('li').find('a').removeClass('listInfoItemHref');
        $(this).closest('li').find('a').addClass('SelectedlistInfoItemHref');
        $.ajax({
            url: "/AboutShop/ShowSelector",
            type: "POST",
            data: { showCriteria: text },
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
