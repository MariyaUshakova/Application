using Application.Controller.Controllers;
using Application.Repository.Contracts;
using Application.Repository.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Application.Controller.UnitTests.GroupController
{
    public class BaseGroupTest
    {
        public const string name = "Group";

        public GroupManagement Controller;

        [SetUp]
        public void Setup()
        {
            // Arrange

            var group = new Group()
            {
                ParentId = Guid.Empty,
                Name = name
            };

            var mockedGroupRepository = new Mock<IGroupRepository>();
            mockedGroupRepository.Setup(_ => _.AddGroup(It.IsAny<Group>())).Returns(Task.FromResult(group));

            Controller = new GroupManagement(Mock.Of<ILogger>(), mockedGroupRepository.Object);
        }
    }


    public class AddRootGroupTests : BaseGroupTest
    {
        [Test]
        public async Task AddRootGroup()
        {
            // Act

            var result = await Controller.AddGroup(new Group()
            {
                Name = name,
                ParentId = Guid.Empty
            }) as OkObjectResult;

            // Assert

            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(200));
        }
    }

    public class AddGroupUndefinedNameTests : BaseGroupTest
    {
        [Test]
        public async Task AddUndefinedNameGroup()
        {
            // Act

            var result = await Controller.AddGroup(new Group()
            {
                Name = null,
                ParentId = Guid.Empty
            }) as BadRequestResult;

            // Assert

            Assert.That(result, Is.Not.Null);
            Assert.That(result.StatusCode, Is.EqualTo(400));
        }
    }
}
