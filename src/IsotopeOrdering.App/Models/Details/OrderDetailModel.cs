using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System.Collections.Generic;

namespace IsotopeOrdering.App.Models.Details {
    public class OrderDetailModel : ModelBase {
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();
        public InstitutionItemModel Institution { get; set; } = new InstitutionItemModel();
        public List<OrderItemDetailModel> Items { get; set; } = new List<OrderItemDetailModel>();
        public List<OrderAddressDetailModel> ShippingAddresses { get; set; } = new List<OrderAddressDetailModel>();
        public List<OrderAddressDetailModel> BillingAddresses { get; set; } = new List<OrderAddressDetailModel>();

        public List<OrderItemDetailModel> Cart { get; set; } = new List<OrderItemDetailModel>();
        public AddressDetailModel ShippingAddress { get; set; } = new AddressDetailModel();
        public AddressDetailModel BillingAddress { get; set; } = new AddressDetailModel();
        public string Notes { get; set; } = string.Empty;
        public string FedExNumber { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }
    }

    public class OrderItemDetailModel : ModelBase {
        public ItemDetailModel Item { get; set; } = new ItemDetailModel();
        public List<ItemConfigurationDetailModel> ItemConfigurations { get; set; } = new List<ItemConfigurationDetailModel>();
        public int ItemConfigurationId { get; set; }
        public decimal Quantity { get; set; }
        public string? SpecialInstructions { get; set; } = string.Empty;
    }

    public class OrderAddressDetailModel {
        public AddressType Type { get; set; }
        public AddressDetailModel Address { get; set; } = new AddressDetailModel();
    }
}
