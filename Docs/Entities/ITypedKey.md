# ITypedKey
<br/>


## 🔍 Definition

> [!NOTE]
> Provides typed primary key definition.

**Type:** Interface \
**Namespace:**: PoofyCore.Entities \
**Platform:** .NET 10 / C# 14 \
**Source:** [ITypedKey.cs](../../Entities/PoofyCore.Entities/Abstractions/ITypedKey.cs) \
<br/>

```csharp
public interface ITypedKey
```

```csharp
public interface ITypedKey<out TKey> : ITypedKey where TKey : notnull
```

```csharp
public interface ITypedKey<TSelf, TKey> : ITypedKey<TKey>, IEquatable<TSelf>, IEmptyable<TSelf>
    where TSelf : struct, ITypedKey<TSelf, TKey>
    where TKey : notnull
```
<br/>

## 🦜 Type Parameters

<a id="tself"></a>
`TSelf`
---
Current `ITypedKey` implementation value type. 

<a id="tkey"></a>
`TKey` 
---
A primitive not null type that identifies an entity (e.g. `Guid`, `int`)

<br/>

## 🎯 Purpose

Resolves a problem, when keys are raw `Guid` or `int` or another primitive type of key and anyone can pass the value not related to it's entity. 

For example, if exists method `ProcessOrder` with raw `Guid` arguments in order `orderId` then `userId`. 

A situation may arise where this method is called with parameters passed in the incorrect order and the compiler will not detect it.

```csharp
Order ProcessOrder(Guid orderId, Guid userId) { ... }

// ...
// Arguments passed not in correct order. 
// That method fails only at runtime. Compiler will not detect it.
ProcessOrder(userId, orderId); 
```
<br/>

## 🎨 Examples

Implementation of typed key related with `User` entity:

```csharp
public readonly record struct UserId : ITypedKey<UserId, Guid>
{
    public Guid Key { get; private init; }

    public static UserId Empty() => new UserId { Key = Guid.Empty };
    public static UserId New() => new UserId { Key = Guid.NewGuid() };
    public static UserId From(Guid key) => new UserId { Key = key };
    public static UserId Parse(string value) => new UserId { Key = Guid.Parse(value) };
    public static bool IsEmpty(UserId value) => value.Key == Guid.Empty;
}

public readonly record struct OrderId : ITypedKey<OrderId, Guid>
{
    public Guid Key { get; private init; }

    public static OrderId Empty() => new OrderId { Key = Guid.Empty };
    public static OrderId New() => new OrderId { Key = Guid.NewGuid() };
    public static OrderId From(Guid key) => new OrderId { Key = key };
    public static OrderId Parse(string value) => new OrderId { Key = Guid.Parse(value) };
    public static bool IsEmpty(OrderId value) => value.Key == Guid.Empty;
}
```

Using example:

```csharp
Order ProcessOrder(UserId userId, OrderId orderId) { ... }

//...

var userId = UserId.Parse("f6aa5f5d-6e46-4aff-92e5-ff63fb68b9ca");
var orderId = OrderId.New();

ProcessOrder(userId, orderId); // Calling 'ProcessOrder' in correct way
ProcessOrder(orderId, userId);  // Calling 'ProcessOrder' not in correct way. Fails at compilation
```
<br/>

## 🔧 Properties 

`Key`
---
**Description:** The inner raw value of the key \
**Type:** [TKey](#tkey) \
<br/>

## 📦 Methods

`Empty()`
---
**Description:** Creates empty key \
**Modifiers:** `static`, `abstract` \
**Return Type:** `TSelf` \
**Returns:** New empty key

`New()`
---
**Description:** Creates a new generated key \
**Modifiers:** `static`, `abstract` \
**Return type:** `TSelf`. \
**Returns:** New generated key

`From(TKey key)`
---
**Description:** Creates a new generated key \
**Modifiers:** `static`, `abstract` \
**Arguments:**
| Name | Type | Description |
| :--- | :--- | :--- |
| raw | [TKey](#tkey) | Raw key value |

**Return type:** [TSelf](#tself) \
**Returns:** New key

`Parse(TKey key)`
---
**Description:** Parse a new key from raw string value \
**Modifiers:** `static`, `abstract` \
**Arguments:**
| Name | Type | Description |
| :--- | :--- | :--- |
| raw | String |Raw string value |

**Return type:** [TSelf](#tself) \
**Returns:** Parsed key


