using FluentValidation;
using System.Text.RegularExpressions;

namespace IsotopeOrdering.App.Models.Shared {
    public class AddressDetailModelValidator : AbstractValidator<AddressDetailModel> {
        public AddressDetailModelValidator() {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.State)
                .MaximumLength(2)
                .MinimumLength(2)
                .NotEmpty();
            RuleFor(x => x.City)
                .NotEmpty();
            RuleFor(x => x.ZipCode)
                .Must(BeValidZipCode);
            RuleFor(x => x.Address1)
                .NotEmpty();
        }

        private bool BeValidZipCode(string zipCode) {
            return Regex.IsMatch(zipCode, @"(^\d{5}$)|(^\d{9}$)|(^\d{5}-\d{4}$)");
        }
    }
}
