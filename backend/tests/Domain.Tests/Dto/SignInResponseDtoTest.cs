using MyAwesomeDecks.Domain.Dto;
using Xunit;

namespace Domain.Tests.Dto
{
    public class SignInResponseDtoTest
    {
        [Fact]
        public void Constructor_WithIdAndUsernameAndEmail_ShouldBuildObject()
        {
            // Arrange
            var user = new ApplicationUserDto();
            user.UserName = "zorro";

            var token = "aa";

            // Act
            var signInResponseDto = new AuthenticationResponseDto(user, token);

            // Assert
            Assert.True(token == signInResponseDto.Token);
            Assert.True(user.UserName == signInResponseDto.User.UserName);
        }
    }
}
