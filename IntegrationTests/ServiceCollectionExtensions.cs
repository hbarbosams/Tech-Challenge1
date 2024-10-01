using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests;

public static class ServiceCollectionExtensions
{
    public static void Remove<T>(this IServiceCollection services)
    {
        var descriptor = services.FirstOrDefault(d => d.ServiceType == typeof(T));
        if(descriptor is not null) services.Remove(descriptor);
    }
}