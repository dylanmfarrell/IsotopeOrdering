$(document).ready(function () {
    renderUploaders();
});

function renderUploaders() {
    var uploaders = $('.document-upload');
    uploaders.each(function () {
        $(this).renderFileUpload().init();
    });
}