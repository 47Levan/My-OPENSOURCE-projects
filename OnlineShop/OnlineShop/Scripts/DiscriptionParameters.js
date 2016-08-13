$('.AddDescription').click(function () {
    $.ajax({
        url: '/AddProductsDialog/AddDescriptionPatrameter',
        type:'GET',
        data: $('#AddProdForm').serialize() + "&categoryId=" + $('#Category').val(),
        success: function (PartialView) {
            $('#ProgressShow').empty()
            $('#Descriptions').html(PartialView)
            $('#Descriptions').show(PartialView)
        }
    })
})

$('.RemoveDescription').click(function () {
    $.ajax({

        url: '/AddProductsDialog/RemoveDescriptionParameter',
        context: this,
        type: 'GET',
        data: $('#AddProdForm').serialize() + "&description="
            + $(this).closest("tr").find('.EnterDescriptionInfoField').val() + "&descriptionParametr="
            + $(this).closest("tr").find('.EnterDescriptionParameterInfoField').val()
            + "&categoryId=" + $('#Category').val(),
        success: function (PartialView) {
            $('#ProgressShow').empty()
            $('#Descriptions').html(PartialView)
            $('#Descriptions').show(PartialView)
        }
    })
})