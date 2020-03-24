using IsotopeOrdering.Domain.Entities;
using IsotopeOrdering.Domain.Interfaces;
using MIR.Core.Data;

namespace IsotopeOrdering.Infrastructure.DataServices {
    public class ShipmentService : ServiceBase<IsotopeOrderingDbContext, Shipment>, IShipmentService {
        public ShipmentService(IsotopeOrderingDbContext context) : base(context) {
        }
    }
}
