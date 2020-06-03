using IsotopeOrdering.App.Models.Items;
using System.Collections.Generic;
using System.Linq;

namespace IsotopeOrdering.App.Models.Details {
    public class OrderCenterModel {
        public List<OrderItemModel> Orders { get; set; } = new List<OrderItemModel>();

        public List<OrderItemModel> OrdersReadyToReview => Orders.Where(x => x.ReadyToReview).ToList();
        public int OrdersReadyToReviewCount => Orders.Count(x => x.ReadyToReview);

        public List<OrderItemModel> OrdersReadyToProcess => Orders.Where(x => x.ReadyToProcess).ToList();
        public int OrdersReadyToProcessCount => Orders.Count(x => x.ReadyToProcess);

        public List<OrderItemModel> OrdersAwaitingCustomerApproval => Orders.Where(x => x.AwaitingCustomerApproval).ToList();
        public int OrdersAwaitingCustomerApprovalCount => Orders.Count(x => x.AwaitingCustomerApproval);

        public List<OrderItemModel> OrdersReadyToComplete => Orders.Where(x => x.ReadyToComplete).ToList();
        public int OrdersReadyToCompleteCount => Orders.Count(x => x.ReadyToComplete);

        public List<OrderItemModel> OrdersArchive => Orders.Where(x => x.Complete).ToList();
        public int OrdersArchiveCount => Orders.Count(x => x.Complete);
    }
}
