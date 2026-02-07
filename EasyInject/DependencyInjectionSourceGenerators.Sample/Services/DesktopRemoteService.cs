using System;
using Microsoft.Extensions.DependencyInjection;
namespace Lanut.EasyInject.Sample.Services;

public interface IRemoteService
{
    void Connect();
    void Disconnect();
}

[Injectable(ServiceLifetime.Singleton, typeof(IRemoteService))]
public class DesktopRemoteService : IRemoteService
{
    public void Connect()
    {
        Console.WriteLine("DesktopRemoteService.Connect()");
    }

    public void Disconnect()
    {
        Console.WriteLine("DesktopRemoteService.Disconnect()");
    }
}
