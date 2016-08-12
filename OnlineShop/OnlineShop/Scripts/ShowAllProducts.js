$(document).ready(function () {
  
    $.ajax({
        url: '/ShowProducts/showAllProducts',
        data: { pageNumber: 1, orderType:$('sortList').val() },
        type:'GET',
        success: function (partialView) {
            $('#showProduct').html(partialView);
            $('#showProduct').show(partialView);
        },
        error:function(){
            alert('ShowAllProducts didnt work');
        }
    })
});