using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IShipmentManager {
        Task<List<ShipmentItemModel>> GetList();
        Task<ShipmentDetailModel?> Get(int id);
        /// <summary>
        /// Gets the order form for a single order applying all items to the shipment
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<ShipmentDetailModel?> GetShipmentFormForOrder(int orderId);
        /// <summary>
        /// Gets the order form for order items
        /// </summary>
        /// <param name="orderItemIds"></param>
        /// <returns></returns>
        Task<ShipmentDetailModel> GetShipmentFormForItems(int[] orderItemIds);
        Task<ApplicationResult> Create(ShipmentDetailModel model);
        Task<ApplicationResult> Edit(ShipmentDetailModel model);
        Task<List<ShipmentItemModel>> GetCenterList();

    }

}
