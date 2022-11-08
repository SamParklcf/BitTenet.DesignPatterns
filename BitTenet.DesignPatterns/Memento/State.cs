using BitTenet.DesignPatterns.Memento.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace BitTenet.DesignPatterns.Memento;

/// <summary>
///     Represents a class for holding an object state.
/// </summary>
public class State : IObjectValidator
{
    /// <summary>
    ///     Initializes a new instance of <see cref="State" /> class.
    /// </summary>
    /// <param name="name">Name of the state.</param>
    /// <param name="value">Value of the state.</param>
    public State(string name, object? value)
    {
        Name = name;
        Value = value;

        StateValidator = new StateValidator();
    }

    /// <summary>
    ///     Gets or sets the state name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///     Gets or sets the state value.
    /// </summary>
    public object? Value { get; }

    /// <inheritdoc cref="Validators.StateValidator" />
    protected virtual StateValidator StateValidator { get; }

    /// <inheritdoc />
    public virtual ValidationResult? ValidationResult { get; protected set; }

    /// <inheritdoc />
    public virtual ValidationResult Validate()
    {
        return
            ValidationResult = StateValidator.Validate(this);
    }
    
    /// <inheritdoc />
    public virtual void ValidateAndThrow()
    {
         StateValidator.ValidateAndThrow(this);
    }
}