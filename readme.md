# 🔑 .NET Keyed Services Examples

This repository contains examples and usage scenarios of the new **Keyed Services** feature introduced in **.NET 8**.

## 🚀 What are Keyed Services?

In some cases, you may need to register multiple implementations of the same interface and choose between them depending on the context. While factory patterns or `IEnumerable<T>` injection were common solutions in the past, **Keyed Services** now provide a cleaner, built-in way to achieve this.

With Keyed Services, you can register services using a key, and later inject or resolve them based on that key.

### ✅ Key types supported:
- `string`
- `enum`
- `Type`
- custom objects (e.g. record, struct, class)


### Examples:
- [Traditional](DependencyInjection.Traditional) : Using `IEnumerable<T>` to resolve multiple implementations of the same interface.
- [Factory Pattern](DependencyInjection.FactoryPattern) : Using a factory to resolve the correct implementation based on a key.
- Registering With Keyed Services:
  - [Keyed Services with String](DependencyInjection.KeyedServiceWithString)
  - [Keyed Services with Enum](DependencyInjection.KeyedServiceWithEnum)
  - [Keyed Services with Type](DependencyInjection.KeyedServiceWithType)
  - [Keyed Services with Custom Object](DependencyInjection.KeyedServiceWithCustomObject)