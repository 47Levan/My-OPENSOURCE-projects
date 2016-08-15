$('#sortList').change(function () {
    var myJsVariable = '@(ViewBag.clickedCategory)';   
    $.ajax({
        url: '/ShowProducts/sortProductsByFilter',
        type:'POST',
        data: { sortChoice: $('#sortList').val(), subCategory: myJsVariable },
        success: function (partialView) {
            $('#showProduct').empty();
            $('#showProduct').html(partialView);
            $('#showProduct').show(partialView);          
        },
        error: function () {
            alert("SortProducts doesn't work");
        }
    })
    //$(this).serialize() + '&sortChoice=' + $('#sortList').val()
})