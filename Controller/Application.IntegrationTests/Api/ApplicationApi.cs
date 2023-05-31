using Application.Common.Contracts.Rest;
using Serilog;
using System.Net.Http;

namespace Application.Controller.IntegrationTests.Api
{
    public class ApplicationApi
    {
        private readonly ILogger _logger;
        private readonly HttpClient _client;
        private readonly IRestManager _restManager;

        private UserManagementApi _userManagmentApi;
        private GroupManagementApi _groupManagementApi;

        public ApplicationApi(ILogger logger, HttpClient client, IRestManager restManager)
        {
            _logger = logger;
            _client = client;
            _restManager = restManager;
        }

        public UserManagementApi UserManagementApi1 => _userManagmentApi ??= 
            new UserManagementApi(_logger, _client, _restManager, 1);

        public GroupManagementApi GroupManagementApi1 => _groupManagementApi ??=
            new GroupManagementApi(_logger, _client, _restManager, 1);
    }
}