$(document).ready(function () {
    $('#Category').change(function () {
        $('#subCategory').empty();
        $('#subCategory').append(
                        '<option>'
                           + "Select sub category" + '</option>'
                          )
        if ($('#Category :selected').text() != 'Select category') {        
            $.ajax({
                type: 'POST',
                url: '/Home/GetSubs',
                data: { category: $("#Category").val() },
                success: function (subs) {
                    $.each(subs, function (i, sub) {
                        $('#subCategory').append(
                          '<option value="'
                             + sub.Value + '">'
                             + sub.Text + '</option>'
                            )
                    })
                },
                error: function () {
                    alert("filling subs didn't work");
                }
            })
        }
    })
})