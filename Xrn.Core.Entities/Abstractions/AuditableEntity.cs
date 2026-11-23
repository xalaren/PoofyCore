namespace Xrn.Core.Entities.Abstractions;

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
