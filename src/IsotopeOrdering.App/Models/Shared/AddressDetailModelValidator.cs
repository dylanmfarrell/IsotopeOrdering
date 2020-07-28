using FluentValidation;

namespace IsotopeOrdering.App.Models.Shared {
    public class AddressDetailModelValidator : AbstractValidator<AddressDetailModel> {
        public AddressDetailModelValidator() {
            RuleFor(x => x.Name)
                .NotEmpty();
            RuleFor(x => x.State)
                .NotEmpty();
            RuleFor(x => x.City)
                .NotEmpty();
            RuleFor(x => x.Country)
               .NotEmpty();
            RuleFor(x => x.ZipCode)
                .Must(PropertyValidators.BeValidZipCode);
            RuleFor(x => x.Address1)
                .NotEmpty();
        }
    }
}
