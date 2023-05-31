using Application.Common.Contracts.Rest;
using Application.Common.Rest;
using Application.Controller.IntegrationTests.Api;
using Application.Controller.IntegrationTests.InMemoryData;
using Application.Repository.Contracts;
using Serilog;

namespace Application.Controller.IntegrationTests
{
    public class BaseTest
    {
        private ApplicationWebApplicationFactory _applicationWebApplicationFactory;
        private ApplicationApi _applicationApi;

        public ApplicationApi ApplicationApi
        {
            get
            {
                if (_applicationApi != null)
                {
                    return _applicationApi;
                }

                _applicationWebApplicationFactory = new ApplicationWebApplicationFactory();

                _applicationApi = new ApplicationApi(
                    Logger, 
                    _applicationWebApplicationFactory.CreateClient(),
                    RestManager);

                return _applicationApi;
            }
        }

        protected static ILogger Logger;
        protected static IRestManager RestManager;

        public static IUserRepository TestInMemoryUserRepository = new InMemoryUserRepository();
        public static IGroupRepository TestInMemoryGroupRepository = new InMemoryGroupRepository();

        static BaseTest()
        {
            const string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{ThreadId}] [{Level:u3}] {Message:lj}{NewLine}";

            Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.WithThreadId()
                .WriteTo.Console(outputTemplate: outputTemplate)
                .WriteTo.File("Automation.log", outputTemplate: outputTemplate, rollingInterval: RollingInterval.Infinite)
                .CreateLogger();

            RestManager = new RestManager(Logger);
        }
    }
}
