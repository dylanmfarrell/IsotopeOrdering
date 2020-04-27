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

function postCollectionAdd(options, model, successCallback) {
    $.post(options.url, { model }, function (data) {
        if (toggleErrorState(options.context, data)) {
            return;
        }
        if (typeof successCallback === 'function') {
            successCallback(data);
        } else {
            $(options.target).append(data);
        }
    });
}

function removeCollectionItem(el) {
    var $el = $(el);
    var $parent = $el.parents($el.data('for'));
    $parent.find('[id$="IsDeleted"]').val(true);
    var undoSection = $('<button type="button" class="btn btn-warning" name="undoRemove">Undo</button>')
    undoSection.click(function () {
        $parent.find('[id$="IsDeleted"]').val(false);
        undoSection.remove();
        $parent.children().each(function () { $(this).show(); })
    });
    $parent.append(undoSection);
    $parent.children().each(function () {
        if ($(this).attr('name') !== 'undoRemove') {
            $(this).hide();
        }
    })
}

function toggleErrorState(context, data) {
    context.find('.alert').remove();
    if (typeof (data.isSuccessful) !== 'undefined' && !data.isSuccessful) {
        context.prepend('<div class="alert alert-danger" role="alert">' + data.message + '</div>');
        return true;
    }
    context.find('input,textarea').val('');
    return false;
}

function getGuid() {
    return (S4() + S4() + "-" + S4() + "-4" + S4().substr(0, 3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();
}

function S4() {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
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