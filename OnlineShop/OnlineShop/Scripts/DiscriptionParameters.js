$('#DescriptionContainer > table:first-child tr td:nth-child(3) input').click(function() {
    $.ajax({
        url: '/AddProductsDialog/AddDescriptionPatrameter',
        type: 'GET',
        data: $('#AddProdForm').serialize() + "&categoryId=" + $('#Category').val(),
        success: function(PartialView) {
            $('#ProgressShow').empty();
            $('#Descriptions').html(PartialView);
            $('#Descriptions').show(PartialView);
        }
    });
});

$('#DescriptionContainer > table:first-child tr td:last-child input').click(function () {
    $.ajax({

        url: '/AddProductsDialog/RemoveDescriptionParameter',
        context: this,
        type: 'GET',
        data: $('#AddProdForm').serialize() + "&description="
            + $(this).closest("tr")
            .find('#DescriptionContainer > table:first-child tr td:first-child ').val() + "&descriptionParametr="
            + $(this).closest("tr").find('#DescriptionContainer > table:first-child tr td:nth-child(2)').val()
            + "&categoryId=" + $('#Category').val(),
        success: function (PartialView) {
            $('#ProgressShow').empty()
            $('#Descriptions').html(PartialView)
            $('#Descriptions').show(PartialView)
        }
    })
})