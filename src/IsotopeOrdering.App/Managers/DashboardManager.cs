using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Dashboard;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Security;
using IsotopeOrdering.Domain.Enums;
using IsotopeOrdering.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Managers {
    public class DashboardManager : IDashboardManager {
        private readonly IIsotopeOrderingAuthorizationService _authorization; 
        private readonly IFormService _formService;
        private readonly IOrderService _orderService;
        private readonly IShipmentService _shipmentService;

        public DashboardManager(IIsotopeOrderingAuthorizationService authorization,
            IFormService formService,
            IOrderService orderService,
            IShipmentService shipmentService) {
            _authorization = authorization;
            _formService = formService;
            _orderService = orderService;
            _shipmentService = shipmentService;
        }

        public async Task<PendingTaskListModel> GetPendingTasks() {
            bool isReviewer = await _authorization.AuthorizeAsync(Policies.ReviewerPolicy);
            PendingTaskListModel model = new PendingTaskListModel();
            if (isReviewer) {

                List<FormItemModel> forms = await _formService.GetCustomerForms<FormItemModel>(CustomerFormStatus.AwaitingAdminApproval);
                forms.ForEach(x => {
                    model.AddTask(x.CustomerDetailFormId, PendingTaskType.FormAdminApproval, $"{x.CustomerName} has a pending MTA form awaiting admin approval");
                });

                List<OrderItemModel> orders = await _orderService.GetList<OrderItemModel>(OrderStatus.Sent);
                orders.ForEach(x => {
                    model.AddTask(x.Id, PendingTaskType.OrderAdminApproval, $"{x.Customer.Contact.FirstName} {x.Customer.Contact.LastName} has a pending order awaiting admin approval");
                });

                List<ShipmentItemModel> shipments = await _shipmentService.GetList<ShipmentItemModel>(ShipmentStatus.Created);
                shipments.ForEach(x => {
                    model.AddTask(x.Id, PendingTaskType.ShippingAdminApproval, $"{x.Customer.Contact.FirstName} {x.Customer.Contact.LastName} has a pending shipment awaiting processing");
                });
            }

            List<OrderItemModel> ordersAwaitingCustomerApproval = await _orderService.GetList<OrderItemModel>(OrderStatus.AwaitingCustomerApproval);
            ordersAwaitingCustomerApproval.ForEach(x => {
                model.AddTask(x.Id, PendingTaskType.OrderCustomerApproval, $"Order {x.Id} has been amended and is awaiting your approval");
            });
            return model;
        }
    }
}
