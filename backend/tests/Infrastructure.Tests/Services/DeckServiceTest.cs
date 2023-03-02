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
    public class DeckServiceTest
    {
        private readonly AutoMocker _autoMocker;

        public DeckServiceTest()
        {
            _autoMocker= new AutoMocker();
        }

        [Fact]
        public void GetDecksByUserId_WithValidParameter_ShouldReturnIQueryable()
        {
            // Arrange
            _autoMocker.GetMock<IDeckRepository>()
                .Setup(x => x.GetDecksByUserId(It.IsAny<Guid>()))
                .Returns(new List<Deck>().AsQueryable());

            var service = _autoMocker.CreateInstance<DeckService>();

            // Act
            var result = service.GetDecksByUserId(Guid.NewGuid());

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IQueryable<Deck>>(result);
        }
    }
}
