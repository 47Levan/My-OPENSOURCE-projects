$(document).ready(function () {
    $("DataOperations").click(function () {
        $.post("/ShowProducts/BuyProduct", new {}, function () {
            alert("ButtonClick")
        })
    })
  
})