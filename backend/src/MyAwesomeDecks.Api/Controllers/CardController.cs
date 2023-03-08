using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAwesomeDecks.Application.Commands.CardCommands.CreateCard;
using MyAwesomeDecks.Application.Queries.CardQueries.GetCardsByDeckId;

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

        [HttpPost]
        public async Task<IActionResult> CreateCard(CreateCardCommand createCardCommand)
        {
            var result = await _mediator.Send(createCardCommand);
            return Ok(result);
        }

        //[HttpPut("{cardId}")]
        //public async Task<IActionResult> UpdateCard(Guid cardId, UpdateCardCommand updateCardCommand)
        //{
        //    updateCardCommand.CardId = cardId;
        //    await _mediator.Send(updateCardCommand);
        //    return Ok();
        //}

        //[HttpDelete("{cardId}")]
        //public async Task<IActionResult> DeleteCardById(Guid cardId)
        //{
        //    var deleteCardCommand = new DeleteCardCommand(cardId);
        //    await _mediator.Send(deleteCardCommand);
        //    return Ok();
        //}
    }
}
