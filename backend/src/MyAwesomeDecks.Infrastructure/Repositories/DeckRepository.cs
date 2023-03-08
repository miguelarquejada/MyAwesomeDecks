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

        public async Task<Deck> CreateDeckAsync(Deck deck)
        {
            await CreateAsync(deck);
            return deck;
        }

        public async Task UpdateDeckAsync(Deck deck)
        {
            await UpdateAsync(deck);
        }

        public async Task DeleteDeckByIdAsync(Guid id)
        {
            await DeleteByIdAsync(id);
        }
    }
}
