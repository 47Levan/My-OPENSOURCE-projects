$(document).ready(function ()
{
    $('#sortNews').change(function () {
        //$.ajax({
        //    url: '/AboutShop/SortNews',
        //    type:'POST',
        //    data: { sortParameters: $('#sortNews').val() },
        //    success: function (partialView) {
        //        $('#newsContainer').empty();
        //        $('#newsContainer').html(partialView);
        //        $('#newsContainer').show(partialView);
        //    }
        //})
       
        $.post('/AboutShop/SortNews', { sortParameters: $('#sortNews').val() }, function (PartialView) {       
            $('#NewsContainer').empty();
            $('#NewsContainer').html(PartialView);
            $('#NewsContainer').show(PartialView);
        })
    })
})