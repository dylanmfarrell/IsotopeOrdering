using FluentValidation;
using IsotopeOrdering.App.Models.Shared;

namespace IsotopeOrdering.App.Models.Details {
    public class InstitutionDetailModelValidator : AbstractValidator<InstitutionDetailModel> {
        public InstitutionDetailModelValidator() {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Address).SetValidator(new AddressDetailModelValidator());
            RuleFor(x => x.SafetyContact).SetValidator(new ContactDetailModelValidator());
            RuleFor(x => x.FinancialContact).SetValidator(new ContactDetailModelValidator());
        }
    }
}
