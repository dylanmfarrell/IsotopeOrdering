using FluentValidation;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using System.Linq;

namespace IsotopeOrdering.App.Models.Details {
    public class CustomerDetailModelValidator : AbstractValidator<CustomerDetailModel> {
        public CustomerDetailModelValidator() {
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Contact.FirstName).NotEmpty();
            RuleFor(x => x.Contact.LastName).NotEmpty();
            RuleFor(x => x.Contact.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Addresses)
                .Must(x => x.Any(x => x.Type == AddressType.Shipping && !x.IsDeleted))
                .WithMessage(ValidationMessages.NoShippingAddress)
                .Must(x => x.Any(x => x.Type == AddressType.Billing && !x.IsDeleted))
                .WithMessage(ValidationMessages.NoBillingAddress);
            RuleForEach(x => x.Addresses).SetValidator(new CustomerAddressDetailModelValidator());
        }

        public class CustomerAddressDetailModelValidator : AbstractValidator<CustomerAddressDetailModel> {
            public CustomerAddressDetailModelValidator() {
                RuleFor(x => x.Address).SetValidator(new AddressDetailModelValidator());
            }
        }
    }
}
