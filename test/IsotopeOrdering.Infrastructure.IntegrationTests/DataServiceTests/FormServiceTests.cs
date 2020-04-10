using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Infrastructure.DataServices;
using System;
using System.Text.Json;
using Xunit;

namespace IsotopeOrdering.Infrastructure.IntegrationTests.DataServiceTests {
    public class FormServiceTests {

        [Theory, AutoMoqData]
        public async void Get_Form_From_Type(Form form) {
            form.Type = FormType.Initiation;
            string instanceName = Guid.NewGuid().ToString();
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                context.Forms.Add(form);
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                FormService service = new FormService(context, TestUtilities.GetMapper());
                FormDetailModel model = await service.Get<FormDetailModel>(FormType.Initiation);
                Assert.NotNull(model);
            }
        }

        [Theory, AutoMoqData]
        public async void Get_CustomerForm(CustomerForm form) {
            form.FormId = 1;
            string instanceName = Guid.NewGuid().ToString();
            string json = JsonSerializer.Serialize(new FormInitiationDetailModel());
            form.FormData = json;
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                context.CustomerForms.Add(form);
                await context.SaveChangesAsync();
            }
            using (var context = TestUtilities.GetDbContext(instanceName)) {
                FormService service = new FormService(context, TestUtilities.GetMapper());
                FormDetailModel? model = await service.GetCustomerForm<FormDetailModel>(form.Id);
                Assert.NotNull(model);
            }
        }
    }
}
