$(document).ready(function () {
    $('.subMenuItem').mouseenter(function () {
        $(this).animate({
            width: '+=10px'
        })

    })
    $('.subMenuItem').mouseleave(function () {
        $(this).animate({
            width: '-=10px'
        })
    })
})