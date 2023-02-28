using MyAwesomeDecks.Domain.Dto;

namespace MyAwesomeDecks.Domain.Services
{
    public interface ITokenService
    {
        string GerenateToken(ApplicationUserDto user);
    }
}
