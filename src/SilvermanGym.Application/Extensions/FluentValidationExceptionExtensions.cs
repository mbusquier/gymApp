using SilvermanGym.Application.Contracts;
using FluentValidation;

namespace SilvermanGym.Application.Extensions;

public static class FluentValidationExceptionExtensions
{
    public static ValidationErrorDetails ToValidationErrorDetails(this ValidationException ex)
    {
        var result = new Dictionary<string, string[]>();
        var errorsByProperty = ex.Errors.GroupBy(err => err.PropertyName);
        foreach (var property in errorsByProperty)
        {
            var errors = property.Select(error => error.ErrorMessage).ToArray();
            result.Add(property.Key.Split(".")[0], errors);
        }

        return new ValidationErrorDetails
        (
            "https://tools.ietf.org/html/rfc7231#section-6.5.1",
            400,
            "One or more validation errors ocurred.",
            result,
            Guid.NewGuid()
        );
    }
}