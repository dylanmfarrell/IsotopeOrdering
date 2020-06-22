using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Items;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {
    public class HomeController : BaseController {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerManager _customerManager;
        private readonly IFormManager _formManager;

        public HomeController(ILogger<HomeController> logger, ICustomerManager customerManager, IFormManager formManager) {
            _logger = logger;
            _customerManager = customerManager;
            _formManager = formManager;
        }

        public async Task<IActionResult> Index() {
            HomeViewModel model = new HomeViewModel();
            model.Customer = await _customerManager.InitializeCustomerForCurrentUser();
            model.FormStatus = await _formManager.GetCustomerInitiationFormStatus(model.Customer.Id);
            return View(model);
        }

        public IActionResult PageNotFound() {
            return View();
        }

        public new IActionResult Unauthorized() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ApplicationResult(Activity.Current?.Id ?? HttpContext.TraceIdentifier, false));
        }
    }

    public class HomeViewModel {
        public CustomerItemModel Customer { get; set; } = new CustomerItemModel();
        public CustomerFormStatus FormStatus { get; set; }
        public bool ShowInitiationMessage => Customer.Status == CustomerStatus.New;
        public bool ShowInitiationStatus => Customer.Status == CustomerStatus.Pending;
    }
}
