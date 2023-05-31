using Application.Repository.Model;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Application.Controller.IntegrationTests.GroupManagement
{
    public class AddGroupTest : GroupManagementBaseTest
    {
        [Test]
        public async Task AddGroup()
        {
            const string name = "Add group";

            var addedGroup = await ApplicationApi.GroupManagementApi1.AddGroup(new Group()
            {
                Name = name,
                ParentId = ParentId
            });

            Assert.That(addedGroup, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(addedGroup.Name, Is.EqualTo(name));
                Assert.That(addedGroup.ParentId, Is.EqualTo(ParentId));
                Assert.That(addedGroup.Id, Is.Not.EqualTo(Guid.Empty));
                Assert.That(addedGroup.Id, Is.Not.EqualTo(ParentId));
            });

            var addedGroupInDb = await TestInMemoryGroupRepository.GetGroup(addedGroup.Id);

            Assert.That(addedGroupInDb, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(addedGroupInDb.Name, Is.EqualTo(name));
                Assert.That(addedGroupInDb.Id, Is.EqualTo(addedGroup.Id));
                Assert.That(addedGroupInDb.ParentId, Is.EqualTo(ParentId));
            });
        }
    }
}