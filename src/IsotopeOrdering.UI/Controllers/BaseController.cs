using IsotopeOrdering.App;
using IsotopeOrdering.App.Models.Shared;
using IsotopeOrdering.UI.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IsotopeOrdering.UI.Controllers {
    public abstract class BaseController : Controller {
        protected void SetApplicationResult(ApplicationResult result) {
            TempData.Put(ViewDataKeys.ApplicationResult, result);
        }

        protected IActionResult ApplicationResult(string view, ApplicationResult result) {
            SetApplicationResult(result);
            return View(view);
        }

        protected IActionResult JsonValidationErrorResult(ModelStateDictionary modelState) {
            IEnumerable<ModelStateEntry> entries = modelState.Values.Where(x => x.ValidationState != ModelValidationState.Valid);
            string message = string.Join(Environment.NewLine, entries.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)); 
            ApplicationResult result = new ApplicationResult(message, false);
            return Json(result);
        }

        protected async Task<IActionResult> Partial<T>(string partial, T model) {
            return await Task.Run(() => {
                if (ModelState.IsValid) {
                    return PartialView(partial, model);
                }
                return JsonValidationErrorResult(ModelState);
            });
        }
    }
}