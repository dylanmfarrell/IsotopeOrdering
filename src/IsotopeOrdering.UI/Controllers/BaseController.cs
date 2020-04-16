using IsotopeOrdering.App.Models.Shared;
using Microsoft.AspNetCore.Mvc;

namespace IsotopeOrdering.UI.Controllers {
    public abstract class BaseController : Controller {
        protected IActionResult ApplicationResult(string view, ApplicationResult result) {
            ViewBag.ApplicationResult = result;
            return View(view);
        }
    }


}