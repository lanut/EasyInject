# lanut.EasyInject

[English](README.md) | 中文

一个用于在 .NET 中自动注册依赖注入服务的源生成器 (Source Generator)。该包通过在编译时生成注册代码，简化了依赖注入的配置过程。

## 功能特性

- **自动注册**：自动注册标记了 `[Injectable]` 属性的类。
- **生命周期管理**：支持 `Singleton` (单例)、`Scoped` (作用域) 和 `Transient` (瞬态) 生命周期。
- **接口映射**：自动将类注册为其实现的第一个接口的实现，或者注册为指定的接口。
- **多接口支持**：支持通过叠加属性将同一个类注册为多个不同的接口。
- **编译时生成**：运行时无反射开销，确保高性能。

## 安装

将包添加到您的项目中：

```xml
<PackageReference Include="lanut.EasyInject" Version="1.1.0" />
```

## 使用方法

### 1. 标记您的服务

在您想要注册的类上添加 `[Injectable]` 属性。

```csharp
using lanut.EasyInject;

// 注册为单例 (Singleton)
// 如果类实现了接口，默认使用第一个接口作为服务类型。
[Injectable(ServiceLifetime.Singleton)]
public class MySingletonService : IMySingletonService
{
    // ...
}

// 注册为作用域 (Scoped) 并指定特定接口
[Injectable(ServiceLifetime.Scoped, typeof(IMySpecificInterface))]
public class MyScopedService : IMySpecificInterface, IOtherInterface
{
    // ...
}

// 注册为多个接口
[Injectable(ServiceLifetime.Scoped, typeof(IWriteFileService))]
[Injectable(ServiceLifetime.Scoped, typeof(IReadFileService))]
public class FileService : IReadFileService, IWriteFileService
{
    // ...
}

// 注册为瞬态 (Transient) (如果没有接口，则注册为自身)
[Injectable(ServiceLifetime.Transient)]
public class MyTransientService
{
    // ...
}

// 注册开放泛型
[Injectable(ServiceLifetime.Transient)]
public class MyGenericService<T> : IMyGenericService<T>
{
    // ...
}
```

### 2. 在容器中注册服务

源生成器会为 `IServiceCollection` 创建一个扩展方法。方法名称遵循 `Add{AssemblyName}Services` 的模式（移除点号）。

例如，如果您的项目程序集名称是 `MyProject.Api`，生成的方法将是 `AddMyProjectApiServices`。

在您的 `Program.cs` 或 `Startup.cs` 中：

```csharp
using lanut.EasyInject;

var builder = WebApplication.CreateBuilder(args);

// 调用生成的扩展方法
builder.Services.AddMyProjectApiServices();

var app = builder.Build();
```

## 属性说明

### `[Injectable]`

- **Lifetime**: 指定服务生命周期 (`Singleton`, `Scoped`, `Transient`)。
- **ServiceType** (可选): 要注册的服务类型。
    - 如果为 `null` (默认值)，且类实现了接口，则使用**第一个**接口。
    - 如果为 `null`，且类没有实现接口，则注册类自身。

## 参与贡献

欢迎参与贡献！您可以提交 Pull Request 或报告 Issue。

## 许可证

MIT 许可证
