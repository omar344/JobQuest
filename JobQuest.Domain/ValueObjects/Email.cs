using JobQuest.Domain.Exceptions;

namespace JobQuest.Domain.ValueObjects;

public sealed record Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidEmailException("Email is required.");

        Value = value.Trim().ToLowerInvariant();
    }

    public override string ToString() => Value;
}