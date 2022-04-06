using JetBrains.Annotations;

namespace SilvermanGym.Application.Contracts;

public record ValidationErrorDetails(string Type, int Status, string Title, IDictionary<string, string[]> Errors, Guid TraceId);