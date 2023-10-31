using EntitiesLayer;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helpers
{
    public class ValidateModelFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                string messageModel = "Por favor validar la siguiente información";
                ExceptionModel exceptionModel = new ExceptionModel(messageModel);
                Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
                foreach (var key in context.ModelState.Keys)
                {
                    List<string> typeErrors = new List<string>();
                    errors.Add(key, typeErrors);
                    Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateEntry modelEntry = null;
                    context.ModelState.TryGetValue(key, out modelEntry);
                    foreach (var error in modelEntry.Errors)
                    {
                        typeErrors.Add(error.ErrorMessage);
                    }
                }
                exceptionModel.Errors = errors;
                throw exceptionModel;
            }
        }
    }
}
