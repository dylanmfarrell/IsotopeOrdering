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
        context.find('#shipping-information').setAddress(shipping);
        context.find('#billing-information').setAddress(billing);
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
    model.Quantity = options.context.find('[name$="Quantity"]').val();
    model.SpecialInstructions = options.context.find('[name$="SpecialInstructions"]').val();
    model.ItemConfiguration = getItemConfiguration(options.context);
    model.Item = getItem(options.context);
    postCollectionAdd(options, model);
}

function getItemConfiguration(context) {
    var config = {};
    config.Id = context.find('[name$="Id"]').val();
    config.Price = context.find('[name$="Price"]').val();
    config.MinimumAmount = context.find('[name$="MinimumAmount"]').val();
    config.MaximumAmount = context.find('[name$="MaximumAmount"]').val();
    return config;
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
