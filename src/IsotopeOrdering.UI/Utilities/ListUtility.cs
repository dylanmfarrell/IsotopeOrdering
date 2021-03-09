using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace IsotopeOrdering.UI.Utilities {
    public static class ListUtility {
        public static IEnumerable<SelectListItem> GetAddressTypes() {
            yield return AddressType.Billing.ToSelectListItem();
            yield return AddressType.Shipping.ToSelectListItem();
        }

        public static IEnumerable<SelectListItem> GetCustomerStatuses() {
            yield return CustomerStatus.New.ToSelectListItem("Customer cannot place orders but can submit a MTA and update their profile");
            yield return CustomerStatus.Initiated.ToSelectListItem("Customer can place orders and update their profile");
            yield return CustomerStatus.Locked.ToSelectListItem("Customer cannot place orders or update their profile");
        }

        public static IEnumerable<SelectListItem> GetShipmentStatuses() {
            yield return ShipmentStatus.Created.ToSelectListItem();
            yield return ShipmentStatus.Cancelled.ToSelectListItem();
            yield return ShipmentStatus.Shipped.ToSelectListItem();
        }

        public static IEnumerable<SelectListItem> GetShipmentItemStatuses() {
            yield return ShipmentItemStatus.Created.ToSelectListItem();
            yield return ShipmentItemStatus.Shipped.ToSelectListItem(); 
            yield return ShipmentItemStatus.Received.ToSelectListItem();
            yield return ShipmentItemStatus.Damaged.ToSelectListItem();
            yield return ShipmentItemStatus.Cancelled.ToSelectListItem();
        }

        private static SelectListItem ToSelectListItem(this Enum value) {
            return new SelectListItem(value.ToString(), Convert.ToInt32(value).ToString());
        }

        private static SelectListItem ToSelectListItem(this Enum value, string description) {
            return new SelectListItem(value + " - " + description, Convert.ToInt32(value).ToString());
        }
    }
}
