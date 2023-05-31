using Application.Repository.Contracts;
using Application.Repository.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Repository
{
    internal class UserRepository : IUserRepository
    {
        public async Task<User> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExists(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}