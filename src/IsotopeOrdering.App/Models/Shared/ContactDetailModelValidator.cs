using FluentValidation;

namespace IsotopeOrdering.App.Models.Shared {
    public class ContactDetailModelValidator : AbstractValidator<ContactDetailModel> {
        public ContactDetailModelValidator() {
            RuleFor(x => x.FirstName)
                .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Must(PropertyValidators.BeValidPhoneNumber);
        }
    }
}
