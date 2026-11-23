namespace SpoofyCore.Entities.Abstractions;

/// <summary>
/// Interface for entities that can expire. Expired entities are considered invalid and should not be used.
/// </summary>
public interface IExpireable
{
    /// <summary>
    /// Utc datetime when the record will expire. If the current UTC datetime is greater than this value, the record is considered expired.
    /// </summary>
    DateTime ExpiresAtUtc { get; }

    /// <summary>
    /// Gets a value indicating whether the record has expired.
    /// </summary>
    bool Expired { get; }
}
