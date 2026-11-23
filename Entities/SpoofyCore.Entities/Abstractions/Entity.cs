namespace SpoofyCore.Entities.Abstractions;

/// <summary>
/// Base entity abstraction
/// </summary>
/// <typeparam name="TContainer">Container of primary key</typeparam>
/// <typeparam name="TKey"></typeparam>
public abstract class Entity<TKey> : IEquatable<Entity<TKey>>
    where TKey : struct, ITypedKey, IEquatable<TKey>
{
    /// <summary>
    /// Primary key of the entity
    /// </summary>
    public TKey Id { get; protected init; }

    /// <summary>
    /// Indicates whether the entity is transient
    /// </summary>
    public bool IsTransient => Id.Equals(default);

    public virtual bool Equals(Entity<TKey>? other)
    {
        return 
            other is not null
            && GetType() == other.GetType()
            && (ReferenceEquals(this, other) || (!IsTransient && Id.Equals(other.Id)));
    }

    public override bool Equals(object? obj) => obj is Entity<TKey> e && Equals(e);
    public override int GetHashCode() => HashCode.Combine(GetType(), Id);
    public static bool operator ==(Entity<TKey>? a, Entity<TKey>? b) => a?.Equals(b) ?? b is null;
    public static bool operator !=(Entity<TKey>? a, Entity<TKey>? b) => !(a == b);
}
