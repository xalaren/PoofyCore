using PoofyCore.Entities.Abstractions;

namespace PoofyCore.Entities.Tests;

internal sealed class TestAuditableEntity : AuditableEntity<TestKey>
{
    public TestAuditableEntity(TestKey id)
    {
        Id = id;
    }
}
