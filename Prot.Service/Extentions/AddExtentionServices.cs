using Microsoft.Extensions.DependencyInjection;

namespace Prot.Service.Extentions;


public static class AddExtensionServices
{
    public static IServiceCollection AddServiceConfig(
    this IServiceCollection services
)
    {
        return services;
    }
}