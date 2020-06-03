using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IOrderManager {
        /// <summary>
        /// Gets the order form for customer with preferred shipping and billing addresses prepopulated and a list of items the customer is able to order.
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        Task<OrderDetailModel> GetOrderForm(CustomerItemModel customer);
        /// <summary>
        /// Gets the order form for customer with preferred shipping and billing addresses prepopulated and a list of items the customer is able to order. Sets selected properties for the order.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<OrderDetailModel> GetOrderForm(OrderDetailModel order);
        /// <summary>
        /// Gets the order form for an existing order. Returns null if the order is not found or the user does not have access to edit the order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<OrderDetailModel?> GetOrderForm(int orderId);
        /// <summary>
        /// Validates the order form. If valid, the order will be saved and reviewers will be notified. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ApplicationResult> Create(OrderDetailModel model);
        Task<List<OrderItemModel>> GetListForCurrentCustomer();
        Task<OrderCenterModel> GetCenter();
        Task<OrderDetailModel?> Get(int id);
        Task<OrderItemModel?> GetItem(int id);
        Task<OrderReviewDetailModel?> GetOrderForReview(int id);
        Task<ApplicationResult> SubmitReview(OrderReviewDetailModel review);
        Task<OrderProcessDetailModel?> GetOrderForProcessing(int id);
        Task<ApplicationResult> SubmitProcessing(OrderReviewDetailModel review);
        Task<OrderCompleteDetailModel?> GetOrderForCompletion(int id);
        Task<ApplicationResult> SubmitCompletion(OrderReviewDetailModel review);
        Task<ApplicationResult> Edit(OrderDetailModel model);
        Task<OrderReviewDetailModel?> GetReviewAmendment(int id);
        Task<ApplicationResult> SubmitAmendmentReview(OrderReviewDetailModel review);
    }
}
