using AutoMapper;
using IsotopeOrdering.App.Models.Details;
using System.Text.Json;

namespace IsotopeOrdering.App.Mappings {
    public class FormInitiationDetailModelToStringFormatter : IValueConverter<FormInitiationDetailModel?, string> {
        public string Convert(FormInitiationDetailModel? sourceMember, ResolutionContext context) {
            if (sourceMember == null) {
                return string.Empty;
            }
            return JsonSerializer.Serialize(sourceMember);
        }
    }

}
