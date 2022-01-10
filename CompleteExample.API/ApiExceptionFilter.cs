using CompleteExample.Logic.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CompleteExample.API
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            ApiError apiError;

            if (exception is UiException useCaseException)
            {
                apiError = new ApiError(useCaseException);
            }
            else
            {
                useCaseException = new UiFatalException();
                apiError = new ApiError(useCaseException);
            }

            switch (useCaseException)
            {
                case UiValidationException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case UiNotFoundException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UiFatalException:
                default:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            context.Result = new JsonResult(apiError);
            context.ExceptionHandled = true;
        }
    }
}
