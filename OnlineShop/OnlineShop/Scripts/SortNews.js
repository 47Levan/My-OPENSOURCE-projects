$(document).ready(function ()
{
    $('#sortNews').change(function () {
     
        $.post('/AboutShop/SortNews', { sortParameters: $('#sortNews').val() }, function (PartialView) {       
            $('#NewsContainer').empty();
            $('#NewsContainer').html(PartialView);
            $('#NewsContainer').show(PartialView);
        })
    })
})