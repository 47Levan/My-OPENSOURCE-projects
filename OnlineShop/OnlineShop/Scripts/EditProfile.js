$(document).ready(function() {
    $('.editProfile').click(function() {
        event.preventDefault();
        var id = $(this).attr("href");
        $.post("/Auth/EditProfile", { userId: id },
            function(partialView) {
                $('#showProduct').empty();
                $('#showProduct').html(partialView);
                $('#showProduct').show(partialView);
            });
    });
});
