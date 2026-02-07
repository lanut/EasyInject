using CommonServices1;
using Lanut.EasyInject;
using Microsoft.Extensions.DependencyInjection;

namespace CommonTest;

static class Program
{
    static void Main(string[] args)
    {
        IServiceCollection services = new ServiceCollection();
        services.AddCommonServices1Services();
        services.AddTempServices2Services();
        
        // build service provider
        var serviceProvider = services.BuildServiceProvider();
        var remoteService = serviceProvider.GetService<IRemoteService>();
        remoteService?.Connect();
        remoteService?.Disconnect();
    }
}
