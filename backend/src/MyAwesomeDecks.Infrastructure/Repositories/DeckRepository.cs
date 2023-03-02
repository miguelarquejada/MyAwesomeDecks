using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Repositories;
using MyAwesomeDecks.Infrastructure.Data.Context;

namespace MyAwesomeDecks.Infrastructure.Repositories
{
    public class DeckRepository : Repository<Deck>, IDeckRepository
    {
        public DeckRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IQueryable<Deck> GetDecksByUserId(Guid userId)
        {
            return GetAll().Where(x => x.UserId == userId);
        }
    }
}
