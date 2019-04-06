using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Core_ApiApp.AppFilters
{
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// ExceptionContext --> Class, used to listen the exception
        /// thrown during current exection context
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(ExceptionContext context)
        {
            // 1. Handle the Exception so that the Error Generation will start executing
            // under the current HttpContext
            context.ExceptionHandled = true;

            // 2. Read the Exception Message raised under the current request
            string message = context.Exception.Message;

            // 3. Generate the Response
            string response = $"Exception Occured in Controller {context.RouteData.Values["controller"]}" +
                $" as {message}";
            context.Result = new BadRequestObjectResult(response);
        }
    }
}
