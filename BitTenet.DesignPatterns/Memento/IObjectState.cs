namespace BitTenet.DesignPatterns.Memento;

/// <summary>
///     Provides functionalities for generating object state.
/// </summary>
public interface IObjectState
{
    /// <summary>
    ///     Gets the state of an object.
    /// </summary>
    /// <returns>A read-only list that represents the state of an object.</returns>
    IReadOnlyList<State> GetState();
}