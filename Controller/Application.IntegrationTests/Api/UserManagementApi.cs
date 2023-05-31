using Application.Common.Contracts.Rest;
using Application.Repository.Model;
using Ardalis.GuardClauses;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Application.Controller.IntegrationTests.Api
{
    public class UserManagementApi : BaseApi
    {
        public override string ControllerName => "UserManagement";

        public UserManagementApi(ILogger logger, HttpClient client, IRestManager restManager, int version) : 
            base(logger, client, restManager, version)
        {
        }

        public async Task<User> GetUser(Guid userId)
        {
            _logger.Verbose($"Get user '{userId}'");

            var pathParameters = new Dictionary<string, object>
            {
                { "userId", userId }
            };

            var result = await _restManager.Execute<User>(
                client: _client,
                method: Common.Types.RestMethod.Get,
                resource: WrapResourcePath("{userId}"),
                pathParameters: pathParameters);

            _logger.Verbose($"User retrieved successfully");

            return result;
        }

        public async Task<List<User>> GetUsers()
        {
            _logger.Verbose($"Get users");

            var result = await _restManager.Execute<List<User>>(
                client: _client,
                method: Common.Types.RestMethod.Get,
                resource: WrapResourcePath("users"));

            _logger.Verbose($"Users retrieved successfully");

            return result;
        }

        public async Task<User> AddUser(User user)
        {
            Guard.Against.Null(user, "User not defined");

            _logger.Verbose($"Add user (name = '{user.Name}', email = {user.Email})");

            var result = await _restManager.Execute<User>(
                client: _client,
                method: Common.Types.RestMethod.Post,
                resource: WrapResourcePath(""),
                body: user);

            _logger.Verbose($"User added successfully");

            return result;
        }

        public async Task DeleteUser(Guid userId)
        {
            _logger.Verbose($"Delete user (id = '{userId}')");

            await _restManager.Execute(
                client: _client,
                method: Common.Types.RestMethod.Delete,
                resource: WrapResourcePath("{userId}"));

            _logger.Verbose($"User removed successfully");
        }
    }
}