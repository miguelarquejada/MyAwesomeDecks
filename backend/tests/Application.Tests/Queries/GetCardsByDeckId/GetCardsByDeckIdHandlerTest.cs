using Moq;
using Moq.AutoMock;
using MyAwesomeDecks.Application.Queries.GetCardsByDeck;
using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Services;
using Xunit;

namespace Application.Tests.Queries.GetCardsByDeckId
{
    public class GetCardsByDeckIdHandlerTest
    {
        private readonly AutoMocker _autoMocker;

        public GetCardsByDeckIdHandlerTest()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task Handle_WithValidParameters_ShouldReturnIEnumerableOfCard()
        {
            // Arrange
            _autoMocker.GetMock<ICardService>()
                .Setup(x => x.GetCardsByDeckId(It.IsAny<Guid>()))
                .Returns(new List<Card>().AsQueryable());

            var handler = _autoMocker.CreateInstance<GetCardsByDeckIdHandler>();

            var parameter = new GetCardsByDeckIdQuery(Guid.NewGuid());

            // Act
            var result = await handler.Handle(parameter, It.IsAny<CancellationToken>());

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<Card>>(result);
        }
    }
}
