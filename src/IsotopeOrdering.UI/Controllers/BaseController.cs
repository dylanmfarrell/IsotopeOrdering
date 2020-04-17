using IsotopeOrdering.App;
using IsotopeOrdering.App.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace IsotopeOrdering.UI.Controllers {
    public abstract class BaseController : Controller {
        protected IActionResult ApplicationResult(string view, ApplicationResult result) {
            ViewData[ViewDataKeys.ApplicationResult] = result;
            return View(view);
        }
    }
}