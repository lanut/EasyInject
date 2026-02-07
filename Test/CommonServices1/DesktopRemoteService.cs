using Lanut.EasyInject;
using Microsoft.Extensions.DependencyInjection;

namespace CommonServices1;

public interface IRemoteService
{
    void Connect();
    void Disconnect();
}

// Singleton registration
// output:
// services.AddSingleton<global::CommonServices1.IRemoteService, global::CommonServices1.DesktopRemoteService>();
[Injectable(ServiceLifetime.Singleton)]
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
