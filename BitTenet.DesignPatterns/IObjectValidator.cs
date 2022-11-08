using FluentValidation.Results;

namespace BitTenet.DesignPatterns;

/// <summary>
///     Provides functionalities to validate an object.
/// </summary>
public interface IObjectValidator
{
    /// <inheritdoc cref="FluentValidation.Results.ValidationResult" />
    ValidationResult? ValidationResult { get; }

    /// <summary>
    ///     Validates object.
    /// </summary>
    ValidationResult Validate();

    /// <summary>
    ///     Performs validation and then throws an exception if validation fails.
    /// </summary>
    void ValidateAndThrow();
}