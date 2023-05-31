using Application.Repository.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository.Contracts
{
    public interface IUserRepository
    {
        Task<User> GetUser(Guid id);
        Task<List<User>> GetUsers();
        Task<User> AddUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(Guid id);
        Task<bool> UserExists(Guid id);
    }
}