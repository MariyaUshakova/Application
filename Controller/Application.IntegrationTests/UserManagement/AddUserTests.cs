using Application.Common.Rest.RestExceptions;
using Application.Repository.Model;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Application.Controller.IntegrationTests.UserManagement
{
    public class AddUserTests : UserManagementBaseTest
    {
        public const string Email = "adduser@dot.com";

        [Test]
        public async Task AddUser()
        {
            const string name = "Add user";

            var addedUser = await ApplicationApi.UserManagementApi1.AddUser(new User()
            {
                Name = name,
                Email = Email
            });

            Assert.That(addedUser, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(addedUser.Name, Is.EqualTo(name));
                Assert.That(addedUser.Email, Is.EqualTo(Email));
                Assert.That(addedUser.Id, Is.Not.EqualTo(Guid.Empty));
            });

            var addedUserInDb = await TestInMemoryUserRepository.GetUser(addedUser.Id);

            Assert.That(addedUserInDb, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(addedUserInDb.Name, Is.EqualTo(name));
                Assert.That(addedUserInDb.Email, Is.EqualTo(Email));
            });
        }

        [Test]
        public void AddUserWrongName()
        {
            Assert.ThrowsAsync<BadRequestException>(async () => 
                await ApplicationApi.UserManagementApi1.AddUser(new User()
            {
                Name = "",
                Email = Email
                }));
        }
    }
}