
$(document).ready(function () {



    $(document).on("click", ".add-fav", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");


        fetch('https://localhost:44386/product/addtofav/' + id)
            .then(response => response.text())
            .then(data => {


                $("#ltn__utilize-cart-menu").html(data)
                var count = $("#favorite").data("favorite-count")
                $("#favorite-count").text(count)
            });
    });

    $(document).on("click", ".delete", function (e) {
        e.preventDefault();

        var id = $(this).attr("data-id");

        fetch('https://localhost:44386/product/deletefromfav/' + id)
            .then(response => response.text())
            .then(data => {

                $("#ltn__utilize-cart-menu").html(data)
                var count = $("#favorite").data("favorite-count")
                $("#favorite-count").text(count)
            });
    })

   

   
})