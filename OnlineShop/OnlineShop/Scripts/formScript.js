$('#submitValidation').click(function ()
{ 
    var bar = $('.progress-bar')
    var percent = $('.progress-bar')
    var status = $('#status')
    $('#AddProdForm').ajaxForm({
        beforeSend: function () {
            //status.empty();   
            var percentVal = '0%';
            bar.width(percentVal)
            percent.html(percentVal);
        },
        uploadProgress: function (event, position, total, percentComplete) {
            var percentVal = percentComplete + '%';
            bar.width(percentVal)
            percent.html(percentVal);
        },
        success: function (partialView) {
            var percentVal = '100%';
            bar.width(percentVal)
            percent.html(percentVal);
            $('#AddProdForm').removeData(".validator")
            $('#AddProdForm').removeData("unobtrusiveValidation");
            $.validator.unobtrusive.parse("#AddProdForm");
            $('#showProduct').empty();
            $('#showProduct').html(partialView);
            $('#showProduct').show(partialView);

        },
        complete: function (xhr) {
            //status.html(xhr.responseText);

        }
    })
})
