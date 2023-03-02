using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Repositories;
using MyAwesomeDecks.Domain.Services;

namespace MyAwesomeDecks.Infrastructure.Services
{
    public class CardService : ICardService
    {

        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public IQueryable<Card> GetCardsByDeckId(Guid deckId)
        {
            return _cardRepository.GetCardsByDeckId(deckId);
        }
    }
}
