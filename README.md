# lanut.EasyInject

English | [中文](README.cn.md)

A source generator for automatically registering services for Dependency Injection in .NET. This package simplifies dependency injection by generating the registration code for you at compile time.

## Features

- **Automatic Registration**: Automatically registers classes marked with the `[Injectable]` attribute.
- **Lifetime Management**: Supports `Singleton`, `Scoped`, and `Transient` lifetimes.
- **Interface Mapping**: Automatically registers the class as the implementation of its first interface, or a specific interface if provided.
- **Multiple Interface Support**: Allows registering a single class as multiple different interfaces by stacking attributes.
- **Compile-Time Generation**: No reflection at runtime, ensuring high performance.

## Installation

Add the package to your project:

```xml
<PackageReference Include="lanut.EasyInject" Version="1.1.0" />
```

## Usage

### 1. Mark your services

Add the `[Injectable]` attribute to the classes you want to register.

```csharp
using lanut.EasyInject;

// Register as Singleton
// If the class implements interfaces, the first one is used as the service type by default.
[Injectable(ServiceLifetime.Singleton)]
public class MySingletonService : IMySingletonService
{
    // ...
}

// Register as Scoped with a specific interface
[Injectable(ServiceLifetime.Scoped, typeof(IMySpecificInterface))]
public class MyScopedService : IMySpecificInterface, IOtherInterface
{
    // ...
}

// Register as multiple interfaces
[Injectable(ServiceLifetime.Scoped, typeof(IWriteFileService))]
[Injectable(ServiceLifetime.Scoped, typeof(IReadFileService))]
public class FileService : IReadFileService, IWriteFileService
{
    // ...
}

// Register as Transient (Self-registration if no interfaces)
[Injectable(ServiceLifetime.Transient)]
public class MyTransientService
{
    // ...
}

// Register Open Generic
[Injectable(ServiceLifetime.Transient)]
public class MyGenericService<T> : IMyGenericService<T>
{
    // ...
}
```

### 2. Register services in your container

The source generator creates an extension method for `IServiceCollection`. The method name follows the pattern `Add{AssemblyName}Services`.

For example, if your project assembly name is `MyProject.Api`, the generated method will be `AddMyProjectApiServices`.

In your `Program.cs` or `Startup.cs`:

```csharp
using lanut.EasyInject;

var builder = WebApplication.CreateBuilder(args);

// Call the generated extension method
builder.Services.AddMyProjectApiServices();

var app = builder.Build();
```

## Attributes

### `[Injectable]`

- **Lifetime**: Specifies the service lifetime (`Singleton`, `Scoped`, `Transient`).
- **ServiceType** (Optional): The service type to register.
    - If `null` (default), and the class implements interfaces, the **first** interface is used.
    - If `null`, and the class implements no interfaces, the class itself is registered.

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

MIT License
