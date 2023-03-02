using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAwesomeDecks.Application.Queries.GetCardsByDeck;

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

        [HttpGet("Deck/{deckId}")]
        public async Task<IActionResult> GetCardsByDeckId(Guid deckId)
        {
            var getCardsByDeckIdQuery = new GetCardsByDeckIdQuery(deckId);
            var result = await _mediator.Send(getCardsByDeckIdQuery);

            return Ok(result);
        }
    }
}
