using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Repositories;

namespace MyAwesomeDecks.Infrastructure.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
    }
}
