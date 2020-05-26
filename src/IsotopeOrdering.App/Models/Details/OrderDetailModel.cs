using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using MIR.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace IsotopeOrdering.App.Models.Details {
    public class OrderDetailModel : ModelBase {
        public OrderDetailModel() {
            CanEdit = Status == OrderStatus.Sent || Status == OrderStatus.Draft;
        }
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();
        public InstitutionItemModel Institution { get; set; } = new InstitutionItemModel();
        [DisplayName("Select Materials")]
        public List<OrderItemDetailModel> Items { get; set; } = new List<OrderItemDetailModel>();
        public List<OrderAddressDetailModel> ShippingAddresses { get; set; } = new List<OrderAddressDetailModel>();
        public List<OrderAddressDetailModel> BillingAddresses { get; set; } = new List<OrderAddressDetailModel>();
        public ContactDetailModel BillingContact { get; set; } = new ContactDetailModel();

        public List<OrderItemDetailModel> Cart { get; set; } = new List<OrderItemDetailModel>();
        public AddressDetailModel ShippingAddress { get; set; } = new AddressDetailModel();
        public AddressDetailModel BillingAddress { get; set; } = new AddressDetailModel();
        public string? Notes { get; set; } = string.Empty;
        public string? FedExNumber { get; set; } = string.Empty;
        public OrderStatus Status { get; set; }


        public bool CanEdit { get; set; }
        public OrderStatus SubmitAction { get; set; }
    }

    public class OrderItemDetailModel : ModelBase {
        public ItemDetailModel Item { get; set; } = new ItemDetailModel();
        public List<ItemConfigurationDetailModel> ItemConfigurations { get; set; } = new List<ItemConfigurationDetailModel>();
        public ItemConfigurationDetailModel ItemConfiguration { get; set; } = new ItemConfigurationDetailModel();
        public int ItemConfigurationId { get; set; }
        [DisplayName("Quantity (mCi)")]
        public decimal Quantity { get; set; }
        public string? SpecialInstructions { get; set; } = string.Empty;
        [DisplayName("Price")]
        public decimal Price => Quantity * ItemConfiguration.Price;
        public int CustomerId { get; set; }
        public DateTime? RequestedDate { get; set; }
    }

    public class OrderAddressDetailModel {
        public AddressType Type { get; set; }
        public AddressDetailModel Address { get; set; } = new AddressDetailModel();
    }
}
