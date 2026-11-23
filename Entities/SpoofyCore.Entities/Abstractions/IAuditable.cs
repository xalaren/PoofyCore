namespace SpoofyCore.Entities.Abstractions;

/// <summary>
/// Defines datetimes used to track when an entity was created and most recently modified.
/// </summary>
public interface IAuditable
{
    /// <summary>
    /// DateTime when entity was created on
    /// </summary>
    DateTime CreatedOnUtc { get; set; }

    /// <summary>
    /// DateTime when entity was modified on 
    /// </summary>
    DateTime ModifiedOnUtc { get; set; }
}
