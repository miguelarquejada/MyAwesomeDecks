using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Repositories;
using MyAwesomeDecks.Domain.Services;

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
    }
}
