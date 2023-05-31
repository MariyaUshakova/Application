using Application.Repository.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Contracts
{
    public interface IGroupRepository
    {
        Task<Group> GetGroup(Guid id);
        Task<List<Group>> GetGroups();
        Task<Group> AddGroup(Group group);
        Task UpdateGroup(Group group);
        Task DeleteGroup(Guid id);
        Task<bool> GroupExists(Guid id);
        Task<List<Group>> GetChildGroups(Guid parentGroup);
    }
}