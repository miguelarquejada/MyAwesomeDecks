using Microsoft.AspNetCore.Identity;
using Moq;
using Moq.AutoMock;
using MyAwesomeDecks.Domain.Dto;
using MyAwesomeDecks.Domain.Services;
using MyAwesomeDecks.Infrastructure.Exceptions;
using MyAwesomeDecks.Infrastructure.Identity;
using MyAwesomeDecks.Infrastructure.Services;
using Xunit;

namespace Infrastructure.Tests.Services
{
    public class AuthenticationServiceTest
    {
        private readonly AutoMocker _autoMocker;

        public AuthenticationServiceTest()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task SignInUser_UsetNotExists_ShouldThrowInvalidCredentialsException()
        {
            // Arrange
            _autoMocker.GetMock<UserManager<ApplicationUser>>()
                .Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync((ApplicationUser)null);

            var authenticationService = _autoMocker.CreateInstance<AuthenticationService>();


            // Act
            // Assert
            await Assert.ThrowsAsync<InvalidCredentialsException>(() => authenticationService.SignInUser(It.IsAny<string>(), It.IsAny<string>()));
        }

        [Fact]
        public async Task SignInUser_InvalidPassword_ShouldThrowInvalidCredentialsException()
        {
            // Arrange
            _autoMocker.GetMock<UserManager<ApplicationUser>>()
                .Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new ApplicationUser());

            _autoMocker.GetMock<UserManager<ApplicationUser>>()
                .Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(false);

            var authenticationService = _autoMocker.CreateInstance<AuthenticationService>();

            // Act
            // Assert
            await Assert.ThrowsAsync<InvalidCredentialsException>(() => authenticationService.SignInUser(It.IsAny<string>(), It.IsAny<string>()));
        }

        [Fact]
        public async Task SignInUser_ValidPassword_ShouldNoThrowInvalidCredentialsException()
        {
            // Arrange
            _autoMocker.GetMock<UserManager<ApplicationUser>>()
                .Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new ApplicationUser());

            _autoMocker.GetMock<UserManager<ApplicationUser>>()
                .Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            var authenticationService = _autoMocker.CreateInstance<AuthenticationService>();

            // Act
            var exception = await Record.ExceptionAsync(() => authenticationService.SignInUser(It.IsAny<string>(), It.IsAny<string>()));

            // Assert
            Assert.IsNotType<InvalidCredentialsException>(exception);
        }

        [Fact]
        public async Task SignInUser_ValidCredentials_ShouldReturnAuthenticationResponseDto()
        {
            // Arrange
            _autoMocker.GetMock<UserManager<ApplicationUser>>()
                .Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new ApplicationUser());

            _autoMocker.GetMock<UserManager<ApplicationUser>>()
                .Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            _autoMocker.GetMock<ITokenService>()
                .Setup(x => x.GerenateToken(It.IsAny<ApplicationUserDto>()))
                .Returns(It.IsAny<string>());

            var authenticationService = _autoMocker.CreateInstance<AuthenticationService>();

            // Act
            var result = await authenticationService.SignInUser(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AuthenticationResponseDto>(result);
        }

        [Fact]
        public async Task RegisterUser_WithoutErrors_ShouldReturnAuthenticationResponseDtoWithErrorsListEmpty()
        {
            // Arrange
            _autoMocker.GetMock<UserManager<ApplicationUser>>()
                .Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new ApplicationUser());

            _autoMocker.GetMock<UserManager<ApplicationUser>>()
                .Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            var authenticationService = _autoMocker.CreateInstance<AuthenticationService>();

            // Act
            var result = await authenticationService.RegisterUser(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AuthenticationResponseDto>(result);
            Assert.True(!result.Errors.Any());
        }

        [Fact]
        public async Task RegisterUser_WithErrors_ShouldReturnAuthenticationResponseDtoWithErrorsListNotEmpty()
        {
            // Arrange
            var errors = new List<IdentityError>();
            var error = new IdentityError { Code = "InvalidPassword", Description = "A senha deve conter pelo menos uma letra maiúscula." };
            errors.Add(error);

            _autoMocker.GetMock<UserManager<ApplicationUser>>()
                .Setup(x => x.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new ApplicationUser());

            _autoMocker.GetMock<UserManager<ApplicationUser>>()
                .Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Failed(errors.ToArray()));

            var authenticationService = _autoMocker.CreateInstance<AuthenticationService>();

            // Act
            var result = await authenticationService.RegisterUser(It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.NotNull(result);
            Assert.IsType<AuthenticationResponseDto>(result);
            Assert.True(result.Errors.Any());
        }
    }
}
