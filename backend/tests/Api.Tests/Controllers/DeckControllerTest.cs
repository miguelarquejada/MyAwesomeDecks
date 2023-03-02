using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using Moq;
using MyAwesomeDecks.Api.Controllers;
using MyAwesomeDecks.Domain.Entities;
using Xunit;
using MyAwesomeDecks.Application.Queries.GetDecks;

namespace Api.Tests.Controllers
{
    public class DeckControllerTest
    {
        private readonly AutoMocker _autoMocker;

        public DeckControllerTest()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task GetAllByUserId_WithValidParameter_ShouldReturnOk()
        {
            // Arrange
            _autoMocker.GetMock<IMediator>()
                .Setup(x => x.Send(It.IsAny<GetDecksByUserIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Deck>());

            var controller = _autoMocker.CreateInstance<DeckController>();

            // Act
            var result = await controller.GetAllByUserId(It.IsAny<Guid>()) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Deck>>(result.Value);
        }
    }
}
