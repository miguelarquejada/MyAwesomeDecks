using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAwesomeDecks.Application.Queries.GetDecks;

namespace MyAwesomeDecks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardController : Controller
    {
        private readonly IMediator _mediator;

        public CardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetDecksQuery());
            return Ok(result);
        }
    }
}
