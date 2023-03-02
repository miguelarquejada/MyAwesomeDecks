using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Moq.AutoMock;
using MyAwesomeDecks.Api.Controllers;
using MyAwesomeDecks.Application.Commands.AuthenticateUser;
using MyAwesomeDecks.Application.Commands.RegisterUser;
using MyAwesomeDecks.Domain.Dto;
using Xunit;

namespace Api.Tests.Controllers
{
    public class AuthenticationControllerTest
    {
        private readonly AutoMocker _autoMocker;

        public AuthenticationControllerTest()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task SignIn_WithValidParameter_ShouldReturnOk()
        {
            // Arrange
            _autoMocker.GetMock<IMediator>()
                .Setup(x => x.Send(It.IsAny<AuthenticateUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AuthenticationResponseDto());

            var controller = _autoMocker.CreateInstance<AuthenticationController>();

            // Act
            var result = await controller.SignIn(new AuthenticateUserCommand()) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.IsAssignableFrom<AuthenticationResponseDto>(result.Value);
        }

        [Fact]
        public async Task SignUp_WithValidParameter_ShouldReturnOk()
        {
            // Arrange
            _autoMocker.GetMock<IMediator>()
                .Setup(x => x.Send(It.IsAny<RegisterUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new AuthenticationResponseDto());

            var controller = _autoMocker.CreateInstance<AuthenticationController>();

            // Act
            var result = await controller.SignUp(new RegisterUserCommand()) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<OkObjectResult>(result);
            Assert.IsAssignableFrom<AuthenticationResponseDto>(result.Value);
        }
    }
}
