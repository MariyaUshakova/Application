using Application.Repository.Contracts;
using Application.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controller.IntegrationTests.InMemoryData
{
    internal class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new ();

        public Task<User> AddUser(User user)
        {
            user.Id = Guid.NewGuid();

            _users.Add(user);

            return Task.FromResult(user);
        }

        public Task DeleteUser(Guid id)
        {
            _users.RemoveAll(_ => _.Id == id);

            return Task.FromResult(true);
        }

        public Task<User> GetUser(Guid id)
        {
            return Task.FromResult(_users.FirstOrDefault(_ => _.Id == id));
        }

        public Task<List<User>> GetUsers()
        {
            return Task.FromResult(_users);
        }

        public Task UpdateUser(User user)
        {
            var userToUpdate = _users.FirstOrDefault(_ => _.Id == user.Id);

            userToUpdate.Name = user.Name;
            userToUpdate.Email = user.Email;

            return Task.FromResult(true);
        }

        public Task<bool> UserExists(Guid id)
        {
            return Task.FromResult(_users.Exists(_ => _.Id == id));
        }
    }
}