//$(document).ready(function () {
//    $("#newsContainer a").on("click", function () {
//        event.preventDefault();
//        var pageUrl = $(this).attr("href");
//        pageUrl = "/Home/GetNews?pageLink=" + $(this).attr("href");
//        $.get("/Home/GetNews", { pageLink: $(this).attr("href") }, function (partialView) {
//            $(document).empty();
//            $(document).html(partialView);
//            $(document).show(partialView);
//        });
//        window.history.pushState({ path: pageUrl }, "", pageUrl);
//    });
//});