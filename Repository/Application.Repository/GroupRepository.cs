using Application.Repository.Contracts;
using Application.Repository.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    internal class GroupRepository : IGroupRepository
    {
        public async Task<Group> AddGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteGroup(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Group> GetGroup(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Group>> GetGroups()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GroupExists(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGroup(Group group)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Group>> GetChildGroups(Guid parentGroup)
        {
            throw new NotImplementedException();
        }
    }
}