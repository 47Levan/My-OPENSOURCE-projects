$(document).ready(function () {

    $(".owl-carousel.banners").owlCarousel({
        stopOnHover: true,
        autoPlay: 5000,
        singleItem: true,
        slideSpeed: 300,
        paginationSpeed: 400,
        navigation: true,
        navigationText: ["<",
            ">"]
    });
    $(".owl-carousel.products").owlCarousel({
        stopOnHover: true,
        autoPlay: 5000,
        items: 4,
        slideSpeed: 300,
        paginationSpeed: 400,
        navigation: true,
        navigationText: ["<",
            ">"]
    });
});