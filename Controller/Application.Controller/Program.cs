using Application.Bl;
using Application.Bl.Contracts;
using Application.Controller.Extensions;
using Application.Repository;
using Application.Repository.Contracts;
using Application.Services;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Application.Controller
{
    public class Program
    {
        const string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{ThreadId}] [{Level:u3}] {Message:lj}{NewLine}";

        public static void Main()
        {
            var builder = WebApplication.CreateBuilder();

            var logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithThreadId()
                .WriteTo.Console(outputTemplate: outputTemplate)
                .WriteTo.File("Application.log", outputTemplate: outputTemplate, rollingInterval: RollingInterval.Infinite)
                .CreateLogger();

            builder.Services.AddSingleton<IUserRepository, UserRepository>(); 
            builder.Services.AddSingleton<IGroupRepository, GroupRepository>();
            builder.Services.AddSingleton<IEmailValidator, EmailValidator>();
            builder.Services.AddSingleton<IUserSettingsService, UserSettingsService>();

            builder.Services.AddSingleton<ILogger>(logger);
            builder.Services.AddSingleton<MyBl, MyBl>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.RegisterUserManagementEndpoints();
            app.RegisterGroupManagementEndpoints();

            app.UseMiddleware<MyMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.Run();
        }
    }
}
