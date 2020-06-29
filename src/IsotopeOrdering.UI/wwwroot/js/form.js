$(document).ready(function () {
    hookupSignatures();
});

function hookupSignatures() {
    $(".signature").each(function () {
        var $that = $(this);
        var signature = $that.parents('.form-group').find('input[name$="Signature"]').val();
        if (signature) {
            $that.append('<img class="img-fluid" src="' + signature + '"></img>')
            $that.jSignature('setData', signature);

        } else {
            $that.jSignature();
            $that.bind('change', function () {
                var signatureData = $that.jSignature('getData');
                $that.parents('.form-group').find('input[name$="Signature"]').val(signatureData)
            });
        }
    })
}
