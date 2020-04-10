using FluentValidation;
using IsotopeOrdering.App.Models.Shared;
using System.Linq;
namespace IsotopeOrdering.App.Models.Details {
    public class FormDetailModelValidator : AbstractValidator<FormDetailModel> {
        public FormDetailModelValidator() {
            RuleFor(x => x.InitiationModel!).SetValidator(new FormInitiationDetailModelValidator());
        }
    }

    public class FormInitiationDetailModelValidator : AbstractValidator<FormInitiationDetailModel> {
        public FormInitiationDetailModelValidator() {
            RuleFor(x => x.SelectedInstitution).NotNull();
            RuleFor(x => x.SelectedInstitution!.Id).GreaterThan(0);
            RuleFor(x => x.ShippingAddress).SetValidator(new AddressDetailModelValidator());
            RuleFor(x => x.Items).Must(x => x.Any(y => y.IsSelected)).WithMessage(ValidationMessages.NoSelectedItems);
        }
    }
}
