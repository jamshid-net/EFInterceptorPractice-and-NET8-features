
using Infrastructure.Identity;
using Microsoft.OpenApi.Models;
using System.Security.Claims;

namespace EFInterceptorPractice;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "My API",
                Version = "v1"
            });
            c.AddSecurityDefinition("Identity.Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please insert JWT with Bearer into field",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                 new OpenApiSecurityScheme
                 {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Identity.Bearer"
                    }
                 },
                 new string[] { }
                }
            });
        });

        builder.Services.AddApiConfigure(builder.Configuration);

        var app = builder.Build();


        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }


        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGroup("/identity").MapIdentityApi<ApplicationUser>();

        app.MapGet("/requires-auth", (ClaimsPrincipal user) => $"Hello, {user.FindFirstValue(ClaimTypes.NameIdentifier)}!").RequireAuthorization();
        app.MapControllers();

        app.Run();
    }
}
