using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
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
        /// Validates the order form. If valid, the order will be saved and reviewers will be notified. 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ApplicationResult> Create(OrderDetailModel model);
        Task<OrderItemModel> GetList();
        Task<OrderItemModel> GetCenterList();
        Task<OrderDetailModel?> Get(int id);
        Task<OrderDetailModel?> GetOrderForReview(int id);
        Task<ApplicationResult> SubmitReview(OrderReviewDetailModel review);
        Task<ApplicationResult> Edit(OrderDetailModel model);

    }
}
