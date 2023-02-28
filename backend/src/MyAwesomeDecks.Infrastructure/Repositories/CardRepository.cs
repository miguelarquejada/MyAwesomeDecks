using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Repositories;
using MyAwesomeDecks.Infrastructure.Data.Context;

namespace MyAwesomeDecks.Infrastructure.Repositories
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
