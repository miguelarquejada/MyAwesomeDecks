using MediatR;
using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Services;

namespace MyAwesomeDecks.Application.Queries.GetCardsByDeck
{
    public class GetCardsByDeckIdHandler : IRequestHandler<GetCardsByDeckIdQuery, IEnumerable<Card>>
    {
        private readonly ICardService _cardService;

        public GetCardsByDeckIdHandler(ICardService cardService)
        {
            _cardService = cardService;
        }

        public async Task<IEnumerable<Card>> Handle(GetCardsByDeckIdQuery request, CancellationToken cancellationToken)
        {
            var result = _cardService.GetCardsByDeckId(request.DeckId).ToList();
            return result;
        }
    }
}
