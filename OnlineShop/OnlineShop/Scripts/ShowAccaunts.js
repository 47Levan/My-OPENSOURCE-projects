$(document).ready(function () {
    $('#showProduct').on("click", ".showAccaunts", function () {
        $.get("/Auth/ShowAccaunts", function(partialView) {
            $('#showProduct').empty();
            $('#showProduct').html(partialView);
            $('#showProduct').show(partialView);
        });
    });
});
//#userContainer > div:last-child > ul > li:last-child > a