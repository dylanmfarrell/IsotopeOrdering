$(document).ready(function () {
    renderDatatables();
});

function renderDatatables() {
    $('.table-datatable').DataTable({
        initComplete: function () {
            if ($(this).parents('.table-responsive').hasClass('table-fadein'))
                $(this).parents('.table-responsive').fadeIn(100);
        }
    });
}

function getCollectionAddOptions(el) {
    var $el = $(el);
    var options = {};
    options.url = $el.data('url');
    options.target = $el.data('target');
    options.context = $el.parents('.add-collection-item');
    return options;
}

function postCollectionAdd(options,model) {
    $.post(options.url, { model }, function (data) {
        if (toggleErrorState(options.context, data)) {
            return;
        }
        $(options.target).append(data);
    });
}

function removeCollectionItem(el) {
    var $el = $(el);
    $el.parents($el.data('for')).remove();
}

function toggleErrorState(context, data) {
    context.find('.alert').remove();
    if (typeof (data.isSuccessful) !== 'undefined' && !data.isSuccessful) {
        context.prepend('<div class="alert alert-danger" role="alert">' + data.message + '</div>');
        return true;
    }
    context.find('input').val('');
    return false;
}


$.fn.extend({
    getObject: function () {
        var object = {};
        $(this).find('input,select').each(function () {
            object[$(this).attr('id')] = $(this).val();
        });
        return object;
    }
})