using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Domain.Repositories
{
    public interface IDeckRepository : IRepository<Deck>
    {
        IQueryable<Deck> GetDecksByUserId(Guid userId);
        Task<Deck> CreateDeckAsync(Deck deck);
        Task UpdateDeckAsync(Deck deck);
    }
}
