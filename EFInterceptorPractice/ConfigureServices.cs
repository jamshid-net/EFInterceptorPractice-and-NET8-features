using Application;
using Application.Common.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace EFInterceptorPractice;

public static class ConfigureServices
{
    public static IServiceCollection AddApiConfigure(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUser, CurrentUser>();

        services.AddAuthentication()
                .AddBearerToken(IdentityConstants.BearerScheme);
        services.AddAuthorizationBuilder();


        services.AddApplication();
        services.AddInfrastructure(configuration);
        services.AddIdentityCore<ApplicationUser>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddApiEndpoints();

       

        return services;
    }
}
