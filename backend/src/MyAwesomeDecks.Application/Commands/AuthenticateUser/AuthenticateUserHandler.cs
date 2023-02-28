using MediatR;
using MyAwesomeDecks.Domain.Dto;
using MyAwesomeDecks.Domain.Services;

namespace MyAwesomeDecks.Application.Commands.AuthenticateUser
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, string>
    {
        private readonly ITokenService _tokenService;

        public AuthenticateUserHandler(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public async Task<string> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUserDto();
            user.Id = Guid.NewGuid();
            user.UserName = "miguel";
            user.Email = "miguel@gmail.com";

            return _tokenService.GerenateToken(user);
        }
    }
}
