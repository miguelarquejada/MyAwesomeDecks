using MyAwesomeDecks.Domain.Dto;
using Xunit;

namespace Domain.Tests.Dto
{
    public class SignInResponseDtoTest
    {
        [Fact]
        public void Constructor_WithIdAndAndEmail_ShouldBuildObject()
        {
            // Arrange
            var user = new ApplicationUserDto(Guid.NewGuid(), "zorro@gmail.com");
            var token = "aa";

            // Act
            var signInResponseDto = new AuthenticationResponseDto(user, token);

            // Assert
            Assert.True(token == signInResponseDto.Token);
            Assert.True(user.Email == signInResponseDto.User.Email);
        }
    }
}
