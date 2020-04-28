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
            yield return new SelectListItem(CustomerStatus.New.ToString(), ((int)CustomerStatus.New).ToString());
            yield return new SelectListItem(CustomerStatus.Initiated.ToString(), ((int)CustomerStatus.Initiated).ToString());
            yield return new SelectListItem(CustomerStatus.Locked.ToString(), ((int)CustomerStatus.Locked).ToString());
        }
    }
}
