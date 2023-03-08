using MyAwesomeDecks.Domain.Entities;

namespace MyAwesomeDecks.Domain.Services
{
    public interface IDeckService
    {
        IQueryable<Deck> GetDecksByUserId(Guid userId);
        Task<Deck> CreateDeckAsync(Deck deck);
        Task UpdateDeckAsync(Guid deckId, Deck deckToUpdate);
        Task DeleteDeckByIdAsync(Guid id);
    }
}
