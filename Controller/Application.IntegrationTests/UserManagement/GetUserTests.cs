using Application.Common.Rest.RestExceptions;
using Application.Controller.IntegrationTests.Api;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Controller.IntegrationTests.UserManagement
{
    public class GetUserTests : UserManagementBaseTest
    {
        [Test]
        public void GetNonexistedUser()
        {
            Assert.ThrowsAsync<NotFoundException>(async () =>
                await ApplicationApi.UserManagementApi1.GetUser(Guid.NewGuid()));
        }

        [Test]
        public async Task GetUsers()
        {
            await ApplicationApi.UserManagementApi1.AddUser(new Repository.Model.User()
            {
                 Name = "Tuzik",
                 Email = "tuzik@dot.com"
            });

            var actualUsers = await ApplicationApi.UserManagementApi1.GetUsers();
            Assert.That(actualUsers, Is.Not.Null);

            var expectedUsers = await TestInMemoryUserRepository.GetUsers();

            Assert.That(actualUsers, Has.Count.EqualTo(expectedUsers.Count));
            Assert.That(actualUsers.TrueForAll(_ => expectedUsers.Any(__ => _.Id == _.Id)), Is.True);
        }
    }
}
