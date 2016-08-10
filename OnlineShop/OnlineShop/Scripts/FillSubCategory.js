$('#Category').change(function () {
    $('#subCategory').empty();
    $('#subCategory').append(
                    '<option>'
                       + "Select sub category" + '</option>'
                      )
   
    if ($('#Category :selected').text() != 'Select category') {
        $.ajax({         
            url: '/MainPage/GetSubs',
            type: 'POST',
            data: {category: $('#Category').val()},
            success: function (subs) {
                $('#subCategory').empty();
                $('#subCategory').append(
                  '<option>'
                     + "Select sub category" + '</option>'
                    )
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