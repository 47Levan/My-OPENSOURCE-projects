$("#Descriptions").on("click", ".AddDescription", function () {
    $.ajax({
        url: '/AddProductsDialog/AddDescriptionParameter',
        type: 'GET',
        data: $('#AddProdForm').serialize() + "&categoryId=" + $('#Category').val(),
        success: function (PartialView) {
            $('#Descriptions').empty();
            $('#Descriptions').html(PartialView);
            $('#Descriptions').show(PartialView);
        }
    });
});
$("#Descriptions").on("click", ".RemoveDescription", function () {
    $.ajax({
        url: '/AddProductsDialog/RemoveDescriptionParameter',
        context: this,
        type: 'GET',
        data: $('#AddProdForm').serialize() + "&description="
            + $(this).closest("tr").find("td:first-child input").val()
            + "&descriptionParametr="
            + $(this).closest("tr").find('td:nth-child(2) input').val()
            + "&categoryId=" + $('#Category').val(),
        success: function (PartialView) {
            $('#ProgressShow').empty()
            $('#Descriptions').html(PartialView)
            $('#Descriptions').show(PartialView)
        }
    });
});
 
