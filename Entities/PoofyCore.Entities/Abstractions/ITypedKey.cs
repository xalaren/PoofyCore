namespace PoofyCore.Entities.Abstractions;

/// <summary>
/// Provides typed primary key definition
/// </summary>
public interface ITypedKey { }

/// <summary>
/// Provides typed primary key definition
/// </summary>
/// <typeparam name="TKey">A primitive not null type that identifies an entity (e.g. `Guid`, `int`)</typeparam
public interface ITypedKey<out TKey> : ITypedKey where TKey : notnull
{
    /// <summary>
    /// The inner raw value of the key
    /// </summary>
    TKey Key { get; }
}

/// <summary>
/// Provides typed primary key definition
/// </summary>
/// <typeparam name="TSelf">Type of implementation</typeparam>
/// <typeparam name="TKey">A primitive not null type that identifies an entity (e.g. `Guid`, `int`)</typeparam>
public interface ITypedKey<TSelf, TKey> : ITypedKey<TKey>, IEquatable<TSelf>, IEmptyable<TSelf>
    where TSelf : struct, ITypedKey<TSelf, TKey>
    where TKey : notnull
{
    /// <summary>
    /// Creates empty key
    /// </summary>
    /// <returns>New empty key</returns>
    static abstract TSelf Empty();

    /// <summary>
    /// Creates a new generated key
    /// </summary>
    /// <returns>New generated key</returns>
    static abstract TSelf New();

    /// <summary>
    /// Creates a new key from raw value
    /// </summary>
    /// <param name="raw">Raw key value</param>
    /// <returns>New key</returns>
    static abstract TSelf From(TKey raw);

    /// <summary>
    /// Parse a new key from raw string value
    /// </summary>
    /// <param name="raw">Raw string value</param>
    /// <returns>Parsed key</returns>
    static abstract TSelf Parse(string raw);
}