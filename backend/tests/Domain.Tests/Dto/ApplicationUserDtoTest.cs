﻿using MyAwesomeDecks.Domain.Dto;
using Xunit;

namespace Domain.Tests.Dto
{
    public class ApplicationUserDtoTest
    {
        [Fact]
        public void GetUsernameOrEmptyString_UsernameIsNotNull_ShouldReturnUsername()
        {
            // Arrange
            var applicationUserDto = new ApplicationUserDto();
            applicationUserDto.UserName = "Zorro";

            // Act
            var result = applicationUserDto.GetUsernameOrEmptyString();

            // Assert
            Assert.NotEmpty(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetUsernameOrEmptyString_UsernameIsNull_ShouldReturnEmptyString()
        {
            // Arrange
            var applicationUserDto = new ApplicationUserDto();

            // Act
            var result = applicationUserDto.GetUsernameOrEmptyString();

            // Assert
            Assert.Empty(result);
            Assert.NotNull(result);
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