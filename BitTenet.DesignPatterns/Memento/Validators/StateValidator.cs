using FluentValidation;

namespace BitTenet.DesignPatterns.Memento.Validators;

/// <summary>
///     Validates a <see cref="State" /> instance.
/// </summary>
public class StateValidator : AbstractValidator<State>
{
    /// <summary>
    ///     Initializes a new instance of <see cref="StateValidator" /> class.
    /// </summary>
    public StateValidator()
    {
        RuleFor(x => x.Name)
            .Must(x => !string.IsNullOrEmpty(x))
            .WithSeverity(Severity.Error)
            .WithMessage(x => $"{nameof(x.Name)} is not provided.");

        RuleFor(x => x.Value)
            .Must(x => x is not null)
            .WithSeverity(Severity.Error)
            .WithMessage(x => $"{nameof(x.Value)} is not provided.");
    }
}