using Application.Common.Interfaces;
using Infrastructure.Identity;
using Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class ConfigureServices
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration )
    {
        services.AddScoped<OnSaveInterceptor>();

        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ConnentionString"))
                   .AddInterceptors(sp.GetRequiredService<OnSaveInterceptor>());
        });

        return services;
    }
}
