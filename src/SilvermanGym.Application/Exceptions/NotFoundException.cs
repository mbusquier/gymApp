using SilvermanGym.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace SilvermanGym.Application.Exceptions;

public class NotFoundException : ApplicationException
{
    public NotFoundException(string message) : base(message) { }
    
    public override GenericErrorDetails ToProblemDetails()
    {
        return new GenericErrorDetails
        (
            "https://tools.ietf.org/html/rfc7231#section-6.5.4",
            404,
            "Resource not found",
            Message,
            Guid.NewGuid()
        );
    }
}