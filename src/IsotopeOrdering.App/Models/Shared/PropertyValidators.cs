using System.Text.RegularExpressions;

namespace IsotopeOrdering.App.Models.Shared {
    public static class PropertyValidators {
        public static bool BeValidZipCode(string zipCode) {
            if (string.IsNullOrEmpty(zipCode)) {
                return false;
            }
            return Regex.IsMatch(zipCode, @"(^\d{5}$)|(^\d{9}$)|(^\d{5}-\d{4}$)");
        }

        public static bool BeValidPhoneNumber(string phoneNumber) {
            if (string.IsNullOrEmpty(phoneNumber)) {
                return false;
            }
            return Regex.IsMatch(phoneNumber, @"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$");
        }
    }
}
