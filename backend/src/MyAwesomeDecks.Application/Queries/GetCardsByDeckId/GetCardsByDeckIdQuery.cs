using MediatR;
using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Application.Queries.GetCardsByDeck
{
    public class GetCardsByDeckIdQuery : IRequest<IEnumerable<Card>>
    {
        public GetCardsByDeckIdQuery(Guid deckId)
        {
            DeckId = deckId;
        }

        public Guid DeckId { get; set; }
    }
}
