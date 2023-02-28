using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Repositories;
using MyAwesomeDecks.Infrastructure.Data.Context;

namespace MyAwesomeDecks.Infrastructure.Repositories
{
    public class DeckCardRepository : Repository<DeckCard>, IDeckCardRepository
    {
        public DeckCardRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
