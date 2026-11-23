using SpoofyCore.Entities.Abstractions;

namespace SpoofyCore.Entities.Tests;

public class EntityTests
{
    [Fact]
    public void Entity_WithDefaultId_IsTransient()
    {
        var entity = new TestEntity(default);

        Assert.True(entity.IsTransient);
    }

    [Fact]
    public void Entity_WithNonDefaultId_IsNotTransient()
    {
        var entity = new TestEntity(new TestKey(1));

        Assert.False(entity.IsTransient);
    }

    [Fact]
    public void Entities_SameTypeWithSameNonTransientId_AreEqual()
    {
        var first = new TestEntity(new TestKey(1));
        var second = new TestEntity(new TestKey(1));

        Assert.True(first.Equals(second));
        Assert.True(first.Equals((object)second));
        Assert.True(first == second);
        Assert.False(first != second);
        Assert.Equal(first.GetHashCode(), second.GetHashCode());
    }

    [Fact]
    public void Entities_WithDifferentIds_AreNotEqual()
    {
        var first = new TestEntity(new TestKey(1));
        var second = new TestEntity(new TestKey(2));

        Assert.False(first.Equals(second));
        Assert.NotEqual(first, second);
    }

    [Fact]
    public void Entities_WithDifferentRuntime_AreNotEqual()
    {
        var entity = new TestEntity(new TestKey(1));
        var otherEntity = new OtherTestEntity(new TestKey(1));

        Assert.False(entity.Equals(otherEntity));
        Assert.False(otherEntity.Equals(entity));
    }

    [Fact]
    public void Entities_DistinctTransient_AreNotEqual_ButEntityIsEqualToItself()
    {
        var first = new TestEntity(default);
        var second = new TestEntity(default);

        Assert.True(first.Equals(first));
        Assert.False(first.Equals(second));
        Assert.NotEqual(first, second);
    }

    [Fact]
    public void EqualityOperators_HandleNullEntities()
    {
        TestEntity? entity = null;

        Assert.Null(entity);
        Assert.NotNull(new TestEntity(new TestKey(1)));
    }
}

internal readonly record struct TestKey(int Value) : ITypedKey;

internal sealed class TestEntity : Entity<TestKey>
{
    public TestEntity(TestKey id)
    {
        Id = id;
    }
}

internal sealed class OtherTestEntity : Entity<TestKey>
{
    public OtherTestEntity(TestKey id)
    {
        Id = id;
    }
}
