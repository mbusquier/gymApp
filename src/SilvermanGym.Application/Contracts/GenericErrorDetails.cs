using JetBrains.Annotations;

namespace SilvermanGym.Application.Contracts;

public record GenericErrorDetails(string Type, int Status, string Title, string Detail, Guid TraceId);