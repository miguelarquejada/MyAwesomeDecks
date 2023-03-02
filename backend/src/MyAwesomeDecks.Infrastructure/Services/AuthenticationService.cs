using Microsoft.AspNetCore.Identity;
using MyAwesomeDecks.Domain.Dto;
using MyAwesomeDecks.Domain.Services;
using MyAwesomeDecks.Infrastructure.Exceptions;
using MyAwesomeDecks.Infrastructure.Identity;

namespace MyAwesomeDecks.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthenticationService(UserManager<ApplicationUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AuthenticationResponseDto> SignInUser(string email, string password)
        {
            await CheckCredentials(email, password);
            var result = await GetResponse(email);
            return result;
        }

        public async Task<AuthenticationResponseDto> RegisterUser(string email, string password)
        {
            var result = await CreateUser(email, password);
            return result;
        }

        private async Task CheckCredentials(string username, string userPassword)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                throw new InvalidCredentialsException();

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, userPassword);
            if (!isPasswordCorrect)
                throw new InvalidCredentialsException();
        }

        private async Task<ApplicationUserDto> GetUserByUsernameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var result = new ApplicationUserDto(Guid.Parse(user.Id), user.Email);

            return result;
        }

        private async Task<AuthenticationResponseDto> GetResponse(string email)
        {
            var user = await GetUserByUsernameAsync(email);
            var token = _tokenService.GerenateToken(user);
            var result = new AuthenticationResponseDto(user, token);

            return result;
        }

        private async Task<AuthenticationResponseDto> CreateUser(string email, string password)
        {
            var userToSave = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            var userManagerResult = await _userManager.CreateAsync(userToSave, password);

            AuthenticationResponseDto result;
            if (!userManagerResult.Succeeded)
            {
                result = new AuthenticationResponseDto();
                foreach (var item in userManagerResult.Errors)
                    result.Errors.Add(item.Description);

                return result;
            }

            result = await GetResponse(email);
            return result;
        }
    }
}
