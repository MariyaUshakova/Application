using Application.Controller.IntegrationTests.InMemoryData;
using Application.Repository.Contracts;
using Application.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace Application.Controller.IntegrationTests
{
    public class ApplicationWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder
                .ConfigureServices(services =>
                {
                    services.AddSingleton(BaseTest.TestInMemoryUserRepository);
                    services.AddSingleton(BaseTest.TestInMemoryGroupRepository);
                    services.AddSingleton<IUserSettingsService, InMemoryUserSettingsService>();
                });

        }
    }
}