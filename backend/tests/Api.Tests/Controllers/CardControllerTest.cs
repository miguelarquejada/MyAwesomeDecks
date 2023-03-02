using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using MyAwesomeDecks.Api.Controllers;
using MyAwesomeDecks.Application.Queries.GetCardsByDeck;
using MyAwesomeDecks.Domain.Entities;
using Xunit;

namespace Api.Tests.Controllers
{
    public class CardControllerTest
    {
        private readonly AutoMocker _autoMocker;

        public CardControllerTest()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task GetCardsByDeckId_WithValidParameter_ShouldReturnOk()
        {
            // Arrange
            _autoMocker.GetMock<IMediator>()
                .Setup(x => x.Send(It.IsAny<GetCardsByDeckIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Card>());

            var controller = _autoMocker.CreateInstance<CardController>();

            // Act
            var result = await controller.GetCardsByDeckId(It.IsAny<Guid>()) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Card>>(result.Value);
        }
    }
}
