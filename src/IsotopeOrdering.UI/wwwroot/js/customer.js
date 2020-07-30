function addCustomerDocument(el) {
    var options = getCollectionAddOptions(el);
    var model = {};
    var expirationDate = $('#Documents_ExpirationDate').val();
    model.ExpirationDate = expirationDate ?? null;
    model.Document = getDocument('Documents');
    postCollectionAdd(options, model, function (data) {
        onAddCustomerDocument(data, options)
    });
}

function onAddCustomerDocument(data, options) {
    var entityId = $(data).find('.document-upload').data('entityid');
    var newEntityId = getGuid();
    options.context.find('.document-upload').renderFileUpload().reset(newEntityId);
    options.context.find('.document-upload').attr('data-entityid', newEntityId)
    $('#Documents_UploadId').val(newEntityId);

    $(options.target).append(data);
    $(options.target).find('[data-entityid="' + entityId + '"]').renderFileUpload().init();
}

function addCustomerItem(el) {
    var options = getCollectionAddOptions(el);
    var model = getItem('ItemConfigurations');
    postCollectionAdd(options, model);
}

function addCustomerAddress(el) {
    var options = getCollectionAddOptions(el);
    var model = {};
    model.Type = $('#Addresses_Type').val();
    model.Address = getAddress('Addresses');
    postCollectionAdd(options, model);
}

function addCustomerInstitution(el) {
    var options = getCollectionAddOptions(el);
    var model = {};
    model.Institution = {};
    model.Institution.Name = $('#Institutions_Name').val();
    model.Institution.Address = getAddress('Institutions_Address');
    model.Institution.SafetyContact = getContact('Institutions_SafetyContact');
    model.Institution.FinancialContact = getContact('Institutions_FinancialContact');
    postCollectionAdd(options, model);
}

function getContact(prefix) {
    var contact = {}
    contact.FirstName = $('#' + prefix + '_FirstName').val();
    contact.LastName = $('#' + prefix + '_LastName').val();
    contact.Email = $('#' + prefix + '_Email').val();
    contact.PhoneNumber = $('#' + prefix + '_PhoneNumber').val();
    contact.Fax = $('#' + prefix + '_Fax').val();
    return contact;
}

function getAddress(prefix) {
    var address = {};
    address.Name = $('#' + prefix + '_Name').val();
    address.State = $('#' + prefix + '_State').val();
    address.City = $('#' + prefix + '_City').val();
    address.ZipCode = $('#' + prefix + '_ZipCode').val();
    address.Address1 = $('#' + prefix + '_Address1').val();
    address.Address2 = $('#' + prefix + '_Address2').val();
    address.Address3 = $('#' + prefix + '_Address3').val();
    return address;
}

function getDocument(prefix) {
    var document = {};
    document.UploadId = $('#' + prefix + '_UploadId').val();
    document.Name = $('#' + prefix + '_Name').val();
    document.Details = $('#' + prefix + '_Details').val();
    return document;
}

function getItem(prefix) {
    var item = {};
    item.ItemId = $('#' + prefix + '_ItemId').val();
    item.ItemName = $('#' + prefix + '_ItemId').find('option[value="' + item.ItemId + '"]').text();
    item.CustomerId = $('#' + prefix + '_CustomerId').val();
    item.Price = $('#' + prefix + '_Price').val();
    item.MinimumAmount = $('#' + prefix + '_MinimumAmount').val();
    item.MaximumAmount = $('#' + prefix + '_MaximumAmount').val();
    return item;
}