using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using MyAwesomeDecks.Api.Controllers;
using MyAwesomeDecks.Application.Commands.CardCommands.CreateCard;
using MyAwesomeDecks.Application.Commands.CardCommands.DeleteCard;
using MyAwesomeDecks.Application.Commands.CardCommands.UpdateCard;
using MyAwesomeDecks.Application.Queries.CardQueries.GetCardsByDeckId;
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
            var mediatorMock = _autoMocker.GetMock<IMediator>();

            mediatorMock
                .Setup(x => x.Send(It.IsAny<GetCardsByDeckIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Card>());

            var controller = _autoMocker.CreateInstance<CardController>();

            // Act
            var result = await controller.GetCardsByDeckId(It.IsAny<Guid>()) as OkObjectResult;

            // Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<GetCardsByDeckIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Card>>(result.Value);
        }

        [Fact]
        public async Task CreateCard_WithValidParameter_ShouldReturnOk()
        {
            // Arrange
            var mediatorMock = _autoMocker.GetMock<IMediator>();

            mediatorMock
                .Setup(x => x.Send(It.IsAny<CreateCardCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Card());

            var controller = _autoMocker.CreateInstance<CardController>();

            // Act
            var result = await controller.CreateCard(It.IsAny<CreateCardCommand>()) as OkObjectResult;

            // Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<CreateCardCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.IsAssignableFrom<Card>(result.Value);
        }

        [Fact]
        public async Task UpdateCard_WithValidParameter_ShouldReturnOk()
        {
            // Arrange
            var mediatorMock = _autoMocker.GetMock<IMediator>();

            mediatorMock
                .Setup(x => x.Send(It.IsAny<UpdateCardCommand>(), It.IsAny<CancellationToken>()));

            var controller = _autoMocker.CreateInstance<CardController>();

            // Act
            var result = await controller.UpdateCard(It.IsAny<Guid>(), new UpdateCardCommand()) as OkResult;

            // Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<UpdateCardCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkResult>(result);
        }

        [Fact]
        public async Task DeleteCardById_WithValidParameter_ShouldReturnOk()
        {
            // Arrange
            var mediatorMock = _autoMocker.GetMock<IMediator>();

            mediatorMock
                .Setup(x => x.Send(It.IsAny<DeleteCardCommand>(), It.IsAny<CancellationToken>()));

            var controller = _autoMocker.CreateInstance<CardController>();

            // Act
            var result = await controller.DeleteCardById(It.IsAny<Guid>()) as OkResult;

            // Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<DeleteCardCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkResult>(result);
        }
    }
}
