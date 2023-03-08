using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAwesomeDecks.Application.Commands.DeckCommands.CreateDeck;
using MyAwesomeDecks.Application.Commands.DeckCommands.DeleteDeck;
using MyAwesomeDecks.Application.Commands.DeckCommands.UpdateDeck;
using MyAwesomeDecks.Application.Queries.DeckQueries.GetDecksByUserId;

namespace MyAwesomeDecks.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class DeckController : Controller
    {
        private readonly IMediator _mediator;

        public DeckController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetAllByUserId(Guid userId)
        {
            var getDecksQuery = new GetDecksByUserIdQuery(userId);
            var result = await _mediator.Send(getDecksQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeck(CreateDeckCommand createDeckCommand)
        {
            var result = await _mediator.Send(createDeckCommand);
            return Ok(result);
        }

        [HttpPut("{deckId}")]
        public async Task<IActionResult> UpdateDeck(Guid deckId, UpdateDeckCommand updateDeckCommand)
        {
            updateDeckCommand.Id = deckId;
            await _mediator.Send(updateDeckCommand);
            return Ok();
        }

        [HttpDelete("{deckId}")]
        public async Task<IActionResult> DeleteDeckById(Guid deckId)
        {
            var deleteDeckCommand = new DeleteDeckCommand(deckId);
            await _mediator.Send(deleteDeckCommand);
            return Ok();
        }
    }
}
