$(document).ready(function() {
    var warmFloorSlider = $("#warmFloorSlider").slider({
        range: true,
        min: 0,
        max: 12402,
        orientation: "horizontal",
        values: [0, 12402],
        slide: function(event, ui) {
            $("#minPrice").val(ui.values[0]);
            $("#maxPrice").val(ui.values[1]);
            //fireFormChange();
        }
    });
    $(document).on("input", "#minPrice", function () {
        warmFloorSlider.slider("values", "0", $("#minPrice").val());
        //fireFormChange();
    });
    $(document).on("input", "#maxPrice", function () {
        warmFloorSlider.slider("values", "1", $("#maxPrice").val());
        //fireFormChange();
    });
    $("#WarmFilterForm input").change(function () {
        alert("WarmFilterForm works");
        fireFormChange();
    });
    function fireFormChange() {
        $.post("/Categories/UpdateWarmFloor"
           , { minPrice: $("#minPrice").val(), maxPrice: $("#maxPrice").val() }
           , function (partialView) {
               $("#ProductContainer").empty();
               $("#ProductContainer").html(partialView);
               $("#ProductContainer").show(partialView);
           });
    }
});

