using Xrn.Core.Entities.Abstractions;

namespace Xrn.Core.Entities.Tests;

public class AuditableEntityTests
{
    [Fact]
    public void Timestamps_WithDefaultValues_EqualToDefaultDateTime()
    {
        var entity = new TestAuditableEntity(default);

        Assert.Equal(default, entity.CreatedOnUtc);
        Assert.Equal(default, entity.ModifiedOnUtc);
    }

    [Fact]
    public void Timestamps_CanBeReadAndWrittenThroughInterface()
    {
        var entity = new TestAuditableEntity(default);
        IAuditable auditable = entity;
        var createdOnUtc = new DateTime(2026, 1, 2, 3, 4, 5, DateTimeKind.Utc);
        var modifiedOnUtc = new DateTime(2026, 2, 3, 4, 5, 6, DateTimeKind.Utc);

        auditable.CreatedOnUtc = createdOnUtc;
        auditable.ModifiedOnUtc = modifiedOnUtc;

        Assert.Equal(createdOnUtc, entity.CreatedOnUtc);
        Assert.Equal(modifiedOnUtc, entity.ModifiedOnUtc);
    }
}
