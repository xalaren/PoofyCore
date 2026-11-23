namespace Xrn.Core.Entities.Abstractions;

/// <summary>
/// Provides typed primary key definition
/// </summary>
public interface ITypedKey { }

/// <summary>
/// Provides typed primary key definition
/// </summary>
/// <typeparam name="TKey">Type of key</typeparam
public interface ITypedKey<out TKey> : ITypedKey where TKey : notnull
{
    TKey Key { get; }
}

/// <summary>
/// Provides typed primary key definition
/// </summary>
/// <typeparam name="TSelf">Type of implementation</typeparam>
/// <typeparam name="TKey">Type of key</typeparam>
public interface ITypedKey<TSelf, TKey> : ITypedKey<TKey>, IEquatable<TSelf>
    where TSelf : struct, ITypedKey<TSelf, TKey>
    where TKey : notnull
{
    /// <summary>
    /// Creates empty key
    /// </summary>
    /// <returns>Empty key</returns>
    static abstract TSelf Empty();

    /// <summary>
    /// Creates a new generated key
    /// </summary>
    /// <returns>New generated key</returns>
    static abstract TSelf New();

    /// <summary>
    /// Creates a new key from value
    /// </summary>
    /// <param name="key">Value of the key</param>
    /// <returns>New key</returns>
    static abstract TSelf From(TKey key);
}