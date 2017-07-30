$(document).ready(function () {
    $(".btn-delete").on('click', function() {
        var removeProduct = $(this).parents('tr');
        $.ajax({
            method: 'POST',
            //url: '@Url.Action("Delete","Product", Request.Url.Scheme))',
            url: 'Products/Delete',
            dataType: 'json',
            data: { id: $(this).attr('id') },
            success: function (response) {
                alert("success");
                removeProduct.remove();
            },
            error: function(response) {
                alert("Not Success");
            }

        });

    });
});