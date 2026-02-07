using Lanut.EasyInject;
using ServiceLifetime = Microsoft.Extensions.DependencyInjection.ServiceLifetime;

namespace CommonServices1;
public interface IGenericService<out T> where T : new()
{
    T GetData();
}

// Generic registration
// output:
// services.AddTransient(typeof(global::CommonServices1.IGenericService<>), typeof(global::CommonServices1.GenericServices<>));

[Injectable(ServiceLifetime.Transient)]
public class GenericServices<T> : IGenericService<T> where T : new()
{
    private readonly T _data = new T();

    public T GetData()
    {
        return _data;
    }
}

// Specific registration for ObjectGenericService
// output:
// services.AddTransient<global::CommonServices1.GenericServices<object>, global::CommonServices1.ObjectGenericService>();
[Injectable(ServiceLifetime.Transient, typeof(GenericServices<object>))]
public class ObjectGenericService : GenericServices<object>;
