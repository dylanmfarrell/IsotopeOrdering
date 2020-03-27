using FluentValidation;
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
                .WithMessage("Must have at least one shipping address")
                .Must(x => x.Any(x => x.Type == AddressType.Billing && !x.IsDeleted))
                .WithMessage("Must have at least one billing address");
        }
    }
}
