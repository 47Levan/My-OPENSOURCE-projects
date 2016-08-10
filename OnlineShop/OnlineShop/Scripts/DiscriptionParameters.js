$('.AddDescription').click(function () {  
    $.ajax({
        url: '/AddProductsDialog/AddDescriptionPatrameter',
        type:'GET',
        data: $('#AddProdForm').serialize() + "&categoryId=" + $('#Category').val(),
        success: function (product) {
            $('#ProgressShow').empty()
            $('#AddProdForm').replaceWith(product)
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
        success: function (product) {
            $('#ProgressShow').empty()
            $('#AddProdForm').replaceWith(product)
        }
    })
})