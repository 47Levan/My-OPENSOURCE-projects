var SelectCategory = '#AddProductContainer > form > select:first-of-type';
var SelectSubCategory = '#AddProductContainer > form > select:last-of-type';
$(SelectCategory).change(function () {
    $(SelectSubCategory).empty();
    $(SelectSubCategory).append(
        '<option>'
        + "Select sub category" + '</option>'
    );
   
    if ($(SelectCategory +':selected').text() != 'Select category') {
        $.ajax({
            url: '/MainPage/GetSubs',
            type: 'POST',
            data: { category: $(SelectCategory).val() },
            success: function(subs) {
                $(SelectSubCategory).empty();
                $(SelectSubCategory).append(
                    '<option>'
                    + "Select sub category" + '</option>'
                )
                $.each(subs, function(i, sub) {
                    $(SelectSubCategory).append(
                        '<option value="'
                        + sub.Value + '">'
                        + sub.Text + '</option>'
                    )
                })
            },
            error: function() {

                alert("filling subs didn't work");
            }
        });
    }
})