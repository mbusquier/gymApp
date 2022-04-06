using SilvermanGym.Application.Contracts;
using SilvermanGym.Application.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ApplicationException = SilvermanGym.Application.Exceptions.ApplicationException;

namespace SilvermanGym.API.Filters
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            // Customize this object to fit your needs
            var result = new ObjectResult(null);
            switch (context.Exception)  
            {
                // If its one of our custom exceptions
                case ApplicationException ex:
                    var errorDetails = ex.ToProblemDetails();
                    result.Value = errorDetails;
                    result.StatusCode = errorDetails.Status;
                    break;
                // If its validator exception
                case FluentValidation.ValidationException ex:
                    var validationErrorDetails = ex.ToValidationErrorDetails();
                    result.Value = validationErrorDetails;
                    result.StatusCode = validationErrorDetails.Status;
                    break;
                // If its any other exception
                default:
                    result.Value =  new
                    {
                        Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                        Status = 500,
                        Title = "An error occured while processing your request."
                    };
                    result.StatusCode = 500;
                    break;
            }

            context.Result = result;
        }
    }
}