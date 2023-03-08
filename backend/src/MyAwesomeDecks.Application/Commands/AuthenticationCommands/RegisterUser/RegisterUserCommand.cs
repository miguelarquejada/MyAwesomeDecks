using MediatR;
using MyAwesomeDecks.Domain.Dto;

namespace MyAwesomeDecks.Application.Commands.AuthenticationCommands.RegisterUser
{
    public class RegisterUserCommand : IRequest<AuthenticationResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
