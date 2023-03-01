﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAwesomeDecks.Application.Commands.AuthenticateUser;
using MyAwesomeDecks.Application.Commands.RegisterUser;

namespace MyAwesomeDecks.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn(AuthenticateUserCommand authenticateUserCommand)
        {
            var result = await _mediator.Send(authenticateUserCommand);
            return Ok(result);
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp(RegisterUserCommand registerUserCommand)
        {
            var result = await _mediator.Send(registerUserCommand);
            return Ok(result);
        }
    }
}