using SpoofyCore.Entities.Abstractions;

namespace SpoofyCore.Entities.Tests;

internal sealed class TestAuditableEntity : AuditableEntity<TestKey>
{
    public TestAuditableEntity(TestKey id)
    {
        Id = id;
    }
}
