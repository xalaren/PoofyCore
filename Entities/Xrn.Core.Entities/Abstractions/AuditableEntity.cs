namespace Xrn.Core.Entities.Abstractions;

/// <summary>
/// Represents an entity that tracks its creation and modification timestamps in UTC.
/// </summary>
/// <typeparam name="TKey">The key type for the entity.</typeparam>
public abstract class AuditableEntity<TKey> : Entity<TKey>, IAuditable
    where TKey : struct, ITypedKey, IEquatable<TKey>
{
    /// <summary>
    /// DateTime when entity was created on
    /// </summary>
    public DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// DateTime when entity was modified on 
    /// </summary>
    public DateTime ModifiedOnUtc { get; set; }
}
