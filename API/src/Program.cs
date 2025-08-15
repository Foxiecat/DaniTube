using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;
using src.Config.Database;
using src.Extensions;
using src.Middleware;

namespace src;

public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
        
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Host.UseSerilog((context, configuration) => 
                configuration.ReadFrom.Configuration(context.Configuration));

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddOpenApi();
            
            builder.Services.AddScopedFeaturesServices();

            builder.Services.AddJwtAuthServices(builder.Configuration);

            builder.Services.AddDbContext<DaniTubeDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.MapOpenApi();
                app.MapScalarApiReference();
            }

            app.UseHttpsRedirection();
            app.UseHealthChecks("_/health");
            app.UseMiddleware<JwtMiddleware>();
            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
        catch (Exception exception)
        {
            Log.Fatal(exception, "Application start-up failed");
            throw;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}