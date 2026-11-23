using Xrn.Core.Entities.Abstractions;

namespace Xrn.Core.Entities.Tests;

internal sealed class TestAuditableEntity : AuditableEntity<TestKey>
{
    public TestAuditableEntity(TestKey id)
    {
        Id = id;
    }
}
