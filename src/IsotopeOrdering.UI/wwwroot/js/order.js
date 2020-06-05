$(document).ready(function () {
    hookupAutocomplete();
    hookupTabs();
});

function moveTab(target) {
    $(target).tab('show');
}

function hookupAutocomplete() {
    $('#customer-autocomplete').renderAutoComplete({
        onSelect: onSelectCustomer
    }).init();
}

function hookupTabs() {
    $('#review-tab').on('shown.bs.tab', function (e) {
        var context = $($(e.target).attr('href'));
        var shipping = $('#shipping-content .add-collection-item').getAddress();
        var billing = $('#billing-content .add-collection-item').getAddress();
        var billingContact = $('#billing-content-contact').getContact();
        context.find('#shipping-information').setAddress(shipping);
        context.find('#billing-information').setAddress(billing);
        context.find('#billing-contact').setContact(billingContact);
        context.find('#Notes').val($('#order-notes').val());
    })
}

function onSelectCustomer(item) {
    var form = $('#selectCustomer');
    var action = form.attr('action');
    form.attr('action', action + '/' + item.value);
    form.submit();
}

function onFedexNumberChanged(el) {
    $('#FedExNumber').val($(el).val());
}

function onAddressSelect(el) {
    var address = $(el).getAddress();
    var target = $(el).parent().find('.add-collection-item');
    target.setAddress(address);
}

function addCartItem(el) {
    var options = getCollectionAddOptions(el);
    var model = {};
    $(el).popover('dispose');
    model.RequestedDate = options.context.find('[name$="RequestedDate"]').val();
    model.Quantity = options.context.find('[name$="Quantity"]').val();
    model.SpecialInstructions = options.context.find('[name$="SpecialInstructions"]').val();
    model.Item = getItem(options.context);
    model.CustomerId = $('#Customer_Id').val();
    postCollectionAdd(options, model, function (data) {
        $(options.target).append(data);
        $(el).popover({
            content: 'Item added!',
            placement: 'right',
            trigger: 'focus'
        });
        $(el).popover('show');

    });
}

function onQuantityChange(el) {
    var context = $(el).parents('.add-collection-item');
    var price = context.find('[name$="ItemConfiguration.Price"]').val();
    var quantity = $(el).val();
    context.find('[name="ItemPrice"]').val(price * quantity);
}

function getItem(context) {
    var item = {};
    item.Id = context.find('[name$="Id"]').val();
    item.Name = context.find('[name$="Name"]').val();
    item.Description = context.find('[name$="Description"]').val();
    item.Target = context.find('[name$="Target"]').val();
    item.Reaction = context.find('[name$="Reaction"]').val();
    item.FinalComposition = context.find('[name$="FinalComposition"]').val();
    item.SpecificActivity = context.find('[name$="SpecificActivity"]').val();
    return item;
}
