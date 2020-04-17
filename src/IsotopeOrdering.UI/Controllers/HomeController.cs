using IsotopeOrdering.App.Interfaces;
using IsotopeOrdering.App.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {
    public class HomeController : BaseController {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerManager _customerManager;

        public HomeController(ILogger<HomeController> logger, ICustomerManager customerManager) {
            _logger = logger;
            _customerManager = customerManager;
        }

        public async Task<IActionResult> Index() {
            await _customerManager.InitializeCustomerForCurrentUser();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ApplicationResult(Activity.Current?.Id ?? HttpContext.TraceIdentifier, false));
        }
    }
}
