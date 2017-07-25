$(document).ready(function () {
    $('#thumbnail-upload-logo').css('display', 'none');
    document.getElementById('upload-logo').addEventListener('change', function () {
        var preview = document.querySelector('img');
        var file = document.querySelector('input[type=file]').files[0];
        var reader = new FileReader();

        reader.addEventListener("load", function () {
            preview.src = reader.result;
            $('#thumbnail-upload-logo').css('display', 'block');
            $('#upload-logo').val(reader.result.substring(reader.result.indexOf(',') + 1));
        }, false);
        if (file) {
            reader.readAsDataURL(file);
        }
    });
})