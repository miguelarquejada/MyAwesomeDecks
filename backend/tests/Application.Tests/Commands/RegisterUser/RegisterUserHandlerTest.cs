﻿using Moq.AutoMock;
using Moq;
using MyAwesomeDecks.Application.Commands.AuthenticateUser;
using MyAwesomeDecks.Domain.Dto;
using MyAwesomeDecks.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MyAwesomeDecks.Application.Commands.RegisterUser;

namespace Application.Tests.Commands.RegisterUser
{
    public class RegisterUserHandlerTest
    {
        private readonly AutoMocker _autoMocker;

        public RegisterUserHandlerTest()
        {
            _autoMocker = new AutoMocker();
        }

        [Fact]
        public async Task Handle_WithValidParameters_ShouldReturnAuthenticationResponseDto()
        {
            // Arrange
            _autoMocker.GetMock<IAuthenticationService>()
                .Setup(x => x.RegisterUser(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new AuthenticationResponseDto());

            var handler = _autoMocker.CreateInstance<RegisterUserHandler>();

            var parameter = new RegisterUserCommand();
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
