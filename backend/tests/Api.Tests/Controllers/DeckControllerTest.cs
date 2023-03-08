using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using Moq;
using MyAwesomeDecks.Api.Controllers;
using MyAwesomeDecks.Domain.Entities;
using Xunit;
using MyAwesomeDecks.Application.Queries.DeckQueries.GetDecksByUserId;
using MyAwesomeDecks.Application.Commands.DeckCommands.CreateDeck;
using MyAwesomeDecks.Application.Commands.DeckCommands.UpdateDeck;
using MyAwesomeDecks.Application.Commands.DeckCommands.DeleteDeck;

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
            var mediatorMock = _autoMocker.GetMock<IMediator>();

            mediatorMock
                .Setup(x => x.Send(It.IsAny<GetDecksByUserIdQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Deck>());

            var controller = _autoMocker.CreateInstance<DeckController>();

            // Act
            var result = await controller.GetAllByUserId(It.IsAny<Guid>()) as OkObjectResult;

            // Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<GetDecksByUserIdQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.IsAssignableFrom<IEnumerable<Deck>>(result.Value);
        }

        [Fact]
        public async Task CreateDeck_WithValidParameter_ShouldReturnOk()
        {
            // Arrange
            var mediatorMock = _autoMocker.GetMock<IMediator>();

            mediatorMock
                .Setup(x => x.Send(It.IsAny<CreateDeckCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Deck());

            var controller = _autoMocker.CreateInstance<DeckController>();

            // Act
            var result = await controller.CreateDeck(It.IsAny<CreateDeckCommand>()) as OkObjectResult;

            // Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<CreateDeckCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.IsAssignableFrom<Deck>(result.Value);
        }

        [Fact]
        public async Task UpdateDeck_WithValidParameter_ShouldReturnOk()
        {
            // Arrange
            var mediatorMock = _autoMocker.GetMock<IMediator>();

            mediatorMock
                .Setup(x => x.Send(It.IsAny<UpdateDeckCommand>(), It.IsAny<CancellationToken>()));

            var controller = _autoMocker.CreateInstance<DeckController>();

            // Act
            var result = await controller.UpdateDeck(It.IsAny<Guid>(), new UpdateDeckCommand()) as OkResult;

            // Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<UpdateDeckCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkResult>(result);
        }

        [Fact]
        public async Task DeleteDeckById_WithValidParameter_ShouldReturnOk()
        {
            // Arrange
            var mediatorMock = _autoMocker.GetMock<IMediator>();

            mediatorMock
                .Setup(x => x.Send(It.IsAny<DeleteDeckCommand>(), It.IsAny<CancellationToken>()));

            var controller = _autoMocker.CreateInstance<DeckController>();

            // Act
            var result = await controller.DeleteDeckById(It.IsAny<Guid>()) as OkResult;

            // Assert
            mediatorMock.Verify(x => x.Send(It.IsAny<DeleteDeckCommand>(), It.IsAny<CancellationToken>()), Times.Once);
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkResult>(result);
        }
    }
}
