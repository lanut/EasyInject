using Lanut.EasyInject;
using Microsoft.Extensions.DependencyInjection;

namespace CommonServices1;

public interface IReadFileService
{
    Task<string> ReadFileAsync(string path);
}
public interface IWriteFileService
{
    Task WriteFileAsync(string path, string content);
}

// Scoped registration
// output:
// services.AddScoped<global::CommonServices1.IWriteFileService, global::CommonServices1.FileService>();
[Injectable(ServiceLifetime.Scoped, typeof(IWriteFileService))]
[Injectable(ServiceLifetime.Scoped, typeof(IReadFileService))]
public class FileService : IReadFileService, IWriteFileService
{
    public async Task<string> ReadFileAsync(string path)
    {
        return await System.IO.File.ReadAllTextAsync(path);
    }
    public async Task WriteFileAsync(string path, string content)
    {
        await System.IO.File.WriteAllTextAsync(path, content);
    }
}

