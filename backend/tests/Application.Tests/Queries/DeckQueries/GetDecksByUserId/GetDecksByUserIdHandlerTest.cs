using Moq.AutoMock;
using Moq;
using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Services;
using Xunit;
using MyAwesomeDecks.Application.Queries.DeckQueries.GetDecksByUserId;

namespace Application.Tests.Queries.DeckQueries.GetDecksByUserId
{
    public class GetDecksByUserIdHandlerTest
    {
        private readonly AutoMocker _autoMocker;

        public GetDecksByUserIdHandlerTest()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task Handle_WithValidParameters_ShouldReturnIEnumerableOfCard()
        {
            // Arrange
            _autoMocker.GetMock<IDeckService>()
                .Setup(x => x.GetDecksByUserId(It.IsAny<Guid>()))
                .Returns(new List<Deck>().AsQueryable());

            var handler = _autoMocker.CreateInstance<GetDecksByUserIdHandler>();

            var parameter = new GetDecksByUserIdQuery(Guid.NewGuid());

            // Act
            var result = await handler.Handle(parameter, It.IsAny<CancellationToken>());

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Deck>>(result);
        }
    }
}
