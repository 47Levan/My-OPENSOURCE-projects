$(".subMenuItem").click(function (event) {
        $.ajax({
            url: "/ShowProducts/startShowProductsByFilter",
            type: "GET",
            data: {
                subCategory: $(this).closest('li').find("button").val(),
            },
            success: function (partialView) {
                $('#showProduct').empty();
                $('#showProduct').html(partialView);
                $('#showProduct').show(partialView);
            },
            error: function () {
                alert("Show product by filter doesn't work");
            }
        })
    })

  

