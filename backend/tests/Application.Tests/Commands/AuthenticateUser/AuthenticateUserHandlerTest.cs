using Moq;
using Moq.AutoMock;
using MyAwesomeDecks.Application.Commands.AuthenticationCommands.AuthenticateUser;
using MyAwesomeDecks.Domain.Dto;
using MyAwesomeDecks.Domain.Services;
using Xunit;

namespace Application.Tests.Commands.AuthenticateUser
{
    public class AuthenticateUserHandlerTest
    {
        private readonly AutoMocker _autoMocker;

        public AuthenticateUserHandlerTest()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task Handle_WithValidParameters_ShouldReturnAuthenticationResponseDto()
        {
            // Arrange
            _autoMocker.GetMock<IAuthenticationService>()
                .Setup(x => x.SignInUser(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new AuthenticationResponseDto());

            var handler = _autoMocker.CreateInstance<AuthenticateUserHandler>();

            var parameter = new AuthenticateUserCommand();
            parameter.Email = "zorro@gmail.com";
            parameter.Password = "zorro123";

            // Act
            var result = await handler.Handle(parameter, It.IsAny<CancellationToken>());


            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<AuthenticationResponseDto>(result);
        }
    }
}
