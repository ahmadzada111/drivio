using Microsoft.EntityFrameworkCore;
using Drivio.Persistence.DbContext;

namespace Drivio.WebApi.Extensions;

public static class DbExtensions
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionString:DefaultConnection")));
        
        return services;
    }
}