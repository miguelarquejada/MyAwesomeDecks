using MediatR;
using MyAwesomeDecks.Domain.Dto;
using MyAwesomeDecks.Domain.Services;

namespace MyAwesomeDecks.Application.Commands.AuthenticateUser
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, AuthenticationResponseDto>
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticateUserHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<AuthenticationResponseDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.SignInUser(request.Email, request.Password);
            return result;
        }
    }
}
