using Application.Common.Rest.RestExceptions;
using Application.Controller.IntegrationTests.Api;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Application.Controller.IntegrationTests.GroupManagement
{
    public class DeleteGroupTests : GroupManagementBaseTest
    {
        [Test]
        public void DeleteNonexistedGroup()
        {
            Assert.ThrowsAsync<NotFoundException>(async () => 
                await ApplicationApi.GroupManagementApi1.DeleteGroup(Guid.NewGuid()));
        }

        [Test]
        public async Task DeleteGroup()
        {
            var addedGroup = await ApplicationApi.GroupManagementApi1.AddGroup(new Repository.Model.Group()
            {
                Name = "To delete group",
                ParentId = ParentId
            });

            Assert.That(addedGroup, Is.Not.Null);

            await ApplicationApi.GroupManagementApi1.DeleteGroup(addedGroup.Id);

            var groupExists = await TestInMemoryGroupRepository.GroupExists(addedGroup.Id);
            Assert.That(groupExists, Is.False);
        }
    }
}