using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Repositories;
using MyAwesomeDecks.Domain.Services;
using MyAwesomeDecks.Infrastructure.Exceptions;

namespace MyAwesomeDecks.Infrastructure.Services
{
    public class DeckService : IDeckService
    {
        private readonly IDeckRepository _deckRepository;

        public DeckService(IDeckRepository deckRepository)
        {
            _deckRepository = deckRepository;
        }

        public IQueryable<Deck> GetDecksByUserId(Guid userId)
        {
            return _deckRepository.GetDecksByUserId(userId);
        }

        public async Task<Deck> CreateDeckAsync(Deck deck) {
            var result = await _deckRepository.CreateDeckAsync(deck);
            return result;
        }

        public async Task UpdateDeckAsync(Guid deckId, Deck deckToUpdate)
        {
            await ThrowDeckNotFoundExceptionIfDeckNotExists(deckId);
            await _deckRepository.UpdateDeckAsync(deckToUpdate);
        }

        public async Task DeleteDeckByIdAsync(Guid id)
        {
            await ThrowDeckNotFoundExceptionIfDeckNotExists(id);
            await _deckRepository.DeleteByIdAsync(id);
        }

        private async Task ThrowDeckNotFoundExceptionIfDeckNotExists(Guid deckId)
        {
            var deck = await _deckRepository.GetByIdAsync(deckId);
            if (deck == null)
                throw new DeckNotFoundException();
        }
    }
}
