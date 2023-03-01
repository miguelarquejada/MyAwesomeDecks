﻿using MediatR;
using MyAwesomeDecks.Domain.Dto;

namespace MyAwesomeDecks.Application.Commands.AuthenticateUser
{
    public class AuthenticateUserCommand : IRequest<AuthenticationResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
