$('#customer-autocomplete').renderAutoComplete({
    onSelect: onSelectCustomer
}).init();

function onSelectCustomer(item) {
    var form = $('#selectCustomer');
    var action = form.attr('action');
    form.attr('action', action + '/' + item.value);
    form.submit();
}

function addCartItem(el) {
    var options = getCollectionAddOptions(el);
    var model = {};
    model.Quantity = $('#Items_Quantity').val();
    model.SpecialInstructions = $('#Items_SpecialInstructions').val();
    model.ItemConfiguration = getItemConfiguration(options.context, 'Items_ItemConfiguration');
    model.Item = getItem(options.context, 'Items_Item');
    postCollectionAdd(options, model);
}

function getItemConfiguration(context, prefix) {
    var config = {};
    config.Id = context.find('#' + prefix + '_Id').val();
    config.Price = context.find('#' + prefix + '_Price').val();
    config.MinimumAmount = context.find('#' + prefix + '_MinimumAmount').val();
    config.MaximumAmount = context.find('#' + prefix + '_MaximumAmount').val();
    return config;
}

function getItem(context, prefix) {
    var item = {};
    item.Id = context.find('#' + prefix + '_Id').val();
    item.Name = context.find('#' + prefix + '_Name').val();
    item.Description = context.find('#' + prefix + '_Description').val();
    item.Target = context.find('#' + prefix + '_Target').val();
    item.Reaction = context.find('#' + prefix + '_Reaction').val();
    item.FinalComposition = context.find('#' + prefix + '_FinalComposition').val();
    item.SpecificActivity = context.find('#' + prefix + '_SpecificActivity').val();
    return item;
}