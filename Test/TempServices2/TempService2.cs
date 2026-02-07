using Lanut.EasyInject;
using Microsoft.Extensions.DependencyInjection;

namespace TempServices2;

public interface ITempService2
{
    string GetData();
}

[Injectable(ServiceLifetime.Transient)]
public class TempService2 : ITempService2
{
    public string GetData()
    {
        return "TempService2 Data";
    }
}
