using Prot.Domain.Entities.Genders;
using Prot.Domain.Interface;
using Prot.Infrastructure.Repositories;

namespace Prot.Api.Configurations;

public static class ExtentionFunction
{
    public static IServiceCollection AddServiceFunctionsConfiguration(
    this IServiceCollection services
)
    {
        services.AddScoped<IGenericRepository<Gender>, GenericRepository<Gender>>();

        return services;
    }
}
