using SilvermanGym.Application.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace SilvermanGym.Application.Exceptions;

public abstract class ApplicationException : Exception
{
    public ApplicationException(string message) : base(message) {}

    public abstract GenericErrorDetails ToProblemDetails();
}