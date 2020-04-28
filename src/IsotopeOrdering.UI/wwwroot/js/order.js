function onSelectCustomer(el) {
    var form = $('#selectCustomer');
    var action = form.attr('action');
    form.attr('action', action + '/' + $(el).val());
    form.submit();
}