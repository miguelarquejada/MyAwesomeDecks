using MediatR;
using MyAwesomeDecks.Domain.Dto;
using MyAwesomeDecks.Domain.Services;

namespace MyAwesomeDecks.Application.Commands.DeckCommands.RegisterUser
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, AuthenticationResponseDto>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterUserHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<AuthenticationResponseDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.RegisterUser(request.Email, request.Password);
            return result;
        }
    }
}
