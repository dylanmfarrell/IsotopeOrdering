function addCustomerAddress(el) {
    var options = getCollectionAddOptions(el);
    var model = {};
    model.Address = {};
    model.Type = $('#Addresses_Type').val();
    model.Address.Name = $('#Addresses_Name').val();
    model.Address.State = $('#Addresses_State').val();
    model.Address.City = $('#Addresses_City').val();
    model.Address.ZipCode = $('#Addresses_ZipCode').val();
    model.Address.Address1 = $('#Addresses_Address1').val();
    model.Address.Address2 = $('#Addresses_Address2').val();
    model.Address.Address3 = $('#Addresses_Address3').val();
    postCollectionAdd(options, model);
}
