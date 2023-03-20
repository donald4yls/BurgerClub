using Donald.BurgerClub.ViewModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.Authorization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.Http;
using Volo.Abp.Json;
using Volo.Abp.Validation;
using Volo.Abp;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Donald.BurgerClub.Middlewares
{
    public class CustomExceptionFilter : IFilterMetadata, IAsyncExceptionFilter, ITransientDependency
    {
        public ILogger<CustomExceptionFilter> Logger { get; set; }

        private readonly IExceptionToErrorInfoConverter _errorInfoConverter;
        private readonly IHttpExceptionStatusCodeFinder _statusCodeFinder;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly AbpExceptionHandlingOptions _exceptionHandlingOptions;

        public CustomExceptionFilter(
            IExceptionToErrorInfoConverter errorInfoConverter,
            IHttpExceptionStatusCodeFinder statusCodeFinder,
            IJsonSerializer jsonSerializer,
            IOptions<AbpExceptionHandlingOptions> exceptionHandlingOptions)
        {
            _errorInfoConverter = errorInfoConverter;
            _statusCodeFinder = statusCodeFinder;
            _jsonSerializer = jsonSerializer;
            _exceptionHandlingOptions = exceptionHandlingOptions.Value;

            Logger = NullLogger<CustomExceptionFilter>.Instance;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            if (!ShouldHandleException(context))
            {
                return;
            }

            await HandleAndWrapException(context);
        }

        protected virtual bool ShouldHandleException(ExceptionContext context)
        {
            if (context.ActionDescriptor.IsControllerAction())
            {
                return true;
            }

            if (context.HttpContext.Request.CanAccept(MimeTypes.Application.Json))
            {
                return true;
            }

            if (context.HttpContext.Request.IsAjax())
            {
                return true;
            }

            return false;
        }

        protected virtual async Task HandleAndWrapException(ExceptionContext context)
        {
            //TODO: Trigger an AbpExceptionHandled event or something like that.

            context.HttpContext.Response.Headers.Add(AbpHttpConsts.AbpErrorFormat, "true");
            context.HttpContext.Response.StatusCode = (int)_statusCodeFinder.GetStatusCode(context.HttpContext, context.Exception);

            var remoteServiceErrorInfo = _errorInfoConverter.Convert(context.Exception, _exceptionHandlingOptions.SendExceptionsDetailsToClients);
            remoteServiceErrorInfo.Code = context.HttpContext.TraceIdentifier;
            remoteServiceErrorInfo.Message = SimplifyMessage(context.Exception);

            var serializeException = _jsonSerializer.Serialize(remoteServiceErrorInfo, indented: true);
            // HttpResponse
            var response = new ApiResponse<object>();

            if (context.Exception is BusinessException)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            else
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            response.ErrorMessage = serializeException;
            context.Result = new ObjectResult(response);

            var logLevel = context.Exception.GetLogLevel();
            var remoteServiceErrorInfoBuilder = new StringBuilder();
            remoteServiceErrorInfoBuilder.AppendLine($"---------- {nameof(RemoteServiceErrorInfo)} ----------");
            remoteServiceErrorInfoBuilder.AppendLine();
            Logger.LogWithLevel(logLevel, remoteServiceErrorInfoBuilder.ToString());
            Logger.LogException(context.Exception, logLevel);

            await context.HttpContext
                .RequestServices
                .GetRequiredService<IExceptionNotifier>()
                .NotifyAsync(
                    new ExceptionNotificationContext(context.Exception)
                );

            context.Exception = null; //Handled!
        }

        protected string SimplifyMessage(Exception error)
        {
            string message = string.Empty;
            switch (error)
            {
                case AbpAuthorizationException e:
                    return message = $"Authenticate failure！{e.Message}";
                case AbpValidationException e:
                    return message = $"Request param validate failure！{e.Message}";
                case EntityNotFoundException e:
                    return message = $"not found the entity！{e.Message}";
                case BusinessException e:
                    return message = $"business exception！{e.Message}";
                case NotImplementedException e:
                    return message = $"not implement！{e.Message}";
                default:
                    return message = $"server internal error！{error.Message}";
            }
        }
    }
}
