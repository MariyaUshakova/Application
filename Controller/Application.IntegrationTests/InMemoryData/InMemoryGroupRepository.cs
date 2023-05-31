using Application.Repository.Contracts;
using Application.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controller.IntegrationTests.InMemoryData
{
    internal class InMemoryGroupRepository : IGroupRepository
    {
        private readonly List<Group> _groups = new();

        public async Task<Group> AddGroup(Group group)
        {
            group.Id = Guid.NewGuid();

            _groups.Add(group);

            return group;
        }

        public async Task DeleteGroup(Guid id)
        {
            _groups.RemoveAll(_ => _.Id == id);
        }

        public async Task<List<Group>> GetChildGroups(Guid parentGroup)
        {
            throw new NotImplementedException();
        }

        public async Task<Group> GetGroup(Guid id) =>
            _groups.FirstOrDefault(_ => _.Id == id);

        public async Task<List<Group>> GetGroups() => _groups;

        public async Task<bool> GroupExists(Guid id) => 
            _groups.Exists(_ => _.Id == id);

        public async Task UpdateGroup(Group group)
        {
            throw new NotImplementedException();
        }
    }
}
