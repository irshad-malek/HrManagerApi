using Hrmanagement.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using System.Net;
using System;

namespace HRmanagement.Controllers
{
    public class ErrorController : IExceptionFilter
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        //private readonly Iexceptions _iexceptions;
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;
            var exception = context.Exception;
            var exceptionType = context.Exception.GetType();
            if (exceptionType == typeof(UnauthorizedAccessException))
            {
                message = "Unauthorized Access";
                status = HttpStatusCode.Unauthorized;
            }
            else if (exceptionType == typeof(InvalidOperationException))
            {
                message = "A server error occurred.";
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(NotSupportedException))
            {
                message = context.Exception.ToString();
                status = HttpStatusCode.InternalServerError;
            }
            else if (exceptionType == typeof(KeyNotFoundException))
            {
                message = context.Exception.ToString();
                status = HttpStatusCode.NotFound;
            }
            else if (exceptionType == typeof(NullReferenceException))
            {
                message = context.Exception.ToString();
                status = HttpStatusCode.InternalServerError;
            }
            else
            {
                message = context.Exception.Message;
                status = HttpStatusCode.NotFound;
            }
            _logger.LogError($"GlobalExceptionFilter: Error in {context.ActionDescriptor.DisplayName}. {exception.Message}. Stack Trace: {exception.StackTrace}");
            context.ExceptionHandled = true;
            string controllername = context.RouteData.Values["Controller"].ToString();
            string action = context.RouteData.Values["Action"].ToString();
            var st = new StackTrace(exception, true);
            // Get the top stack frame
            var frame = st.GetFrame(0);
            // Get the line number from the stack frame
            var line = frame.GetFileLineNumber();
            context.Result = new ObjectResult(exception.Message) { StatusCode = (int?)status };
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)status;
            response.ContentType = "application/json";
            var err = message + " " + context.Exception.StackTrace;
            string inner = "";
            if (context.Exception.InnerException != null)
            {
                inner = context.Exception.InnerException.Message;

            }

            string stake;
            stake = context.Exception.StackTrace;
            var err1 = message + " " + context.Exception.Message + "Inner exception=" + inner + "StackTrace=" + stake;

            response.WriteAsync(err1);
        }
    }

}
