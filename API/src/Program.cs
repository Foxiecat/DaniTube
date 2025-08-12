using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using src.Config;
using src.Config.Database;
using src.Middleware;
using src.Services;
using src.Services.Interfaces;

namespace src;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<JwtMiddleware>();
        
        builder.Services.Configure<JwtOptions>(
            builder.Configuration.GetSection("JWT"));

        builder.Services.AddAuthentication(configureOptions =>
        {
            configureOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            configureOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            configureOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            var secretInBytes = Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]
                                                       ?? throw new NullReferenceException("Missing JWT:Key"));
            options.TokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(secretInBytes),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidIssuer = builder.Configuration["JWT:Issuer"],
                ValidateAudience = true,
                ValidAudience = builder.Configuration["JWT:Audience"],
            };
        });

        builder.Services.AddAuthorization();
        
        builder.Services.AddDbContext<DaniTubeDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.UseHttpsRedirection();
        app.UseMiddleware<JwtMiddleware>();
        app.UseAuthorization();
        app.UseAuthentication();
        
        app.MapControllers();

        app.Run();
    }
}