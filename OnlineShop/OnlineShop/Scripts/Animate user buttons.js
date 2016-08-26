$(document).ready(function () {
    $('#profileAdjust > ul > li').mouseenter(function () {
      
        $(this).animate(function () {
            width:'+=10px'
        })
    })
    $('#profileAdjust > ul > li').mouseleave(function () {
       
        $(this).animate(function () {
            width: '-=10px'
        })
    })
})