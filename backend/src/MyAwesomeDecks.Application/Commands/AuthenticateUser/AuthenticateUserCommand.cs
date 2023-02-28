using MediatR;

namespace MyAwesomeDecks.Application.Commands.AuthenticateUser
{
    public class AuthenticateUserCommand : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
