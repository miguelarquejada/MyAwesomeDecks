using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Domain.Repositories
{
    public interface ICardRepository : IRepository<Card>
    {
        IQueryable<Card> GetCardsByDeckId(Guid deckId);
    }
}
