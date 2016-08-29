$(document).ready(function () {  
    $('.showAccaunts').click(function () {
        $.get("/Auth/ShowAccaunts", function (PartialView) {
            $('#showProduct').empty();
            $('#showProduct').html(PartialView);
            $('#showProduct').show(PartialView);
        })
    });
  
})