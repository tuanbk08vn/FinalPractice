$(document).ready(function () {
    alert(0);
    $(".btn-delete").on('click', function() {
        alert(1);
        var id = $(this).attr('id');

        $.ajax({
            method:'POST',
            dataType: 'json',
            url: "/Products/Delete",
            data: { id: id },
            success: function(response) {
                alert("success");
                $(this).parent('tr').remove();
            }

        });

    });
});