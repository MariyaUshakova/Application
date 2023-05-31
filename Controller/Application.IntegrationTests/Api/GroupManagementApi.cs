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
    public class GroupManagementApi : BaseApi
    {
        public override string ControllerName => "GroupManagement";

        public GroupManagementApi(ILogger logger, HttpClient client, IRestManager restManager, int version) :
            base(logger, client, restManager, version)
        {
        }

        public async Task<Group> GetGroup(Guid groupId)
        {
            _logger.Verbose($"Get group '{groupId}'");

            var pathParameters = new Dictionary<string, object>
            {
                { "groupId", groupId }
            };

            var result = await _restManager.Execute<Group>(
                client: _client,
                method: Common.Types.RestMethod.Get,
                resource: WrapResourcePath("{groupId}"),
                pathParameters: pathParameters);

            _logger.Verbose($"Group retrieved successfully");

            return result;
        }

        public async Task<Group> AddGroup(Group group)
        {
            Guard.Against.Null(group, "Group not defined");

            _logger.Verbose($"Add group (name = '{group.Name}', parent group = {group.ParentId})");

            var result = await _restManager.Execute<Group>(
                client: _client,
                method: Common.Types.RestMethod.Post,
                resource: WrapResourcePath(""),
                body: group);

            _logger.Verbose($"Group added successfully");

            return result;
        }

        public async Task DeleteGroup(Guid groupId)
        {
            _logger.Verbose($"Delete group '{groupId}'");

            var pathParameters = new Dictionary<string, object>
            {
                { "groupId", groupId }
            };

            await _restManager.Execute(
                client: _client,
                method: Common.Types.RestMethod.Delete,
                pathParameters: pathParameters,
                resource: WrapResourcePath("{groupId}"
                ));

            _logger.Verbose($"Group deleted successfully");
        }
    }
}
