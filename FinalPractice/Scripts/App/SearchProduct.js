$(document).ready(function() {
    alert(1);

    $('.search-form').on('submit',
        function() {
            var input = $(this).child('input').val();
            alert(2);

            $.ajax({
                method: 'POST',
                data: { input: input },
                dataType: 'json',
                url: '/Products/Search',
                success: function(response) {
                    alert("success");
                },
                error:function(response) {
                    alert("error");
                }
            });
        });
})