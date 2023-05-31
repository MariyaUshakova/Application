using Application.Controller.Exceptions;
using Application.Repository.Contracts;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Application.Controller.Extensions
{
    public class MyBl
    {
        private ILogger _logger;
        private IGroupRepository _groupRepository;

        public MyBl(ILogger logger, IGroupRepository groupRepository)
        {
            _logger = logger;
            _groupRepository = groupRepository;
        }

        public async Task DeleteGroup(Guid groupId)
        {
            _logger.Debug($"Delete group '{groupId}'..");

            if (!await _groupRepository.GroupExists(groupId))
            {
                _logger.Error($"Wrong group id '{groupId}'.");

                throw new GroupDoesNotExistException($"Group {groupId} does not exist");
            }

            await _groupRepository.DeleteGroup(groupId);

            _logger.Debug($"Group deleted successfully (id = {groupId}).");
        }
    }
}
