$('.AddDescription').click(function () {
    $.ajax({
        url: '/AddProductsDialog/AddDescriptionPatrameter',
        type:'GET',
        data: $('#AddProdForm').serialize(),
        success: function (product) {
            $('#ProgressShow').empty()
            $('#AddProdForm').replaceWith(product)
        }
    })
})
$('.RemoveDescription').click(function () {
    $.ajax({
        url: '/AddProductsDialog/RemoveDescriptionPatrameter',
        type: 'GET',
        data: $('#AddProdForm').serialize() + "&description="
            + $('#DescriptionField').val() + "&descriptionParametr="
            + $('#DescriptionParamField').val(),
        success: function (product) {
            $('#ProgressShow').empty()
            $('#AddProdForm').replaceWith(product)
        }
    })
})