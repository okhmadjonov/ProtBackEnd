using Microsoft.Extensions.DependencyInjection;
using Prot.Service.Interfaces.Auths;
using Prot.Service.Interfaces.Genders;
using Prot.Service.Interfaces.Tokens;
using Prot.Service.Interfaces.Users;
using Prot.Service.Services.Auths;
using Prot.Service.Services.Genders;
using Prot.Service.Services.Tokens;
using Prot.Service.Services.Users;

namespace Prot.Service.Extentions;


public static class AddExtensionServices
{
    public static IServiceCollection AddServiceConfig(
    this IServiceCollection services
)
    {
        services.AddScoped<IGenderRepository, GenderService>();
        services.AddScoped<IAuthRepository, AuthService>();
        services.AddScoped<ITokenRepository, TokenService>();
        services.AddScoped<IUserRepository, UserService>();
   
        return services;
    }
}