namespace PoofyCore.Entities.Abstractions;

/// <summary>
/// Defines a contract for determining whether a value is empty.
/// </summary>
/// <remarks>Implementations provide the value-specific emptiness test.</remarks>
/// <typeparam name="TValue">The type of value evaluated for emptiness.</typeparam>
public interface IEmptyable<TValue>
{
    /// <summary>
    /// Determines whether a value is empty.
    /// </summary>
    /// <param name="value">The value to test.</param>
    /// <returns><see langword="true"/> if the value is empty; otherwise, <see langword="false"/>.</returns>
    static abstract bool IsEmpty(TValue value);
}
