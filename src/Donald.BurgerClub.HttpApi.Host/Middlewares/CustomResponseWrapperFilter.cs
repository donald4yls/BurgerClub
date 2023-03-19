using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Xml;
using System;
using Newtonsoft.Json;
using Donald.BurgerClub.ViewModels;

namespace Donald.BurgerClub.Middlewares
{
    public class CustomResponseWrapperFilter : Attribute, IActionFilter, IFilterMetadata
    {
        private readonly ILogger<CustomResponseWrapperFilter> _logger;

        public CustomResponseWrapperFilter(ILogger<CustomResponseWrapperFilter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //To do : before the action executes  
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception != null)
            {
                return;
            }

            if (context.HttpContext != null)
            {
                var statusCode = context.HttpContext.Response?.StatusCode ?? 0;
                var result = context.Result as ObjectResult;

                if (IsSuccessResponse(statusCode))
                {
                    if(result != null)
                    {
                        context.Result = new JsonResult(new ApiResponse<object>(result.Value, statusCode, string.Empty));
                    }
                }
                else
                {
                    var errorMsg = string.Empty;
                    if (result?.Value is String || result?.Value is Char)
                    {
                        errorMsg = result?.Value.ToString();
                    }
                    else
                    {
                        errorMsg = JsonConvert.SerializeObject(result.Value, Newtonsoft.Json.Formatting.Indented);
                    }

                    context.Result = new JsonResult(new ApiResponse<object>(null, statusCode, errorMsg));
                }
            }

        }

        private bool IsSuccessResponse(int statusCode)
        {
            return statusCode >= 200 && statusCode < 300;
        }

        private void LogResponse(string message)
        {

        }
    }
}
