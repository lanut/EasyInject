using System;
using System.Threading.Tasks;
using Lanut.EasyInject;
using Microsoft.Extensions.DependencyInjection;

namespace Lanut.EasyInject.Sample.Services;

public interface IReadFileService
{
    Task<string> ReadFileAsync(string path);
}
public interface IWriteFileService
{
    Task WriteFileAsync(string path, string content);
}

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

[Injectable(ServiceLifetime.Scoped, typeof(IWriteFileService))]
[Injectable(ServiceLifetime.Scoped, typeof(IReadFileService))]
public class WebFormService: IReadFileService, IWriteFileService
{
    /// <summary>
    /// This Reader reads from a web forum summary
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public async Task<string> ReadFileAsync(string path)
    {
        // Simulate reading a file in a web form context
        await Task.Delay(100); // Simulate async operation
        return $"Content of {path} from WebFormService";
    }

    /// <summary>
    /// This Writer writes to a web forum Comment
    /// </summary>
    public async Task WriteFileAsync(string path, string content)
    {
        // Simulate writing a file in a web form context
        await Task.Delay(100); // Simulate async operation
        // In a real scenario, you would write the content to the specified path
        Console.WriteLine($"Written to {path} in WebFormService: {content} to WebForum");
    }
}