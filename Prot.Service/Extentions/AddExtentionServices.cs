using Microsoft.Extensions.DependencyInjection;
using Prot.Service.Interfaces.Genders;
using Prot.Service.Services.Genders;

namespace Prot.Service.Extentions;


public static class AddExtensionServices
{
    public static IServiceCollection AddServiceConfig(
    this IServiceCollection services
)
    {
        services.AddScoped<IGenderRepository, GenderService>();
        return services;
    }
}