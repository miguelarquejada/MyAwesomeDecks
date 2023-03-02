using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Domain.Services
{
    public interface ICardService
    {
        IQueryable<Card> GetCardsByDeckId(Guid deckId);
    }
}
