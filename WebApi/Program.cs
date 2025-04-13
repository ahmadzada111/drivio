using WebApi.Extensions;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Configuration.AddJsonFile("appsettings.json", true, true)
            .AddUserSecrets<Program>(optional:true, reloadOnChange:true)
            .AddEnvironmentVariables();

        builder.Services.AddControllers();
        builder.Services.ConfigureAuthentication(builder.Configuration);
        builder.Services.ConfigureAuthorization();
        builder.Services.ConfigureIdentity();
        builder.Services.ConfigureDbContext(builder);
        builder.Services.AddOpenApi();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHsts();
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        
        app.Run();
    }
}