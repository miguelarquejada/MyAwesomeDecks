using MyAwesomeDecks.Domain.Entities;
using MyAwesomeDecks.Domain.Repositories;
using MyAwesomeDecks.Domain.Services;
using MyAwesomeDecks.Infrastructure.Exceptions;

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

        public async Task<Card> CreateCardAsync(Card card)
        {
            await _cardRepository.CreateAsync(card);
            return card;
        }

        public async Task UpdateCardAsync(Card card)
        {
            await ThrowCardNotFoundExceptionIfCardNotExists(card.Id);
            await _cardRepository.UpdateAsync(card);
        }

        public async Task DeleteCardByIdAsync(Guid id)
        {
            await ThrowCardNotFoundExceptionIfCardNotExists(id);
            await _cardRepository.DeleteByIdAsync(id);
        }

        private async Task ThrowCardNotFoundExceptionIfCardNotExists(Guid id)
        {
            var deck = await _cardRepository.GetByIdAsync(id);
            if (deck == null)
                throw new CardNotFoundException();
        }
    }
}
