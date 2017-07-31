$(document).ready(function() {
   // alert(1);
    $("button[id$='-wishlist']").on('click',
        function () {

            var productId = $(this).attr('data-id');
            $(".wish-list-bar").css('display', 'block !important');

            var userWishListCount = $('.wish-list-count').text();
            $('.wish-list-count').data(userWishListCount);

            if (userWishListCount == null) {
                userWishListCount = 0;
            }
            userWishListCount++;

            //Start AJAX
            $.ajax({
                method: "POST",
                url: 'WishLists/AddToWishList',
                dataType: 'json',
                //contentType: 'application/json; charset=utf-8',
                data: { productId: productId},
                success: function(response) {
                    alert("success");
                },
                error: function(response) {
                    alert("error");
                }
            });

            //End AJAX

            $('.wish-list-count').text(userWishListCount);
        });
})