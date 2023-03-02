using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Domain.Services
{
    public interface IDeckService
    {
        IQueryable<Deck> GetDecksByUserId(Guid userId);
    }
}
