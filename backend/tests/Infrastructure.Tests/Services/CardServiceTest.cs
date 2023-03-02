using Moq;
using Moq.AutoMock;
using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Repositories;
using MyAwesomeDecks.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Infrastructure.Tests.Services
{
    public class CardServiceTest
    {
        private readonly AutoMocker _autoMocker;

        public CardServiceTest()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public void GetDecksByUserId_WithValidParameter_ShouldReturnIQueryable()
        {
            // Arrange
            _autoMocker.GetMock<ICardRepository>()
                .Setup(x => x.GetCardsByDeckId(It.IsAny<Guid>()))
                .Returns(new List<Card>().AsQueryable());

            var service = _autoMocker.CreateInstance<CardService>();

            // Act
            var result = service.GetCardsByDeckId(Guid.NewGuid());

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IQueryable<Card>>(result);
        }
    }
}
