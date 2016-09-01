$(document).ready(function () {
    $(".BuyOperations").click(function () {
        alert("ButtonClick")
        $.post("/ShowProducts/BuyProduct", new {}, function () {
            alert("ButtonClick")
        })
    })
  
})