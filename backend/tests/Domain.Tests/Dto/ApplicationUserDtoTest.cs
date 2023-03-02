using MyAwesomeDecks.Domain.Dto;
using Xunit;

namespace Domain.Tests.Dto
{
    public class ApplicationUserDtoTest
    {
        [Fact]
        public void Constructor_WithIdAndEmail_ShouldBuildObject()
        {
            // Arrange
            var id = Guid.NewGuid();
            var email = "zorro@gmail.com";

            // Act
            var userDto = new ApplicationUserDto(id, email);

            // Assert
            Assert.True(userDto.Id == id);
            Assert.True(userDto.Email == email);
        }


        [Fact]
        public void GetEmailOrEmptyString_EmailIsNotNull_ShouldReturnEmail()
        {
            // Arrange
            var applicationUserDto = new ApplicationUserDto();
            applicationUserDto.Email = "zorro@gmail.com";

            // Act
            var result = applicationUserDto.GetEmailOrEmptyString();

            // Assert
            Assert.NotEmpty(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetEmailOrEmptyString_EmailIsNull_ShouldReturnEmptyString()
        {
            // Arrange
            var applicationUserDto = new ApplicationUserDto();

            // Act
            var result = applicationUserDto.GetEmailOrEmptyString();

            // Assert
            Assert.Empty(result);
            Assert.NotNull(result);
        }
    }
}
