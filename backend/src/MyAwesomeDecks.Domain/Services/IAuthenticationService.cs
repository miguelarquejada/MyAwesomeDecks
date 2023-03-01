using MyAwesomeDecks.Domain.Dto;

namespace MyAwesomeDecks.Domain.Services
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseDto> SignInUser(string email, string password);
        Task<AuthenticationResponseDto> RegisterUser(string email, string password);
    }
}
