using System.Collections;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using ThreatMap.Application.Shared.Common.Exceptions.Abstractions;
using ThreatMap.Domain.Identity.Static;

namespace ThreatMap.Admin.Attributes
{
    public class WebExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public WebExceptionFilterAttribute(IModelMetadataProvider modelMetadataProvider, IWebHostEnvironment hostingEnvironment)
        {
            _modelMetadataProvider = modelMetadataProvider;
            _hostingEnvironment = hostingEnvironment;
        }

        public override async Task OnExceptionAsync(ExceptionContext context)
        {

            switch (context.Exception)
            {
                case UnauthorizedAccessException ex:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = WebExceptionResultView(context);
                    context.ExceptionHandled = true;
                    break;

                case ThreatMapException ex:
                    context.HttpContext.Response.StatusCode = 400;
                    context.Result = WebExceptionResultView(context);
                    context.ExceptionHandled = true;
                    break;
                
                // case ForbiddenAccessException ex:
                //     context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                //     context.Result = WebExceptionResultView(context);
                //     context.ExceptionHandled = true;
                //     break;
                //
                // case ServiceException ex:
                //     context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //     context.Result = WebExceptionResultView(context);
                //     context.ExceptionHandled = true;
                //     break;
                //
                // case NotFoundException ex:
                //     context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                //     context.Result = WebExceptionResultView(context);
                //     context.ExceptionHandled = true;
                //     break;

                case Exception ex:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Result = WebExceptionResultView(context);
                    context.ExceptionHandled = true;
                    break;
            }

            base.OnException(context);
        }


        private IActionResult WebExceptionResultView(ExceptionContext context)
        {
            var returnUrl = context.HttpContext.Request.GetEncodedUrl();
            var message = context.Exception.Message;
            var layout = "~/Views/Shared/_Layout.cshtml";//GetLayout(context);
            var exceptionTitle = GetExceptionTitle(context);

            var result = new ViewResult()
            {
                ViewName = "~/Views/Error/ServiceErrorView.cshtml",
                ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState)
            };
            result.ViewData.Add("ReturnUrl", returnUrl);
            result.ViewData.Add("ErrorMessage", message);
            result.ViewData.Add("Layout", layout);
            result.ViewData.Add("ExceptionTitle", exceptionTitle);

            if (_hostingEnvironment.IsDevelopment() || context.HttpContext.User.IsInRole(UserRoles.Dev))
            {
                result.ViewData.Add("AdditionalExceptionInfo", GetAdditionalExceptionInfo(context));
            }

            return result;
        }
        

        private string GetExceptionTitle(ExceptionContext context)
        {
            string title = "Wystąpił błąd";
            switch (context.HttpContext.Response.StatusCode)
            {
                case 400:
                    title = "Wystąpił błąd przetwarzania zapytania na serwerze";
                    break;
                case 401:
                    title = "Nieautoryzowany dostęp do zasobów";
                    break;
                case 403:
                    title = "Brak uprawnień do przeglądania zasobów";
                    break;
                case 404:
                    title = "Nie znaleziono poszukiwanych zasobów";
                    break;
                case 500:
                    title = "Wystąpił nieoczekiwany błąd";
                    break;
            }

            return title;
        }

        private string GetAdditionalExceptionInfo(ExceptionContext context)
        {
            var exceptionData = new StringBuilder();
            if (context.Exception.Data != null && context.Exception.Data.Count > 0)
            {
                exceptionData.Append("<ul>\n");
                foreach (DictionaryEntry d in context.Exception.Data)
                {
                    exceptionData.Append($"<li><b>Key:</b> {d.Key.ToString()} <b class='ml-100'>Value:</b> {d.Value}</li>\n");
                }
                exceptionData.Append("</ul>\n");
            }

            return $"<p><b>Message:</b> {context.Exception?.Message}</p>\n" +
                $"<p><b>Action:</b> {((ControllerActionDescriptor)context?.ActionDescriptor)?.ActionName}</p>\n" +
                $"<p><b>Controller:</b> {((ControllerActionDescriptor)context?.ActionDescriptor)?.ControllerName}</p>\n" +
                $"<p><b>Path:</b> {context.HttpContext?.Request?.Path.Value}</p>\n" +
                $"<p><b>QueryString:</b> {context.HttpContext?.Request?.QueryString}</p>\n" +
                $"<p><b>ExceptionData:</b> {exceptionData?.ToString()}</p>\n" +
                $"<p><b>Source:</b> {context.Exception?.Source}</p>\n" +
                $"<p><b>StackTrace:</b> {context.Exception?.ToString()}</p>\n" +
                $"<p><b>InnerException:</b> {context.Exception?.InnerException?.ToString()}</p>\n";
        }
        

    }

}
