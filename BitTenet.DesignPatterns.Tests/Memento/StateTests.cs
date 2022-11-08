using BitTenet.DesignPatterns.Memento;
using FluentAssertions;
using FluentValidation;

namespace BitTenet.DesignPatterns.Tests.Memento;

public class StateTests
{
    [Fact]
    public void InitializeState_ShouldHaveSameValuesAndBeValid()
    {
        var stateName = "State 1";
        var stateValue = true;

        var state = new State(stateName, stateValue);

        state.Name
            .Should()
            .Be(stateName);
        state.Value
            .Should()
            .BeOfType<bool>()
            .And
            .Be(stateValue);

        var validationResult = state.Validate();

        validationResult
            .Should()
            .NotBeNull();
        validationResult.IsValid
            .Should()
            .BeTrue();
        state.ValidationResult
            .Should()
            .NotBeNull();
        state.ValidationResult.IsValid
            .Should()
            .BeTrue();

        new Action(() => state.ValidateAndThrow())
            .Should()
            .NotThrow<ValidationException>();
    }

    [Fact]
    public void InitializeState_WhenInputsAreNotProvided_ShouldHaveValidationErrors()
    {
        var state = new State("", null);

        state.Validate();

        state.ValidationResult
            .Should()
            .NotBeNull();
        state.ValidationResult.IsValid
            .Should()
            .BeFalse();
        state.ValidationResult.Errors
            .Should()
            .HaveCount(2);
        state.ValidationResult.Errors[0].ErrorMessage
            .Should()
            .Be("Name is not provided.");
        state.ValidationResult.Errors[1].ErrorMessage
            .Should()
            .Be("Value is not provided.");
    }

    [Fact]
    public void InitializeState_WhenInputsAreNotProvided_ShouldThrowException()
    {
        var state = new State("", null);

        new Action(() => state.ValidateAndThrow())
            .Should()
            .Throw<ValidationException>();
    }
}