using System;
using System.Threading.Tasks;
using Catalog.Api.Controllers;
using Catalog.Api.Models;
using Catalog.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Catalog.UnitTest
{
    public class ItemsControllerTest
    {
        [Fact]
        public async Task GetItem_WithUnexistingItem_ReturnsNotFound()
        {
            // Arrange
            var repositoryStub = new Mock<IItemsRepository>();
            repositoryStub.Setup(repo => repo.GetItem(It.IsAny<Guid>()))
                .ReturnsAsync((Item) null);

            var controller = new ItemsController(repositoryStub.Object);
            
            // Act
            var result = await controller.GetItem(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
