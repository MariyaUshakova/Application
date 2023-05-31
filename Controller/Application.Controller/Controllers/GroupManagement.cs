using Application.Repository.Contracts;
using Application.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Application.Controller.Controllers
{
    //[ApiController]
    //[Route("GroupManagement")]
    public class GroupManagement : ControllerBase
    {
        public ILogger _logger;
        public IGroupRepository _groupRepository;

        public GroupManagement(
            ILogger logger,
            IGroupRepository groupRepository)
        {
            _logger = logger;
            _groupRepository = groupRepository;
        }

        [HttpGet("{groupId}")]
        public async Task<IActionResult> GetGroup([FromRoute] Guid groupId)
        {
            _logger.Debug($"Get group {groupId}");

            var group = await _groupRepository.GetGroup(groupId);

            if (group == null)
            {
                _logger.Debug($"Group with id = '{groupId}' not found.");

                return NotFound();
            }

            _logger.Debug($"Get group {groupId} successfully.");

            return Ok(group);
        }

        [HttpGet("groups")]
        public async Task<IActionResult> GetGroups()
        {
            _logger.Debug($"Get all groups");

            var groups = await _groupRepository.GetGroups();

            _logger.Debug($"Get groups successfully.");

            return Ok(groups);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddGroup([FromBody] Group group)
        {
            _logger.Debug($"Add group..");

            if (!await IsValid(group))
            {
                return BadRequest();
            }

            var addedGroup = await _groupRepository.AddGroup(group);

            _logger.Debug($"Group added successfully (id = {group.Id}).");

            return Ok(addedGroup);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateGroup([FromBody] Group group)
        {
            _logger.Debug($"Update group..");

            if (!await _groupRepository.GroupExists(group.Id))
            {
                return NotFound();
            }

            if (! await IsValid(group))
            {
                return BadRequest();
            }

            await _groupRepository.UpdateGroup(group);

            _logger.Debug($"Group '{group.Id}' updated successfully.");

            return Ok();
        }

        [HttpDelete("{groupId}")]
        public async Task<IActionResult> DeleteGroup([FromRoute] Guid groupId)
        {
            _logger.Debug($"Delete group..");

            if (!await _groupRepository.GroupExists(groupId))
            {
                return NotFound();
            }

            await _groupRepository.DeleteGroup(groupId);

            _logger.Debug($"Group '{groupId}' deleted successfully.");

            return Ok();
        }

        private async Task<bool> IsValid(Group group)
        {
            if (string.IsNullOrEmpty(group.Name))
            {
                return false;
            }

            if (group.ParentId != Guid.Empty && await _groupRepository.GroupExists(group.ParentId))
            {
                return false;
            }

            return true;
        }
    }
}