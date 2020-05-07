using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IsotopeOrdering.UI.Utilities {
    public static class ListUtility {
        public static IEnumerable<SelectListItem> GetAddressTypes() {
            yield return new SelectListItem(AddressType.Billing.ToString(), ((int)AddressType.Billing).ToString());
            yield return new SelectListItem(AddressType.Shipping.ToString(), ((int)AddressType.Shipping).ToString());
        }

        public static IEnumerable<SelectListItem> GetCustomerStatuses() {
            yield return new SelectListItem($"{CustomerStatus.New} - Customer cannot place orders but can submit a MTA and update their profile", ((int)CustomerStatus.New).ToString());
            yield return new SelectListItem($"{CustomerStatus.Initiated} - Customer can place orders and update their profile", ((int)CustomerStatus.Initiated).ToString());
            yield return new SelectListItem($"{CustomerStatus.Locked} - Customer cannot place orders or update their profile", ((int)CustomerStatus.Locked).ToString());
        }
    }
}
