using Drivio.Services;
using Drivio.WebApi.ExceptionHandler;
using Drivio.WebApi.Extensions;
using FluentValidation;

namespace Drivio.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Configuration.AddJsonFile("appsettings.json", true, true)
            .AddUserSecrets<Program>(true, true)
            .AddEnvironmentVariables();

        builder.Services.AddControllers();
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddValidatorsFromAssembly(AssemblyReference.Reference);
        builder.Services.ConfigureAuthentication(builder.Configuration);
        builder.Services.ConfigureAuthorization();
        builder.Services.ConfigureIdentity();
        builder.Services.ConfigureDbContext(builder);
        builder.Services.ConfigureSwagger();
        builder.Services.AddEndpointsApiExplorer();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => options.EnablePersistAuthorization());
        }
        else
        {
            app.UseExceptionHandler();
        }
        
        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        
        app.Run();
    }
}