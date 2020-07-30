using IsotopeOrdering.App.Models.Details;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IsotopeOrdering.App.Interfaces {
    public interface IShipmentManager {
        Task<List<ShipmentItemModel>> GetListForCurrentCustomer();
        Task<ShipmentDetailModel?> Get(int id);
        Task<ApplicationResult> Create(ShipmentDetailModel model);
        Task<ApplicationResult> Edit(ShipmentDetailModel model);
        Task<ShipmentCenterModel> GetCenter();
        Task<List<ShipmentDetailModel>> GetShipmentsForOrder(int id);
    }

}
