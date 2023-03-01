using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAwesomeDecks.Application.Queries.GetDecks;

namespace MyAwesomeDecks.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class CardController : Controller
    {
        private readonly IMediator _mediator;

        public CardController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
