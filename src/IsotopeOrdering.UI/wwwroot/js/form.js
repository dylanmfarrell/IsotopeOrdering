$(document).ready(function () {
    hookupSignatures();
});

function hookupSignatures() {
    $(".signature").each(function () {

        $(this).jSignature();
        $(this).bind('change', function () {

        })
    })
}
