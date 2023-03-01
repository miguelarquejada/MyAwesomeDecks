using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAwesomeDecks.Application.Queries.GetDecks;

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

        [HttpGet("/user/{id}")]
        public async Task<IActionResult> GetAllByUserId(Guid userId)
        {
            var getDecksQuery = new GetDecksQuery(userId);
            var result = await _mediator.Send(getDecksQuery);
            return Ok(result);
        }
    }
}
