$(document).ready(function () {
    renderDatatables();
    hookupModals();
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

function postCollectionAdd(options, model, successCallback,failureCallback) {
    $.post(options.url, { model }, function (data) {
        if (toggleErrorState(options.context, data)) {
            if (typeof successCallback === 'function') {
                failureCallback();
            } else {
                return;
            }
        }
        if (typeof successCallback === 'function') {
            successCallback(data);
        } else {
            $(options.target).append(data);
        }
    });
}
function hookupModals() {
    $('.modal').on('show.bs.modal', function (event) {
        var button = $(event.relatedTarget)
        var title = button.data('title');
        var content = button.data('content');
        var submittext = button.data('submittext');
        var submitvalue = button.data('submitvalue');
        var modal = $(this)
        modal.find('.modal-title').text(title);
        modal.find('.modal-body').text(content);
        var actionBtn = modal.find('button[name="Action"]');
        actionBtn.text(submittext);
        actionBtn.val(submitvalue);
    });
}


function removeCollectionItem(el) {
    var $el = $(el);
    var $parent = $el.parents($el.data('for'));
    $parent.find('[id$="IsDeleted"]').val(true);
    var undoSection = $('<button type="button" class="btn btn-sm btn-warning" name="undoRemove">Undo</button>')
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
    context.find('input,textarea').each(function () {
        if (!$(this).is('[readonly]') && $(this).attr('type') !== 'hidden') {
            if ($(this).attr('type') === 'number') {
                $(this).val(0);
            } else {
                $(this).val('');
            }
        }
    });
    return false;
}

function getGuid() {
    return (S4() + S4() + "-" + S4() + "-4" + S4().substr(0, 3) + "-" + S4() + "-" + S4() + S4() + S4()).toLowerCase();
}

function S4() {
    return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
}
$.fn.extend({
    renderAutoComplete: function (options) {
        var search = {
            context: $(this),
            onSelect: options.onSelect,
        };
        search.execute = function (request, response) {
            $.ajax({
                url: search.context.data('url'),
                dataType: "json",
                data: {
                    search: request.term
                },
                success: function (data) {
                    response(data);
                }
            });
        }
        search.init = function () {
            this.context.autocomplete({
                source: search.execute,
                minLength: 3,
                select: function (event, ui) {
                    search.onSelect(ui.item)
                    return false;
                }
            });
        }
        return search;
    },
    getAddress: function () {
        var $el = $(this);
        var address = {};
        address.Name = $el.find('[name$="Name"]').val();
        address.State = $el.find('[name$="State"]').val();
        address.City = $el.find('[name$="City"]').val();
        address.ZipCode = $el.find('[name$="ZipCode"]').val();
        address.Address1 = $el.find('[name$="Address1"]').val();
        address.Address2 = $el.find('[name$="Address2"]').val();
        address.Address3 = $el.find('[name$="Address3"]').val();
        address.Country = $el.find('[name$="Country"]').val();
        return address;
    },
    setAddress: function (address) {
        var $el = $(this);
        $el.find('[name$="Name"]').val(address.Name);
        $el.find('[name$="State"]').val(address.State);
        $el.find('[name$="City"]').val(address.City);
        $el.find('[name$="ZipCode"]').val(address.ZipCode);
        $el.find('[name$="Address1"]').val(address.Address1);
        $el.find('[name$="Address2"]').val(address.Address2);
        $el.find('[name$="Address3"]').val(address.Address3);
        $el.find('[name$="Country"]').val(address.Country);
    },
    getContact: function () {
        var $el = $(this);
        var contact = {};
        contact.FirstName = $el.find('[name$="FirstName"]').val();
        contact.LastName = $el.find('[name$="LastName"]').val();
        contact.Email = $el.find('[name$="Email"]').val();
        contact.PhoneNumber = $el.find('[name$="PhoneNumber"]').val();
        contact.Fax = $el.find('[name$="Fax"]').val();
        return contact;
    },
    setContact: function (contact) {
        var $el = $(this);
        $el.find('[name$="FirstName"]').val(contact.FirstName);
        $el.find('[name$="LastName"]').val(contact.LastName);
        $el.find('[name$="Email"]').val(contact.Email);
        $el.find('[name$="PhoneNumber"]').val(contact.PhoneNumber);
        $el.find('[name$="Fax"]').val(contact.Fax);
    }
})