$(document).ready(function () {
    hookupSignatures();
});

function hookupSignatures() {
    $(".signature").each(function () {
        var $that = $(this);
        $that.jSignature();
        $that.bind('change', function () {
            var signatureData = $that.jSignature('getData');
            $that.parents('.form-group').find('input[name$="Signature"]').val(signatureData)
        })
    })
}
